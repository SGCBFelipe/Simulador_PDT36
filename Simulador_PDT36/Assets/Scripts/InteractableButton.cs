using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    public PDT36Controller machine;
    private void OnTriggerEnter(Collider other)
    {
        machine.CallButtonPressed(this.name);
    }
}
