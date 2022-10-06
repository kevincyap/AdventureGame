using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorDemo : MonoBehaviour {

    //This script goes on the TrapDoor prefab;
    [SerializeField] ParticleSystem  explosion = null;
    public Animator TrapDoorAnim; //Animator for the trap door;

    // Use this for initialization
    void Awake()
    {
        //get the Animator component from the trap;
        TrapDoorAnim = GetComponent<Animator>();
        //start opening and closing the trap for demo purposes;
        StartCoroutine(OpenCloseTrap());
        explosion.Play();
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            Awake();
            
        }
    }

    IEnumerator OpenCloseTrap()
    {
        //play open animation;
        TrapDoorAnim.SetTrigger("open");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //play close animation;
        TrapDoorAnim.SetTrigger("close");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);

    }
}