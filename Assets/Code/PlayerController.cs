using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    NavMeshAgent agent;
    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (PublicVars.paused) {
            return;
        }

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                agent.isStopped = false;
                agent.SetDestination(hit.point);
            }
        }
    }
    public void StopPlayer() {
        agent.SetDestination(transform.position);
    }
}
