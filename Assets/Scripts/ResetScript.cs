using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResetScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SavedVariables.score = 0;
        SavedVariables.lives = 3;
    }

}
