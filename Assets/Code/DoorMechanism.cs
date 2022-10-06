using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanism : MonoBehaviour
{

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        // animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            animator.SetBool("wantToOpen", true);
            print("Animation done!!");
        }
    }

    private void OnTriggerEnter(Collider other) {
        print("Hello enter");
    }

    private void OnTriggerStay(Collider other) {
        print("Hello");
        // if (Input.GetKeyDown(KeyCode.E) && (other.CompareTag("Player"))) {
          animator.SetBool("wantToOpen", true);
        // }

    }
}
