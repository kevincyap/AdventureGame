using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseFire : MonoBehaviour
{
    public static int Damage = 5;
    public bool active = true;
    public AudioClip laser_sound;
    public AudioSource laser_audio;
    public GameObject projectile;
    public GameObject target;
    public LayerMask player;
    public float sphere = 20f;
    float timeLeft = 0f;
    public float shootCD = 4f; 
    // Start is called before the first frame update

    //This script goes on the TrapDoor prefab;
    [SerializeField] ParticleSystem  explosion = null;
    public Animator TrapDoorAnim; //Animator for the trap door;

    void Awake()
    {
        //get the Animator component from the trap;
        TrapDoorAnim = GetComponent<Animator>();
        //start opening and closing the trap for demo purposes;
        StartCoroutine(OpenCloseTrap());
        explosion.Play();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeLeft > 0)
        {
            print(timeLeft);
            timeLeft -= Time.deltaTime;
        }
        if(timeLeft <= 0)
        {
            Awake();
            SpawnProjectile();
            timeLeft += shootCD;
        }
        Collider[] colliders = Physics.OverlapSphere(transform.position, sphere, player);
        if (colliders.Length > 0) {
            target = Camera.main.gameObject;
        }
    }

    public void SpawnProjectile()
    {
        GameObject b = Instantiate(projectile, transform.position, transform.rotation);
        GetComponent<AudioSource>().PlayOneShot(laser_sound);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = null;
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
