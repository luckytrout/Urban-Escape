using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileVelocity : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed = 25f;
    private GameObject target;

    // beingDestroyed makes sure that after the projectile has hit the ground, it does not count against the player
    private bool beingDestroyed = false;


    // Start is called before the first frame update
    void Start()
    {
        // Find our player (the target)
        target = GameObject.FindGameObjectWithTag("Player");

        // Randomize how high the shot will be
        float offsetY= Random.Range(1.5f, 3f);

        // Define where this projectile needs to go based on player's position + offset (to aim higher)
        direction = (new Vector3(target.transform.position.x, target.transform.position.y + offsetY, target.transform.position.z) - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {    
        // Stop projectile tracking if beingDestroyed
        if (!beingDestroyed){
            // Transform the position of the projectile based on the speed set and direction
            Vector3 distance = direction * speed * Time.deltaTime;
            gameObject.transform.Translate(distance);
        }
    }

    private void OnCollisionEnter(Collision other) {

        // If the projectile hits the ground or the bottom of the level
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground") || other.gameObject.layer == LayerMask.NameToLayer("Die")){
          // Begin process of destroying the projectile
          StartCoroutine(DestroyProjectile());
        }

        if(other.gameObject.tag  == "Player" && beingDestroyed == false){
            // if instead the player was hit, they lose a life
            // Begin process of destroying the projectile
            StartCoroutine(DestroyProjectile());

            other.gameObject.GetComponent<PlayerMovement1>().KillPlayer();
            Debug.Log("isDie");
        }
    }

    private IEnumerator DestroyProjectile(){
        beingDestroyed = true;
        yield return new WaitForSeconds(2f);
        // Destroy itself
        Destroy(gameObject);
    }
}
