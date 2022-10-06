using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMove : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent player;
    public Animator playerAnimator;
    public GameObject targetDest;

    // Animation clean
    private bool isAttackPressed;
    private bool isAttacking;


    // Movement
    NavMeshAgent agent;
    string prevAction;

    [SerializeField] private float attackDelay = 0.3f;

    // Animation states
    const string PLAYER_IDLE = "player_idle";
    const string PLAYER_WALK = "player_walk";
    const string PLAYER_ATTACK_1 = "player_attack_1";
    private string currentState;


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
    void Update()
    {


        // Checking for inputs
        print(playerAnimator.GetBool("isWalking"));
        print(playerAnimator.GetBool("isAttacking1"));
        print(playerAnimator.GetBool("isAttacking2"));
        print(playerAnimator.GetBool("isAttacking3"));

        // Attack Key pressed
        if (Input.GetKeyDown(KeyCode.RightControl)) {
            isAttackPressed = true;
        }


        // Jump key pressed
        // if (Input.GetkeyDown(KeyCode.Space)) {
        //     isJumpPressed = true;
        // }


    }


    // ============================
    // Physics based time step loop
    // ============================
    private void FixedUpdate() {

        if (Input.GetKeyDown(KeyCode.A)) {
            prevAction = "Attack";
        } else if (Input.GetMouseButtonDown(0)) {
            print("Mouse clicked!");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            print(ray);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1f)) {
                print("ray went to screen!!");
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
            if (player.velocity != Vector3.zero) {
                print("setting walk");
                playerAnimator.SetBool("isWalking", true);
                // ChangeAnimationState(PLAYER_WALK);
            }
            
            else if (player.velocity == Vector3.zero) {
                print("setting idle");
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

            attackDelay = playerAnimator.GetCurrentAnimatorStateInfo(0).length;
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

}
