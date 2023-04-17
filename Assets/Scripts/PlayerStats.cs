using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    // local player stats in StatManager need to be public for access
    public int playerScore;
    public int playerLives;

    public TMP_Text  scoreText;
    public TMP_Text  livesText;

    // Start is called before the first frame update
    void Start()
    {
        // call to public method with static variables
        // sets local stats in current level with saved variables from runtime
        playerScore = SavedVariables.score;
        playerLives = SavedVariables.lives;

        getLives();
        getScore();
    }

    public void addScore(int points){
        SavedVariables.score += points;
        getScore();
    }

    public void getScore(){
        scoreText.text = "Score: " + (SavedVariables.score).ToString();
    }

    public void substractLife(){
        if(playerLives != 0){
            playerLives -= 1;
            SavedVariables.lives = playerLives;
            getLives();

            SavedVariables.score -= 5;
            getScore();
        }
        Debug.Log(SavedVariables.lives);
    }

    public void getLives(){
       livesText.text = "Lives: " + (SavedVariables.lives).ToString();
    }
}
