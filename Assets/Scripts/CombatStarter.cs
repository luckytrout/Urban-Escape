//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CombatStarter : MonoBehaviour
{
    [SerializeField] Camera battleCamera;
    [SerializeField] Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player"){
            Debug.Log("Player started combat in " + gameObject);
            battleCamera.gameObject.SetActive(true);
            //mainCamera.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("Player exited combat" + gameObject);
        mainCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }
}
