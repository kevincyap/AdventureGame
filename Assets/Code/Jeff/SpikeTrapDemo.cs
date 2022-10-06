using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDemo : MonoBehaviour {

    public static int Damage = 5;

    //This script goes on the SpikeTrap prefab;

    public Animator spikeTrapAnim; //Animator for the SpikeTrap;

    private bool active = true;

    // Use this for initialization
    void Start()
    {
        //get the Animator component from the trap;
        spikeTrapAnim = GetComponent<Animator>();
        //start opening and closing the trap for demo purposes;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && active)
        {
            active = false;
            StartCoroutine(OpenCloseTrap());
        }
    }

    IEnumerator OpenCloseTrap()
    {
        HealthBar.instance.TakeDamage(Damage);
        //play open animation;
        spikeTrapAnim.SetTrigger("open");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //play close animation;
        spikeTrapAnim.SetTrigger("close");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        active = true;
        //Do it again;
    }
}