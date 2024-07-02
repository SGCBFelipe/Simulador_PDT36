using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhraseStop : MonoBehaviour
{
    public GameManager manager;

    public void StopPhraseAnimation()
    {
        manager.phrase.GetComponent<Animator>().SetBool("Active", false);
    }
}
