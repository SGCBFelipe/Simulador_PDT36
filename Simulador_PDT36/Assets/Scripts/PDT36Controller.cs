using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PDT36Controller : MonoBehaviour
{
    #region Privates
    private Vector2 _leftMove, _rightMove, _move;
    private Rigidbody _rb;
    private InputAction _leftControl, _rightControl;
    [SerializeField] private Transform _leftStick, _rightStick;
    private Quaternion _tempRotLeft, _tempRotRight;
    private MachineMovement _machine;
    private LeversMovement _lever;
    #endregion

    #region Publics
    #region Inspector
    [ReadOnly]
    public float currentSpeed;
    public float maxSpeed = 15f, accelerationRate = 10f, decelerationRate = 2f;
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

    private void Start()
    {
        _tempRotLeft = _leftStick.rotation; // Stores the initial rotation of the _leftStick
        _tempRotRight = _rightStick.rotation; // Stores the initial rotation of the _rightStick

        _machine.MaxSpeed = maxSpeed;
        _machine.AccelerationRate = accelerationRate;
        _machine.DecelerationRate = decelerationRate;
    }

    private void Awake()
    {

        #region Assigning Variables
        #region Machine
        _machine = new MachineMovement();
        _machine.RB = GetComponent<Rigidbody>();
        _machine.SetPDT36 = this.gameObject;
        #endregion
        #region Levers
        _lever = new LeversMovement();
        _lever.LeftLever = _leftStick;
        _lever.RightLever = _rightStick;
        _lever.LeftReset = _tempRotLeft;
        _lever.RightReset = _tempRotRight;
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
    }

    private void FixedUpdate()
    {
        // Calculates whether there was any type of movement and then accelerates
        if (_leftMove + _rightMove != Vector2.zero) { _machine.Accelerate(); }
        else { _machine.Decelerate(); _lever.ResetLeverRotation(); }

        #region Call Movements
        // Forward
        if (_leftMove.y > 0 && _rightMove.y > 0)
        {
            _machine.Forward();
            _lever.LeverRotation(_leftMove, _leftStick);
            _lever.LeverRotation(_rightMove, _rightStick);
        }

        // Left
        else if (_leftMove.x < 0 && _rightMove.x < 0)
        {
            _machine.Left();
            _lever.LeverRotation(-_leftMove, _leftStick);
            _lever.LeverRotation(-_rightMove, _rightStick);
        }

        // Right
        else if (_leftMove.x > 0 && _rightMove.x > 0)
        {
            _machine.Right();
            _lever.LeverRotation(-_leftMove, _leftStick);
            _lever.LeverRotation(-_rightMove, _rightStick);
        }

        // Back
        else if (_leftMove.y < 0 && _rightMove.y < 0)
        {
            _machine.Back();
            _lever.LeverRotation(_leftMove, _leftStick);
            _lever.LeverRotation(_rightMove, _rightStick);
        }

        // Can Rotate
        else
        {
            Invoke("CallSetCanRotate", 1f);
        }
        #endregion

        #region Call Rotations
        // Left Forward
        if (_leftMove.y > 0 && _rightMove.y < 0 && _machine.CanRotate)
        {
            _machine.LeftForward();
            _lever.LeverRotation(_leftMove, _leftStick);
            _lever.LeverRotation(_rightMove, _rightStick);
        }

        // Right Forward
        else if (_rightMove.y > 0 && _leftMove.y < 0 && _machine.CanRotate)
        {
            _machine.RightForward();
            _lever.LeverRotation(_leftMove, _leftStick);
            _lever.LeverRotation(_rightMove, _rightStick);
        }

        //// Left Back
        //else if (_leftMove.y < 0 && _rightMove.y > 0 && _machine.CanRotate)
        //{
        //    _machine.LeftBack();
        //    _lever.LeverRotation(_leftMove, _leftStick);
        //    _lever.LeverRotation(_rightMove, _rightStick);
        //}

        //// Right Back
        //else if (_rightMove.y < 0 && _leftMove.y > 0 && _machine.CanRotate)
        //{
        //    _machine.RightBack();
        //    _lever.LeverRotation(_leftMove, _leftStick);
        //    _lever.LeverRotation(_rightMove, _rightStick);
        //}
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
    public void Accelerate()
    {
        if (currentSpeed <= maxSpeed) { currentSpeed += accelerationRate * Time.fixedDeltaTime; }
    }

    public void Decelerate()
    {
        if (currentSpeed >= 0f) { currentSpeed -= (accelerationRate * decelerationRate) * Time.fixedDeltaTime; }
        else { currentSpeed = 0f; }
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
}

public class LeversMovement
{
    private Transform _leftLever, _rightLever;
    private Quaternion _leftReset, _rightReset;

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

    public Quaternion LeftReset
    {
        get { return _leftReset; }
        set { _leftReset = value; }
    }

    public Quaternion RightReset
    {
        get { return _rightReset; }
        set { _rightReset = value; }
    }
    #endregion

    public void LeverRotation(Vector3 input, Transform lever)
    {
        input = new Vector3(input.y, 0, input.x);
        lever.Rotate(input * 2f);

        Vector3 localAngle = lever.localEulerAngles;

        if (localAngle.x > 180f) { localAngle.x -= 360f; } 
        if (localAngle.z > 180f) { localAngle.z -= 360f; }

        localAngle.x = Mathf.Clamp(localAngle.x, -20f, 20f);
        localAngle.z = Mathf.Clamp(localAngle.z, -20f, 20f);

        lever.localEulerAngles = localAngle;
    }

    public void ResetLeverRotation()
    {
        _leftLever.rotation = Quaternion.Slerp(_leftLever.rotation, _leftReset, 100f);
        _rightLever.rotation = Quaternion.Slerp(_rightLever.rotation, _rightReset, 100f);
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
