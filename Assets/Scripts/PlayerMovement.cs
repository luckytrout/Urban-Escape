using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerCollider;
    float defaultSpeed = 10f;
    float defaultRotateSpeed = 0.05f;
    Vector3 movement;
    [SerializeField] Rigidbody playerRigidbody;

    bool onGround;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * Time.deltaTime * defaultSpeed);
        }

        if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.back * Time.deltaTime * defaultSpeed);
        }

        if (Input.GetKey(KeyCode.A)) { 
            transform.Rotate(0, -(defaultRotateSpeed), 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, defaultRotateSpeed, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space) && gameObject.GetComponentInChildren<PlayerCollisionDetector>().onGround)
        {
            playerRigidbody.AddForce(transform.up*10f,ForceMode.Impulse);
        }
    }


}
