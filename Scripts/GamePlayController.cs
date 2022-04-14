using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class GamePlayController : MonoBehaviour
{
public static int gametotalScore = 0;
public static GamePlayController instance;
public BoxSpawner box_Spawner;
public static GameObject gameUI;
public AudioSource IceCreamStart;
public AudioSource IceCreamSound;
    public AudioSource pauseSound;
    public float gameSpeed =2f;
    public float multiplier = 1f;
    [HideInInspector]
public IceCreamScript currentBox;
public CameraFollow cameraScript;
public static int moveCount = 0;
    public Player player;
    public int layerManager = 1;
    public List<GameObject> iceCreamList = new List<GameObject>();


    void Awake (){
        if (instance == null){
            instance = this;



        }else{

        }
        gametotalScore = 0;
        moveCount = 0;
        gameSpeed = 1f;
        multiplier = 1f;
        SaveSystem.checkIfSystemFile();
        player.LoadPlayer();
        Invoke("PlayIceCreamStartSound", 0.5f);

    }

    public void PlayIceCreamStartSound()
    {

          IceCreamStart.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
       
        box_Spawner.SpawnBox();
        layerManager = layerManager + 1;
    }

    // Update is called once per frame
    void Update()
    {
     
        DetectInput();
    }
    void DetectInput(){
  
        if (dropNow)
        {
            currentBox.DropBox();
            dropNow = false;
        }
    }

    private bool dropNow = false;
    public void DropIcecream()
    {
        dropNow = true;
    }
   public void SpawnNewBox()
   {
             StartCoroutine(waitForSound(IceCreamSound));
            if (cameraMoving)
            {
                Invoke("NewBox", 1.8f);
                cameraMoving = false;
            }
            else
            {
                Invoke("NewBox", 0.01f);

            }

   }

   void NewBox()
   {
        box_Spawner.SpawnBox();
        layerManager = layerManager + 1;

    }


   public bool cameraMoving;

   public void MoveCamera(){

       moveCount ++;
       if (moveCount == 4){
            cameraMoving = true;
            moveCount = 0;
            cameraScript.targetPos.y +=3f;


       }



   }

   bool gameHasEnded = false;

    public GameOverMenu gameOverScript;

   public void RestartGame()
   {
        if (gameHasEnded == false)
        {
            
            gameOverScript.OpenGameOverMenu();
            gameOverScript.hiddenButton.onClick.Invoke();
            gameHasEnded = true;
        }


   }

   public TextMeshProUGUI changingText;

   public void addScore(float multiplier)
   {
        float scoreTest = box_Spawner.iceCreamScore * multiplier;
        gametotalScore += (int)scoreTest;
        changingText.GetComponent<TMPro.TextMeshProUGUI>().text = gametotalScore.ToString();
   }

     public void PlayIcecreamButtonSound()
                   {
                        IceCreamSound.Play();
                   }

        IEnumerator waitForSound(AudioSource sound)
                   {
                       //Wait Until Sound has finished playing
                       while (sound.isPlaying)
                       {
                           yield return null;
                       }

                      //Auidio has finished playing, disable GameObject

                   }
}
