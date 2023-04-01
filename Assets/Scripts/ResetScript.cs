using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SavedVariables.score = 0;
        SavedVariables.lives = 3;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
