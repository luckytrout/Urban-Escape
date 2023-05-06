using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject selectLevelCanvas;
    public GameObject creditsCanvas;

    private void Start() {
        selectLevelCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
    }

    public void toggleCanvas(GameObject canvasObj){
        canvasObj.SetActive(!canvasObj.activeInHierarchy);
    }
}
