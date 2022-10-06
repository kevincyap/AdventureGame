using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float pushAmount = 10f;
    public float timeToDie = 8f;
    public float damage = 10f;
    public bool counterSpawned = false;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }   

    // Update is called once per frame
    void Update()
    {
        print(rb);
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * pushAmount, ForceMode.Impulse);
            //collision.gameObject.GetComponent<CustomPlayerController>().TakeDamage(damage);
            print("Hit!");
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(timeToDie);
        Destroy(gameObject);
    }
}


