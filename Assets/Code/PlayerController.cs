using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    NavMeshAgent agent;
    string prevAction;
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
        if (Input.GetKeyDown(KeyCode.A)) {
            prevAction = "Attack";
        } else if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.gameObject.CompareTag("Enemy") && prevAction == "Attack") {
                    print("attack");
                    Destroy(hit.transform.gameObject);
                    agent.isStopped = true;
                } else {
                    agent.isStopped = false;
                    agent.SetDestination(hit.point);
                }
                prevAction = "";
            }
        }
    }
}
