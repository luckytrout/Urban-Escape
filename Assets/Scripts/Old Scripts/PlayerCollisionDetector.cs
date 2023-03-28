using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    public bool onGround = true;

    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Ground"){
            onGround = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        onGround = false;
    }
}
