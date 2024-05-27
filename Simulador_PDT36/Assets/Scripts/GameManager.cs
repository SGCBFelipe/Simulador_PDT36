using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    #region Privates
    private PlayerInput _input;
    private InputActionMap _inputMap;
    private float time;
    #endregion

    #region Publics
    public PDT36Controller pdt;
    public TextMeshProUGUI veloctyText, timer, phrase;
    public TimeType timeType;
    [SerializeField] private float timeTarget;
    public List<string> phrasesList = new();
    public bool ActivePhrase = false;
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
        else if (_input.currentActionMap.name == "Xbox Controller")
        {
            pdt.LeftInput = _inputMap.FindAction("XCTL_Left"); // Left stick
            pdt.RightInput = _inputMap.FindAction("XCTL_Right"); // Right stick
        }
        // VR Controller
        else
        {
            pdt.LeftInput = _inputMap.FindAction("VR_Left"); // VR Left stick
            pdt.RightInput = _inputMap.FindAction("VR_Right"); // VR Right stick
        }
        #endregion

        if (timeType == TimeType.Countdown)
        {
            time = timeTarget;
        }
    }

    private void Update()
    {
        veloctyText.text = "Velocity: " + (int)pdt.currentSpeed;
        switch (timeType)
        {
            case TimeType.Countdown:
                Countdown();
                break;
            case TimeType.Time:
                Timer();
                break;
        }
    }

    #region Timer
    public enum TimeType
    {
        Countdown,
        Time
    }

    public void Countdown()
    {
        if(time > 0) { time -= Time.deltaTime; }
        else { time = 0; }        
        int min = Mathf.FloorToInt(time / 60);
        int sec = Mathf.FloorToInt(time % 60);
        timer.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    public void Timer()
    {
        if(time <= timeTarget)
        {
            time += Time.deltaTime;
            int min = Mathf.FloorToInt(time / 60);
            int sec = Mathf.FloorToInt(time % 60);
            timer.text = string.Format("{0:00}:{1:00}", min, sec);
        }
    }
    #endregion

    public void EnableNewPhrase(int index)
    {
        if (index >= 0 && index < phrasesList.Count)
        {
            phrase.text = phrasesList[index];
            if (!ActivePhrase) 
            {
                phrase.GetComponent<Animator>().Play("PhraseFadeAnimation");
                ActivePhrase = true;
            }
            phrasesList.RemoveAt(index);
        }
        else
        {
            Debug.LogWarning("�ndice fora dos limites da lista de frases");
        }
    }
}
