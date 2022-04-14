using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public UnityAdManager adManager;
    public static bool gameIsOver = false;
    public GameObject gameOverMenuUI;
    public GamePlayController Controller;
    public TextMeshProUGUI changingText = null;
    public Player player;
    public TextMeshProUGUI playerScore = null;
    string scoreString = "";
 public AudioSource gameOverSound;
  public AudioSource iceCreamButtonSound;
    bool showAd = false;
    public Button hiddenButton;
    int count =0;
    void Awake()
    {
        Resume();
       
    }
    void Update()
    {
            if (gameIsOver)
            {
                
                GameOver();
            }
            else
            {

            }
    }


       
 

    public void OpenGameOverMenu()
    {
        
        gameIsOver = true;
        adManager.PlayGameOverAD(gameOverSound.Play);  gameOverSound.Play();
        scoreString = playerScore.GetComponent<TMPro.TextMeshProUGUI>().text;
        showAd = true;
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        gameOverMenuUI.SetActive(true);
        updateScore();
        gameIsOver = true;

    }



    public void Resume()
    {
        if (!iceCreamButtonSound.isPlaying)
        {
            gameOverMenuUI.SetActive(false);
            Time.timeScale = 1f;
            gameIsOver = false;
        }
    }

    public void Restart()
       {
        if (!iceCreamButtonSound.isPlaying)
        {
            player.setPlayerScore(int.Parse(scoreString));
            PlayPauseButtonSound();
            StartCoroutine(waitForSound(iceCreamButtonSound, "R"));
        }

       }
    public void RestartNow()
    {
        count = 0;
        Time.timeScale = 1f;
                    SceneManager.LoadScene(2);
                    gameIsOver = false;

    }

    public void Quit()
    {
        if (!iceCreamButtonSound.isPlaying)
        {
            player.setPlayerScore(int.Parse(scoreString));
            PlayPauseButtonSound();
            StartCoroutine(waitForSound(iceCreamButtonSound, "Q"));
            

        }
    }

    public void QuitNow()
       {
        count = 0;
        Time.timeScale = 1f;
            SceneManager.LoadScene(1);
            gameIsOver = false;
       }

   public void updateScore()
   {
        scoreString = playerScore.GetComponent<TMPro.TextMeshProUGUI>().text;
        changingText.GetComponent<TMPro.TextMeshProUGUI>().text ="Score: " + scoreString;
   }

    public void PlayPauseButtonSound()
       {
            iceCreamButtonSound.Play();


       }
    public string statusOption = "";
    IEnumerator waitForSound(AudioSource sound, string option)
        {
      
            //Wait Until Sound has finished playing
            while (sound.isPlaying)
            {
                yield return null;
            }
        
           //Auidio has finished playing, disable GameObject
           if (option == "R")
           {

            RestartNow();
            statusOption = "R";

           }
           else if  (option == "Q")
           {
            QuitNow();
            statusOption ="Q";
           }
        
        }

}
