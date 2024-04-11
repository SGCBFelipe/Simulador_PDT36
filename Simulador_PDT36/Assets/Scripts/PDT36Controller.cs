using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

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
    #endregion

    private void Start()
    {
        _tempRotLeft = _leftStick.rotation; // Stores the initial rotation of the _leftStick
        _tempRotRight = _rightStick.rotation; // Stores the initial rotation of the _rightStick
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

    private void FixedUpdate()
    {
        print(this.GetComponent<Rigidbody>().transform.position);
        if (_leftMove + _rightMove != Vector2.zero) { _machine.Accelerate(); }
        else { _machine.Decelerate(); _lever.ResetLeverRotation(); }

        if (_leftMove.y > 0 && _rightMove.y > 0)
        {
            _machine.Forward();
        }
    }
}

public class MachineMovement
{
    private float currentSpeed, maxSpeed = 15f, accelerationRate = 10f, maxRotation = 20f;
    private bool canRotate = true;
    private GameObject PDT36;
    private Rigidbody _rb;

    #region Getters & Setters
    public Rigidbody RB { get { return _rb; } set { _rb = value; } }

    public GameObject SetPDT36 { set { PDT36 = value; } }

    public void SetCanRotate() { canRotate = true; }
    #endregion

    #region Acceleration & Deceleration System
    public void Accelerate() 
    {
        Debug.Log("Entrou");
        if(currentSpeed <= maxSpeed) { currentSpeed += accelerationRate * Time.fixedDeltaTime; }
    }

    public void Decelerate()
    {
        if (currentSpeed >= 0f) { currentSpeed -= accelerationRate * Time.fixedDeltaTime; }
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
