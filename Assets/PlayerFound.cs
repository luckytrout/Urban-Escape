using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFound : MonoBehaviour
{
    public GameObject wallGun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        if(other.transform.tag == "Player"){
            wallGun.GetComponent<ShootProjectile>().playerPosition = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.transform.tag == "Player"){
            wallGun.GetComponent<ShootProjectile>().playerPosition = new Vector3(0, 0, 0);
        }
    }
}
