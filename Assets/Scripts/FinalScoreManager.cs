using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreManager : MonoBehaviour
{

    public TMP_Text finalScoretext;

    // Start is called before the first frame update
    void Start()
    {
        finalScoretext.text = "Final Score: " + SavedVariables.score.ToString();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
