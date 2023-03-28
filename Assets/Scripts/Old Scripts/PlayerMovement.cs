using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float defaultSpeed = 10f;
    [SerializeField] float defaultRotateSpeed = 0.5f;
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
            transform.Rotate(0, -(defaultRotateSpeed) * Time.deltaTime, 0);
            //transform.Translate(Vector3.left * Time.deltaTime * defaultSpeed);
            //transform.rotation = Quaternion.Euler(new Vector3(0, -defaultRotateSpeed * Time.deltaTime,0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, defaultRotateSpeed * Time.deltaTime, 0);
            //transform.Translate(Vector3.right * Time.deltaTime * defaultSpeed);
            //var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRot);
            //transform.rotation = Quaternion.Euler(new Vector3(0, defaultRotateSpeed * Time.deltaTime,0));
        }
        

        if(Input.GetKeyDown(KeyCode.Space) && gameObject.GetComponentInChildren<PlayerCollisionDetector>().onGround)
        {
            playerRigidbody.AddForce(transform.up*10f,ForceMode.Impulse);
        }
    }


}
