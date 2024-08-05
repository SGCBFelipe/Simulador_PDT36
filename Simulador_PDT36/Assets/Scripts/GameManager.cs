using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Privates
    private PlayerInput _input;
    private InputActionMap _inputMap;
    private float _time;
    private int _tutoIndex = 0;
    #endregion

    #region Publics
    public PDT36Controller pdt;
    public Camera playerCamera;
    public AudioManager audioManager;
    public TextMeshProUGUI veloctyText, timer, tutorialButtonText;
    public GameObject orbImage, videoForwardBack, videoLeftRight, videoSelfRotation, logo, BG, restartGameButton;
    public TimeType timeType;
    [SerializeField] private float timeTarget;
    public List<Sprite> imagesList = new();
    public bool ActiveImage = false, start = false;
    public RenderTexture[] videosTextures;

    [Header("Game Canvas")]
    public List<GameObject> canvasGame = new();

    [Header("Tutorial Canvas")]
    public List<GameObject> tutorialCanvas = new();

    [Header("End Game Canvas")]
    public List<GameObject> endGameCanvas = new();
    #endregion

    private void Start()
    {
        StartCoroutine(Fade(logo, "FadeIn", true, 0.5f));
        StartCoroutine(Fade(logo, "FadeOut", true, 3.5f));
        StartCoroutine(Fade(BG, "FadeIn", true, 4f));
        StartCoroutine(Fade(videoForwardBack, "FadeIn", true, 5f));
        StartCoroutine(Fade(videoLeftRight, "FadeIn", true, 5f));
        StartCoroutine(Fade(videoSelfRotation, "FadeIn", true, 5f));
        StartCoroutine(Fade(BG, "FadeOut", true, 15f));
        StartCoroutine(Fade(videoForwardBack, "FadeOut", true, 15f));
        StartCoroutine(Fade(videoLeftRight, "FadeOut", true, 15f));
        StartCoroutine(Fade(videoSelfRotation, "FadeOut", true, 15f));
        Invoke("TurnOnMachine", 15f);
    }

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

        //_inputMap.FindAction("ButtonOnOff").performed += TurnOnMachine;
        #endregion

        if (timeType == TimeType.Countdown)
        {
            _time = timeTarget;
        }
    }

    private void Update()
    {
        veloctyText.text = "Velocity: " + (int)pdt.currentSpeed;
        if (start)
        {
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
    }

    public void TurnOnMachine()
    {
        foreach(GameObject obj in tutorialCanvas)
        {
            Destroy(obj);
        }

        foreach (GameObject obj in canvasGame)
        {
            obj.SetActive(true);
        }

        start = true;
        pdt.onOffMachine = true;
        if (pdt.onOffMachine) { audioManager.PlaySound("Partida"); }
        StartCoroutine(PlayMotor());
    }

    public void TurnOffMachine()
    {
        foreach(GameObject obj in endGameCanvas)
        {
            obj.SetActive(true);
        }

        foreach(GameObject obj in canvasGame)
        {
            obj.SetActive(false);
        }
        pdt.onOffMachine = false;
        start = false;
        //restartGameButton.GetComponent<Button>().interactable = true;
        if (!pdt.onOffMachine) { audioManager.StopSound("Motor"); audioManager.StopSound("Laminas"); }
    }

    public void EnableNewPhrase(int index)
    {
        if (index >= 0 && index < imagesList.Count)
        {
            orbImage.GetComponent<Image>().sprite = imagesList[index];
            if (!ActiveImage) 
            {
                orbImage.GetComponent<Animator>().SetBool("Active", true);
                ActiveImage = true;
            }
            imagesList.RemoveAt(index);
        }
        else
        {
            Debug.LogWarning("Índice fora dos limites da lista de frases");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #region Tutorial
    //public void NextTutorial()
    //{
    //    if(_tutoIndex >= videosTextures.Length)
    //    {
    //        return;
    //    }
    //    else
    //    {
    //        if (_tutoIndex == 0)
    //        {
    //            logo.GetComponent<Animator>().SetBool("FadeOut", true);
    //            StartCoroutine(SetEnable(logo, false, 3f));
    //            videoForwardBack.GetComponent<RawImage>().texture = videosTextures[_tutoIndex];
    //            videoForwardBack.GetComponent<Animator>().SetBool("FadeIn", true);
    //            _tutoIndex++;
    //        }
    //        else
    //        {
    //            videoForwardBack.GetComponent<Animator>().SetBool("FadeIn", false);
    //            videoForwardBack.GetComponent<Animator>().SetBool("FadeOut", true);
    //            videoForwardBack.GetComponent<RawImage>().texture = videosTextures[_tutoIndex];
    //            videoForwardBack.GetComponent<Animator>().SetBool("FadeIn", true);
    //            //StartCoroutine(Fade(videoForwardBack, "FadeIn", true, 0.5f));
    //            StartCoroutine(Fade(videoForwardBack, "FadeOut", false, 0.5f));
    //            _tutoIndex++;
    //        }
    //    }
    //}

    #endregion

    #region Timer
    public enum TimeType
    {
        Countdown,
        Time
    }

    public void Countdown()
    {
        if(_time > 0) { _time -= Time.deltaTime; }
        else { _time = 0; }        
        int min = Mathf.FloorToInt(_time / 60);
        int sec = Mathf.FloorToInt(_time % 60);
        timer.text = string.Format("{0:00}:{1:00}", min, sec);

        if(_time <= 0)
        {
            TurnOffMachine();
        }
    }

    public void Timer()
    {
        if(_time <= timeTarget)
        {
            _time += Time.deltaTime;
            int min = Mathf.FloorToInt(_time / 60);
            int sec = Mathf.FloorToInt(_time % 60);
            timer.text = string.Format("{0:00}:{1:00}", min, sec);
        }
    }
    #endregion
    
    #region Coroutines
    private IEnumerator PlayMotor()
    {
        AudioSource partidaSource = audioManager.GetAudioSource("Partida");
        while (partidaSource.isPlaying)
        {
            yield return null;
        }

        audioManager.PlaySound("Motor");
    }

    IEnumerator SetEnable(GameObject obj, bool value, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(value);
    }

    IEnumerator Fade(GameObject obj, string parameter, bool value, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        obj.GetComponent<Animator>().SetBool(parameter, value);
    }
    #endregion
}