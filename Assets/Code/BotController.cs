using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }
    void FixedUpdate()
    {
        StartCoroutine(FollowPlayer());
    }
    IEnumerator FollowPlayer() {
        yield return new WaitForSeconds(0.5f);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player) {
            agent.SetDestination(player.transform.position);
        }
    }
}
