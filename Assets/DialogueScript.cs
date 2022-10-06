using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    private bool active = true;
    public string  message = "Empty dialog";

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && active)
        {
            active = false;
            DialogController.instance.DisplayMessage(message);
        }
    }
}
