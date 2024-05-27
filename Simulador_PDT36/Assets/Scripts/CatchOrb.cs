using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchOrb : MonoBehaviour
{
    public GameManager manager;
    private int phrasesCount;

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (manager.phrasesList != null && manager.phrasesList.Count != 0)
        {
            phrasesCount = Random.RandomRange(0, manager.phrasesList.Count);
            manager.ActivePhrase = false;
            manager.EnableNewPhrase(phrasesCount);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("Não há frases na lista");
        }
    }
}
