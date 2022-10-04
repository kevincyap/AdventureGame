using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int agroDistance = 10;
    public int health = 10;
    public int maxHealth = 10;
    GameObject spotLight;
    private GameObject playerObj;
    private Vector3 origPos;
    public string enemyName;

    public void TakeDamage(int damage) {
        health -= damage;
    }
    void CheckHealth() {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        spotLight = transform.Find("SpotLight").gameObject;
        origPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        if (!DialogController.instance.InEncounter) {
            if (Vector3.Distance(playerObj.transform.position, transform.position) < 5) {
                spotLight.SetActive(false);
                DialogController.instance.StartEncounter(this);
            }
        }
    }
}
