using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    private bool isFinish;
    private bool isDie;
    private bool isRespawning = false;

    private float respawnDelay = 0;
    private float time;

    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask levelFinishMask;
    [SerializeField] private LayerMask dieMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    //REFERENCES
    private CharacterController controller;
    private Animator anim;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] SceneChanger sceneChanger;
    [SerializeField] PlayerStats playerStats;

    private void Start() {
        isRespawning = false;
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        transform.position = spawnPoint.transform.position;
    }

    private void Update() {
        time = time + 1f * Time.deltaTime;
        
        if(!isRespawning){
            Move();
        }

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        isDie = Physics.CheckSphere(transform.position, groundCheckDistance, dieMask);

        if(isDie && !isRespawning){
            isRespawning = true;
            playerStats.substractLife();
            transform.position = spawnPoint.transform.position;
            respawnDelay = time + 0.1f;
            //transform.position.y -= 1;
            //moveDirection =  new Vector3(0, 0, 0);
            isGrounded = true;
        }

        if(time >= respawnDelay){
            time = 0;
            respawnDelay = 0;
            isRespawning = false;
        }

        if (playerStats.playerLives <= 0){
                sceneChanger.LoadGameOver();
        }
    }

    private void Move() {
        isFinish = Physics.CheckSphere(transform.position, groundCheckDistance, levelFinishMask);
        

        if(isFinish){
            sceneChanger.LoadNextLevel();
        }

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        //isGrounded = true;

        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        
        if(isGrounded){
            if(moveDirection != Vector3.zero && !(Input.GetKey(KeyCode.LeftShift))) {
            //Walking
            Walk();

            }else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)){
            //Running
            Run();

            }else if(moveDirection == Vector3.zero){
            //Idle
            Idle();
            }

            //moveDirection *= moveSpeed;

            if(Input.GetKeyDown(KeyCode.Mouse0)){
                StartCoroutine(Interact());
            }

            if(Input.GetKeyDown(KeyCode.Space) && (moveDirection != Vector3.zero)){
                StartCoroutine(Jump());
            }
        }

        moveDirection *= moveSpeed;

        controller.Move(moveDirection* Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle(){
        anim.SetFloat("Speed" , 0, 0.1f, Time.deltaTime);
    }

    private void Walk(){
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run(){
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private IEnumerator Jump(){
        anim.SetLayerWeight(anim.GetLayerIndex("Jump Layer"), 1);
        anim.SetTrigger("Jump");
        //moveSpeed = runSpeed;
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        yield return new WaitForSeconds(0.9f);
    }

    private IEnumerator Interact(){
        anim.SetLayerWeight(anim.GetLayerIndex("Interact Layer"), 1);
        anim.SetTrigger("Interact");

        yield return new WaitForSeconds(0.9f);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Collectable 1"){
            playerStats.addScore(1);
            Destroy(other.transform.gameObject);
        }
    }

}
