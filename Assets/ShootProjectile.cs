using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject scanZone;
    public Vector3 playerPosition;
    public float projectileTimer = 3f;
    private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPosition != new Vector3(0, 0, 0)){

            time = time + 1f * Time.deltaTime;

            if(time >= projectileTimer){
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                time = 0;
            }
        }
    }
}
