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
        _inputMap = _input.currentActionMap; //Receberá o mapa de controle selecionado

        if(_input.currentActionMap.name == "Keyboard")
        {
            #region Left Control
            pdt.LeftInput = _inputMap.FindAction("KB_Left");// WASD
            pdt.RightInput = _inputMap.FindAction("KB_Right");// Arrows
            #endregion
        }
    }
}
