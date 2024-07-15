using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMnager : MonoBehaviour
{
    public string scene;
    [SerializeField] private GameObject _indexMenu;
    [SerializeField] private GameObject _mapMenu;

    public void Play()
    {
        SceneManager.LoadScene(scene);
    }

    public void Maps()
    {
        _indexMenu.SetActive(false);
        _mapMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
