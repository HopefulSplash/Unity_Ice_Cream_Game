using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    public GameObject[] music;
    public AudioSource buttonSound;
    



    void Awake()
    {
      
        music = GameObject.FindGameObjectsWithTag ("gameMusic");
                    m_MyAudioSource = music[0].GetComponent<AudioSource>();
                    m_MyAudioSource.volume = 0.3f;
        SaveSystem.checkIfSystemFile();


    }

    public void GoToGame()
    {
         music = GameObject.FindGameObjectsWithTag ("gameMusic");
                    m_MyAudioSource = music[0].GetComponent<AudioSource>();
                    m_MyAudioSource.volume = 0.07f;
                   SceneManager.LoadScene(2);
    }

    public void PlayGame()
    {
        if (!buttonSound.isPlaying)
        {
            buttonSound.Play();
            Invoke("GoToGame", 0.53f);
        }
    }
    public void GoToQuit()
    {

    }

    public void GoToScore()
    {
     SceneManager.LoadScene(3);
    }

    public void GoToShop()
    {
    SceneManager.LoadScene(4);
    }

    public void GoToBack()
    {
        SceneManager.LoadScene(1);
    }
     public void Quit()
        {
        if (!buttonSound.isPlaying)
        {
            buttonSound.Play();
            Invoke("GoToQuit", 0.53f);
        }
        }
         public void Score()
            {
        if (!buttonSound.isPlaying)
        {
            buttonSound.Play();
            Invoke("GoToScore", 0.53f);
        }
            }
             public void Shop()
                {
        if (!buttonSound.isPlaying)
        {
            buttonSound.Play();
            Invoke("GoToShop", 0.53f);
        }
                }

                 public void Back()
                      {

        if (!buttonSound.isPlaying)
        {
            buttonSound.Play();
            Invoke("GoToBack", 0.53f);
        }
                      }
}
