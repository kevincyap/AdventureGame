using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float pushAmount = 10f;
    public float timeToDie = 2f;
    public static int Damage = 5;
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
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthBar.instance.TakeDamage(Damage);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Wall"))
        {
            print("Wall hit!");
            Destroy(gameObject);
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(timeToDie);
        Destroy(gameObject);
    }
}


