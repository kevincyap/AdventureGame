using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public Transform target;

    public Camera cam;

    public static float speed = 20f;
    public static float rotSpeed = 100f;

    private bool active = false;

    void Start() {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        target = transform.Find("Target");
    }

    void Update() {
        if (active) {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, target.position, speed * Time.deltaTime);
            cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, target.rotation, rotSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            print("Active");
            active = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            print("Deactivate");
            active = false;
        }
    }
}
