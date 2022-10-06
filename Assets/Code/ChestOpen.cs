using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{

    public Animator animator;

    private bool hasBeenOpened = false;



    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player") && !hasBeenOpened) {
          DialogController.instance.DisplayMessage(" A treasure chest, the small gap between its lid and body gleaming with light. It was almost calling to you, begging you to open it. You oblige.");
          animator.SetBool("isOpen", true);
          hasBeenOpened = true;
        }
    }
}
