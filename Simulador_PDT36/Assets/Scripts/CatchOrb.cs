using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchOrb : MonoBehaviour
{
    public GameManager manager;
    private int imagesCount;

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (manager.imagesList != null && manager.imagesList.Count != 0)
        {
            imagesCount = Random.RandomRange(0, manager.imagesList.Count);
            manager.ActiveImage = false;
            manager.EnableNewPhrase(imagesCount);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("Não há frases na lista");
        }
    }

    public void StopImageAnimation()
    {
        manager.orbImage.GetComponent<Animator>().SetBool("Active", false);
    }
}