using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public Player player = new Player();
    int scoops;
    public TextMeshProUGUI scoopsText = null;
    public TextMeshProUGUI speedText = null;
    public TextMeshProUGUI gravityText = null;
    public GameObject[] iceCreams;
    public Sprite[] yesIceCreams;
    public AudioSource buttonSound;
    public GameObject button;
    public GameObject buttonGravity;
    public GameObject buttonSpeed;
    public UnityAdManager adManager;
    public AudioSource gameover;
    public float gravity;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

        SaveSystem.checkIfSystemFile();
        player.LoadPlayer();
        scoops = player.scoops;
        scoopsText.GetComponent<TMPro.TextMeshProUGUI>().text = scoops.ToString();
        UpdateSpeed();
        UpdateGravity();
        UpdateIceCream();
        if (player.iceCreamCan == 11)
        {
            button.SetActive(false);
        }

    }
    public void buyGravity()
    {
        if (player.scoops >= 60 && player.gravity > 1)
        {
            if (player.gravity - player.gravity * 10 / 100 < 1)
            {
                player.gravity = 1;
            }
            else
            {
                player.gravity = player.gravity - player.gravity * 10 / 100;

            }
            player.scoops = player.scoops - 60;
            SaveSystem.SavePlayer(player);

            if (!buttonSound.isPlaying)
            {
                buttonSound.Play();
                StartCoroutine(waitForSound(buttonSound, "Gravity"));
            }
        }
        else if (player.scoops <= 60)
        {
            if (!gameover.isPlaying)
            {
                gameover.Play();
                StartCoroutine(waitForSound(gameover, "NO"));

            }
        }

    }

    public void buySpeed()
    {
        if (player.scoops >= 100 && player.speed > 1)
        {
            if (player.speed - player.speed * 10 / 100 < 1)
            {
                player.speed = 1;
            }
            else
            {
                player.speed = player.speed - player.speed * 10 / 100;

            }
            player.scoops = player.scoops - 100;
            SaveSystem.SavePlayer(player);

            if (!buttonSound.isPlaying)
            {
                buttonSound.Play();
                StartCoroutine(waitForSound(buttonSound, "Speed"));
            }
        }
        else if (player.scoops <= 100)
        {
            if (!gameover.isPlaying)
            {
                gameover.Play();
                StartCoroutine(waitForSound(gameover, "NO"));

            }
        }


    }

    public void refreshStat()
    {
        scoops = player.scoops;
        speed = player.speed;
        gravity = player.gravity;
        player.SavePlayer();
        SceneManager.LoadScene(4);
    }

    bool isPressed = false;
    public void PlayAD()
    {
       
        if (!isPressed)
        {
            if (!buttonSound.isPlaying)
            {
                isPressed = true;
                buttonSound.Play();
                StartCoroutine(waitForSound(buttonSound, "AD"));
            }
            
        }
        else
        {
            gameover.Play();
            StartCoroutine(waitForSound(gameover, "NO"));
        }


    }

    public void Unlock()
    {
        //add and take away
        if (player.scoops >= 30 && player.iceCreamCan <= 11)
        {
                       
            if (!buttonSound.isPlaying)
            {

                buttonSound.Play();
                player.scoops = player.scoops - 30;
                player.iceCreamCan = player.iceCreamCan + 1;
                SaveSystem.SavePlayer(player);
                StartCoroutine(waitForSound(buttonSound, "YES"));

            }
        }
        else if (player.iceCreamCan == 12)
        {
                button.SetActive(false);  
        }
        else if (player.scoops <= 30)
        {
            if (!gameover.isPlaying)
            {
                gameover.Play();
                StartCoroutine(waitForSound(gameover, "NO"));
                
            }
        }

    }

    public void addReward()
    {
        int rewardAmount = 25;
        isPressed = false;
        player.scoops = player.scoops + rewardAmount;
        refreshStat();
    }
    public void UpdateSpeed()
    {
        if (player.speed <= 1)
        {
            //do nothing
            buttonSpeed.SetActive(false);
        }
        speed = player.speed;
        speedText.GetComponent<TMPro.TextMeshProUGUI>().text = speed.ToString("0.0");
    }

    public void UpdateGravity()
    {
        if (player.gravity <= 1)
        {
            //do nothing
            buttonGravity.SetActive(false);
        }
        gravity = player.gravity;
        gravityText.GetComponent<TMPro.TextMeshProUGUI>().text = gravity.ToString("0.0");

    }
    public void UpdateIceCream ()
    {
        if (player.iceCreamCan >= 11)
        {
            button.SetActive(false);
        }

        if (player.iceCreamCan >= 0)
        {
            iceCreams[0].GetComponent<Image>().sprite = yesIceCreams[0];
            if (player.iceCreamCan >= 1)
            {
                iceCreams[1].GetComponent<Image>().sprite = yesIceCreams[1];
                if (player.iceCreamCan >= 2)
                {
                    iceCreams[2].GetComponent<Image>().sprite = yesIceCreams[2];
                    if (player.iceCreamCan >= 3)
                    {
                        iceCreams[3].GetComponent<Image>().sprite = yesIceCreams[3];
                        if (player.iceCreamCan >= 4)
                        {
                            iceCreams[4].GetComponent<Image>().sprite = yesIceCreams[4];
                            if (player.iceCreamCan >= 5)
                            {
                                iceCreams[5].GetComponent<Image>().sprite = yesIceCreams[5];
                                if (player.iceCreamCan >= 6)
                                {
                                    iceCreams[6].GetComponent<Image>().sprite = yesIceCreams[6];
                                    if (player.iceCreamCan >= 7)
                                    {
                                        iceCreams[7].GetComponent<Image>().sprite = yesIceCreams[7];
                                        if (player.iceCreamCan >= 8)
                                        {
                                            iceCreams[8].GetComponent<Image>().sprite = yesIceCreams[8];
                                            if (player.iceCreamCan >= 9)
                                            {
                                                iceCreams[9].GetComponent<Image>().sprite = yesIceCreams[9];
                                                if (player.iceCreamCan >= 10)
                                                {
                                                    iceCreams[10].GetComponent<Image>().sprite = yesIceCreams[10];
                                                    if (player.iceCreamCan >= 11)
                                                    {
                                                        iceCreams[11].GetComponent<Image>().sprite = yesIceCreams[11];

                                                    }
                                                   
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public bool notFinished = false;
    IEnumerator waitForSound(AudioSource sound, string option)
    {

        //Wait Until Sound has finished playing
        while (sound.isPlaying)
        {
            yield return null;
        }

        if (option == "YES")
        {
            refreshStat();
        }
        else if (option == "Gravity")
        {
            refreshStat();
        }
        else if (option == "Speed")
        {
            refreshStat();
        }
        else if (option == "AD")
        {
            adManager.PlayRewardedAD(addReward);
            
        }
        


    }
}
