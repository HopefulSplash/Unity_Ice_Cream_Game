using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PuaseMenu : MonoBehaviour
{
    public bool UIbuttonPressed = false;
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GamePlayController Controller;
    public TextMeshProUGUI changingText = null;
    public TextMeshProUGUI playerScore = null;
    public AudioSource pauseButtonSound;
      public AudioSource iceCreamButtonSound;
    public Player player;
    public UnityAdManager adManager;

    string scoreString = "";
    void Awake()
    {

        if (UIbuttonPressed == true)
        {
           
        }
        else
        {
          pauseMenuUI.SetActive(false);
        }


    }
    void Update()
    {
        if (UIbuttonPressed)
        {
            if (gameIsPaused)
            {
                //Nothing
            }
            else
            {

                 Pause();
            }
        }
        else
        {

        }
    }
    public void PlayPauseButtonSound()
    {
         pauseButtonSound.Play();
    }

    public void OpenPauseMenu()
    {
        UIbuttonPressed = true;
    }

    public void ResumeNow()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        UIbuttonPressed = false;

    }

    void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
               updateScore();
        gameIsPaused = true;
        UIbuttonPressed = false;
    }

    public void RestartNow()
    {

        Time.timeScale = 1f;
         SceneManager.LoadScene(2);
         gameIsPaused = false;
          UIbuttonPressed = false;


    }

    public void QuitNow()
    {

        Time.timeScale = 1f;
         SceneManager.LoadScene(1);
         gameIsPaused = false;
          UIbuttonPressed = false;
    }

    public void Quit()
    {
        if (!iceCreamButtonSound.isPlaying)
        {
            
            player.setPlayerScore(int.Parse(scoreString));
            PlayIcecreamButtonSound();
            StartCoroutine(waitForSound(iceCreamButtonSound, "Q"));
        }
    }

    public void Resume()
    {
         if (!iceCreamButtonSound.isPlaying)
        {

            PlayIcecreamButtonSound();
            StartCoroutine(waitForSound(iceCreamButtonSound, "C"));

        }
    }

  

    public void Restart()
    {
        
        if (!iceCreamButtonSound.isPlaying)
        {
            
           
          
            player.setPlayerScore(int.Parse(scoreString));
            PlayIcecreamButtonSound();
            
            StartCoroutine(waitForSound(iceCreamButtonSound, "R"));
            
        }
    }
    public void PlayIcecreamButtonSound()
           {
                iceCreamButtonSound.Play();
           }

   public void updateScore()
   {
        scoreString = playerScore.GetComponent<TMPro.TextMeshProUGUI>().text;
        changingText.GetComponent<TMPro.TextMeshProUGUI>().text ="Score: " + scoreString;
   }
    public string option;
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
            adManager.adSource = "Pause";
            adManager.PlayPauseAD(RestartNow);

            while (adManager.stop == false)
            {
                yield return new WaitForSeconds(0.5f);
            }
            }
            if (option == "Q")
            {
                QuitNow();
            }

            if (option == "C")
            {
                ResumeNow();

            }

        
    }
}
