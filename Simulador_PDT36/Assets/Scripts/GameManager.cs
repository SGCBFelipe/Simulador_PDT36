using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    #region Privates
    private PlayerInput _input;
    private InputActionMap _inputMap;
    #endregion

    #region Publics
    public PDT36Controller pdt;
    #endregion

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _inputMap = _input.currentActionMap;

        #region Assigning Controls
        _inputMap = _input.currentActionMap; // Receive the selected control map
        // Keyboard Controller
        if (_input.currentActionMap.name == "Keyboard") 
        {
            pdt.LeftInput = _inputMap.FindAction("KB_Left"); // WASD
            pdt.RightInput = _inputMap.FindAction("KB_Right"); // Arrows
        }
        // Xbox Controller
        else
        {
            pdt.LeftInput = _inputMap.FindAction("XCTL_Left"); // Left stick
            pdt.RightInput = _inputMap.FindAction("XCTL_Right"); // Right stick
        }
        #endregion
    }
}
