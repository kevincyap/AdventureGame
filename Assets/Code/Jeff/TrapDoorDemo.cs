using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorDemo : MonoBehaviour {

    public int Damage = 5;

    //This script goes on the TrapDoor prefab;
    [SerializeField] ParticleSystem  explosion = null;
    public Animator TrapDoorAnim; //Animator for the trap door;
    public bool active = true;
    // Use this for initialization
    void Start()
    {
        //get the Animator component from the trap;
        TrapDoorAnim = GetComponent<Animator>();
        //start opening and closing the trap for demo purposes;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && active)
        {
            explosion.gameObject.SetActive(true);
            HealthBar.instance.TakeDamage(Damage);
            active = false;
            StartCoroutine(OpenCloseTrap());
            explosion.Play();
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