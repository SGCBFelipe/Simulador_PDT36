using System;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PDT36Controller : MonoBehaviour
{
    #region Privates
    private Vector2 _leftMove, _rightMove;
    private Rigidbody _rb;
    private InputAction _leftControl, _rightControl;
    [SerializeField] private Transform _leftStick, _rightStick;
    private Quaternion _tempRotLeft, _tempRotRight;
    private MachineMovement _machine;
    private LeversMovement _lever;
    private bool onOffVehicle = false, onOffLights = true, onOffCanvas = true;
    #endregion

    #region Publics
    #region Inspector
    [ReadOnly]
    public float currentSpeed;
    public float maxSpeed = 15f, accelerationRate = 10f, decelerationRate = 2f, leverSpeedRotation = 30f;
    public Vector3 machineVelocity;
    public GameObject canvas, machineLights;
    #endregion
    #endregion

    #region Getters & Setters
    public InputAction LeftInput
    {
        get { return _leftControl; }
        set { _leftControl = value; }
    }

    public InputAction RightInput
    {
        get { return _rightControl; }
        set { _rightControl = value; }
    }

    public Vector2 SetLeftControl(Vector2 value) { return _leftMove = value; }

    public Vector2 SetRightControl(Vector2 value) { return _rightMove = value; }

    private void CallSetCanRotate() { _machine.CanRotate = true; }
    #endregion

    #region Buttons
    public void CallButtonPressed(string buttonName)
    {
        switch (buttonName)
        {
            case "OnOffVehicleButtonVisual":
                onOffVehicle = !onOffVehicle;
                break;
            case "LightsButtonVisual":
                machineLights.SetActive(!onOffLights);
                break;
            case "ActiveHUDVisual":
                canvas.SetActive(!onOffCanvas);
                break;
            default:
                throw new WarningException($"Button named {buttonName} does not exist");
        } 
    }
    #endregion

    private void Start()
    {
        _tempRotLeft = _leftStick.rotation; // Stores the initial rotation of the _leftStick
        _tempRotRight = _rightStick.rotation; // Stores the initial rotation of the _rightStick

        _machine.MaxSpeed = maxSpeed;
        _machine.AccelerationRate = accelerationRate;
        _machine.DecelerationRate = decelerationRate;
        machineVelocity = new Vector3();
    }

    private void Awake()
    {

        #region Assigning Variables
        #region Machine
        _rb = GetComponent<Rigidbody>();
        _machine = new MachineMovement
        {
            RB = _rb,
            SetPDT36 = this.gameObject
        };
        #endregion
        #region Levers
        _lever = new LeversMovement
        {
            LeftLever = _leftStick,
            RightLever = _rightStick,
            SpeedRotation = leverSpeedRotation,
        };
        #endregion
        #endregion

        LeftInput.performed += ctx => SetLeftControl(ctx.ReadValue<Vector2>());
        LeftInput.canceled += ctx => SetLeftControl(Vector2.zero);
        RightInput.performed += ctx => SetRightControl(ctx.ReadValue<Vector2>());
        RightInput.canceled += ctx => SetRightControl(Vector2.zero);
    }
    
    private void Update()
    {
        currentSpeed = _machine.GetCurrentSpeed;
        _lever.RotationWithInput(_leftMove, _leftStick);
        _lever.RotationWithInput(_rightMove, _rightStick);
        machineVelocity = _rb.velocity;
        _machine.MaxVelocity();
    }

    private void FixedUpdate()
    {
        // Calculates whether there was any type of movement and then accelerates
        if (_leftMove + _rightMove != Vector2.zero) { _machine.AccelerateSpeed(); }
        else { _machine.DecelerateSpeed(); }

        #region Call Movements
        // Forward
        if (_leftMove.y > 0 && _rightMove.y > 0)
        {
            _machine.Forward();
            //_lever.LeverRotation(_leftMove, _leftStick);
            //_lever.LeverRotation(_rightMove, _rightStick);
        }

        // Left
        if (_leftMove.x < 0 && _rightMove.x < 0)
        {
            _machine.Left();
            //_lever.LeverRotation(-_leftMove, _leftStick);
            //_lever.LeverRotation(-_rightMove, _rightStick);
        }

        // Right
        if (_leftMove.x > 0 && _rightMove.x > 0)
        {
            _machine.Right();
            //_lever.LeverRotation(-_leftMove, _leftStick);
            //_lever.LeverRotation(-_rightMove, _rightStick);
        }

        // Back
        if (_leftMove.y < 0 && _rightMove.y < 0)
        {
            _machine.Back();
            //_lever.LeverRotation(_leftMove, _leftStick);
            //_lever.LeverRotation(_rightMove, _rightStick);
        }

        // Can Rotate
        else
        {
            Invoke(nameof(CallSetCanRotate), 1f);
        }
        #endregion

        #region Call Rotations
        // Left Forward
        if (_leftMove.y > 0 && _rightMove.y < 0 && _machine.CanRotate)
        {
            _machine.LeftForward();
            //_lever.LeverRotation(_leftMove, _leftStick);
            //_lever.LeverRotation(_rightMove, _rightStick);
        }

        // Right Forward
        else if (_rightMove.y > 0 && _leftMove.y < 0 && _machine.CanRotate)
        {
            _machine.RightForward();
            //_lever.LeverRotation(_leftMove, _leftStick);
            //_lever.LeverRotation(_rightMove, _rightStick);
        }

        //_machine.MaxVelocity(new Vector3(_leftMove.x + _rightMove.x, 0f, _leftMove.y + _rightMove.y));
        #endregion
    }


}

#region Movements
public class MachineMovement
{
    private float currentSpeed, maxSpeed, accelerationRate, decelerationRate;
    private bool canRotate = true;
    private GameObject PDT36;
    private Rigidbody _rb;

    #region Getters & Setters
    public Rigidbody RB { get { return _rb; } set { _rb = value; } }

    public GameObject SetPDT36 { set { PDT36 = value; } }

    public bool CanRotate { get { return canRotate; } set { canRotate = value; } }

    public float GetCurrentSpeed { get { return currentSpeed; } }

    public float MaxSpeed { get { return maxSpeed; } set { maxSpeed = value; } }

    public float AccelerationRate { get { return accelerationRate; } set { accelerationRate = value; }}

    public float DecelerationRate { get { return decelerationRate; } set { decelerationRate = value; }}
    #endregion

    #region Acceleration & Deceleration System
    public void AccelerateSpeed()
    {
        if (currentSpeed <= maxSpeed) { currentSpeed += accelerationRate * Time.fixedDeltaTime; }
    }

    public void DecelerateSpeed()
    {
        if (currentSpeed > 0) { currentSpeed -= decelerationRate * Time.fixedDeltaTime; }
        if (currentSpeed < 0) { currentSpeed = 0; }
        Stop();
    }
    #endregion

    #region Movement System
    public void Forward()
    {
        _rb.AddForce(PDT36.transform.forward * currentSpeed);
        canRotate = false;
    }

    public void Back()
    {
        _rb.AddForce(-PDT36.transform.forward * currentSpeed);
        canRotate = false;
    }

    public void Left()
    {
        _rb.AddForce(-PDT36.transform.right * currentSpeed);
        canRotate = false;
    }

    public void Right()
    {
        _rb.AddForce(PDT36.transform.right * currentSpeed);
        canRotate = false;
    }
    #endregion

    #region Rotation System
    public void LeftForward() { PDT36.transform.Rotate(Vector3.up); }

    public void LeftBack() { PDT36.transform.Rotate(-Vector3.up); }

    public void RightForward() { PDT36.transform.Rotate(Vector3.down); }

    public void RightBack() { PDT36.transform.Rotate(-Vector3.down); }

    #endregion

    #region Velocity System
    public void MaxVelocity()
    {
        if (_rb.velocity.magnitude > maxSpeed) { _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, maxSpeed); }
    }

    public void Stop()
    {
        if (currentSpeed < 0 && _rb.velocity.magnitude > 0)
        {
            _rb.velocity = Vector3.zero;
        }
    }
    #endregion
}

public class LeversMovement
{
    private Transform _leftLever, _rightLever;
    private float speed = 100f, rotationLimit = 30f;

    #region Getters & Setters
    public Transform LeftLever
    {
        get { return _leftLever; }
        set { _leftLever = value; }
    }

    public Transform RightLever
    {
        get { return _rightLever; }
        set { _rightLever = value; }
    }

    public float SpeedRotation
    {
        get { return speed; }
        set { speed = value; }
    }
    #endregion

    public void RotationWithInput(Vector3 input, Transform lever)
    {
        if (input.magnitude > 0)
        {
            Vector3 adjustedLeverRotation = new(input.y, 0f, -input.x), currentRotation = lever.localEulerAngles;

            currentRotation.x = (currentRotation.x > 180) ? currentRotation.x - 360 : currentRotation.x;
            currentRotation.z = (currentRotation.z > 180) ? currentRotation.z - 360 : currentRotation.z;

            float newRotationX = Mathf.Clamp(currentRotation.x + adjustedLeverRotation.x, 15f - rotationLimit, 15f + rotationLimit);
            float newRotationZ = Mathf.Clamp(currentRotation.z + adjustedLeverRotation.z, -rotationLimit, rotationLimit);

            Quaternion targetRotation = Quaternion.Euler(newRotationX, currentRotation.y, newRotationZ);

            lever.localRotation = Quaternion.RotateTowards(lever.localRotation, targetRotation, speed);
        }
        else { lever.localRotation = Quaternion.Euler(15f, 0f, 0f); }
    }
}
#endregion

#region Inspector ReadOnly System
public class ReadOnlyAttribute : PropertyAttribute { }
#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}
#endif
#endregion
