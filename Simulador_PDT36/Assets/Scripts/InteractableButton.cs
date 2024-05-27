using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    public PDT36Controller machine;
    void OnCollisionEnter(Collision collision)
    {
        machine.CallButtonPressed(this.name);
    }
}
