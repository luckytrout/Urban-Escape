using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject scanZone;
    public Vector3 playerPosition;

    [SerializeField] private Vector3 projectileOriginOffset;

    public float projectileTimer = 3f;
    private float time;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(playerPosition != new Vector3(0, 0, 0)){

            // Count the time that has passed since player position was (0,0,0)
            time = time + 1f * Time.deltaTime;

            // When time reaches a certain number of seconds (projectileTimer), create projectile prefab
            if(time >= projectileTimer){
                
                // Instantiate projectile at position of wall gun + Vector3 offsets and with zero rotation.
                Instantiate(projectilePrefab, new Vector3(transform.position.x + projectileOriginOffset.x,
                transform.position.y + projectileOriginOffset.y,
                transform.position.z + projectileOriginOffset.z),
                Quaternion.identity);
                
                // Reset timer
                time = 0;
            }
        }
    }
}
