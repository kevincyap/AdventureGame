using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMove : MonoBehaviour
{
    public Camera cam;
    public Animator playerAnimator;
    public GameObject targetDest;

    // Animation clean
    public bool isAttackPressed;
    private bool isAttacking;


    // Movement
    NavMeshAgent agent;
    string prevAction;


    // Animation states
    const string PLAYER_IDLE = "player_idle";
    const string PLAYER_WALK = "player_walk";
    const string PLAYER_ATTACK_1 = "player_attack_1";
    private string currentState;
    public float attackDelay = 1f;

    // ============================
    // Start called before first frame
    // ============================
    private void Start() {
        print("character loaded");
        agent = GetComponent<NavMeshAgent>();
    }
    

    // ============================
    // Update called once per frame
    // ============================
    // void Update()
    // {


    //     // Checking for inputs
    //     print(playerAnimator.GetBool("isWalking"));
    //     print(playerAnimator.GetBool("isAttacking1"));
    //     print(playerAnimator.GetBool("isAttacking2"));
    //     print(playerAnimator.GetBool("isAttacking3"));

    //     // Attack Key pressed
        

    //     // Jump key pressed
    //     // if (Input.GetkeyDown(KeyCode.Space)) {
    //     //     isJumpPressed = true;
    //     // }


    // }


    // ============================
    // Physics based time step loop
    // ============================
    private void Update() {
        if (PublicVars.paused) {
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightControl)) {
            isAttackPressed = true;
        }

        if (Input.GetMouseButtonDown(0) && !DialogController.instance.InEncounter) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                print(hit.point);
                agent.isStopped = false;
                agent.SetDestination(hit.point);
            }
        }
        

        // Player movement
        // if (Input.GetMouseButtonDown(0)) {
        //     print("mouse click detected!");
        //     Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hitPoint;
        //     if (Physics.Raycast(ray, out hitPoint)) {
        //         print("ray goingg");
        //         targetDest.transform.position = hitPoint.point;
        //         player.SetDestination(hitPoint.point);
        //     }
        // }

        // Player movement animations
        if (!isAttacking) {
            if (agent.velocity != Vector3.zero) {
                playerAnimator.SetBool("isWalking", true);
                // ChangeAnimationState(PLAYER_WALK);
            }
            
            else if (agent.velocity == Vector3.zero) {
                playerAnimator.SetBool("isWalking", false);
                // ChangeAnimationState(PLAYER_IDLE);
            }
        }

        



        // ============================
        // Jumping 
        // if (isJumpPressed && isGrounded) {

        // }
        // ============================


        // ============================
        // Attacking
        if (isAttackPressed) {
            isAttackPressed = false;

            if (!isAttacking) {
                isAttacking = true;
                int rand = Random.Range(1, 4);
                string attackStr = "isAttacking" + rand;
                playerAnimator.SetBool(attackStr, true);
                // ChangeAnimationState(PLAYER_ATTACK_1);
            }

            Invoke("AttackComplete", attackDelay);
        }

        // ============================
    }


    void AttackComplete() {
        isAttacking = false;
        playerAnimator.SetBool("isAttacking1", false);
        playerAnimator.SetBool("isAttacking2", false);
        playerAnimator.SetBool("isAttacking3", false);
    }


    void ChangeAnimationState(string newState) {
        // Stop same animation from interrupting itself
        if (currentState == newState) return;

        playerAnimator.Play(newState);

        currentState = newState;
    }

    
    public void StopPlayer() {
        agent.SetDestination(transform.position);
    }

}
