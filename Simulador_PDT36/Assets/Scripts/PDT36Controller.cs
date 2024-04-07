using UnityEngine;
using UnityEngine.InputSystem;

public class PDT36Controller : MonoBehaviour
{
    #region Privates
    private Rigidbody _rb;
    private Vector2 _leftmove, _rightmove, _move;
    private InputAction _leftControl, _rightControl;
    [SerializeField] private Transform _leftStick, _rightStick;
    private Vector3 _tempRotLeft, _tempRotRight;
    #endregion

    #region Publics
    public float currentSpeed, acelerationRate = 10f, maxSpeed = 20f, maxRotation = 20f;
    public bool canRotate = true;
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

    public Vector2 SetLeftControl(Vector2 value)
    {
        return _leftmove = value;
    }

    public Vector2 SetRightControl(Vector2 value)
    {
        return _rightmove = value;
    }
    #endregion

    private void Start()
    {
        //No início, é pego a rotação inicial e guarda nas temporárias
        //para que possam ser utilizadas no reset
        _tempRotLeft = _leftStick.position;
        _tempRotRight = _rightStick.position;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        LeftInput.performed += ctx => SetLeftControl(ctx.ReadValue<Vector2>());
        LeftInput.canceled += ctx => SetLeftControl(Vector2.zero);
        RightInput.performed += ctx => SetRightControl(ctx.ReadValue<Vector2>());
        RightInput.canceled += ctx => SetRightControl(Vector2.zero);
    }
}
