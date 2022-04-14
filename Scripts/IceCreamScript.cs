using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IceCreamScript : MonoBehaviour
{

private float min_X = -2.48f, max_X = 2.48f;
private bool canMove;
private float move_Speed = 2f;
private Rigidbody2D myBody;
private bool gameOver;
private bool ignoreCollision;
private bool ignoreTrigger;
    private float max_Speed;
    private float multiplier = 1f;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0;

    }

    void Start()
    {


        GamePlayController.instance.currentBox = this;
        move_Speed = GamePlayController.instance.gameSpeed;
        max_Speed = GamePlayController.instance.player.speed;
    

        if (move_Speed <= max_Speed) 
        { 
            move_Speed = move_Speed * 1.25f;
            multiplier = GamePlayController.instance.multiplier + 0.2f;
            GamePlayController.instance.multiplier = multiplier;
            GamePlayController.instance.gameSpeed = move_Speed;
         }
  
        
        canMove =true;

        if (Random.Range(0, 2) > 0){
            move_Speed *= -1f;
        }


       
    }

    void Update()
    {
        
        MoveBox();
    }
    bool hitMax = true;
    bool hitMin = true;
    void MoveBox(){

        if (canMove)
        {
            Vector3 temp = transform.position;
            if (temp.x >= max_X && hitMin == true)
            {

                hitMax = true;
                hitMin = false;
                move_Speed *= -1f;
            }
            else if (temp.x <= min_X && hitMax == true)
            {
    
                hitMin = true;
                hitMax = false;
                move_Speed *= -1f;
            }

            temp.x += move_Speed * Time.deltaTime;
            transform.position = temp;
        }
    }
    public int layerManager = 0;

    public void DropBox(){
        canMove = false;

        myBody.gravityScale = GamePlayController.instance.player.gravity;
      
    }

    void Landed (){

        if (gameOver)
            return;



       

        GamePlayController.instance.PlayIcecreamButtonSound();
        GamePlayController.instance.addScore(multiplier);
        ignoreCollision = true;
        ignoreTrigger = true;

        if (GamePlayController.moveCount == 1)
        {
           // myBody.isKinematic = false;
        }
        else
        {
          //  myBody.isKinematic = true;
        }

        GamePlayController.instance.MoveCamera();
        GamePlayController.instance.SpawnNewBox();
        this.gameObject.tag = "IC";

        GamePlayController.instance.iceCreamList.Add(this.gameObject);

        if (GamePlayController.instance.iceCreamList.Count >= 2)
        {
            GamePlayController.instance.iceCreamList[GamePlayController.instance.iceCreamList.Count - 2].gameObject.tag = "Below";
        }

    }

    void RestartGame(){
        GamePlayController.instance.RestartGame();
    }


    void OnCollisionEnter2D (Collision2D target)
    {

                        if (ignoreCollision){
                            return;
                        }
                        if (target.gameObject.tag == "Cone")
                        {

                            Invoke("Landed", 0.1f);
                            ignoreCollision = true;
                        }
                        else if (target.gameObject.tag == "IC")
                        {

                            Invoke("Landed", 0.1f);
                            ignoreCollision = true;
                        }
        else if (target.gameObject.tag == "Below")
        {

            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;
            Invoke("RestartGame", 0.2f);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Cone")
        {
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;
            Invoke("RestartGame", 0.2f);
        }
        else if (other.gameObject.tag == "IC")
        {
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;
            Invoke("RestartGame", 0.2f);
            

        }
        else if (other.gameObject.tag == "Below")
        {
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;
            Invoke("RestartGame", 0.2f);

        }
    }
    void OnTriggerEnter2D (Collider2D target){

            if (ignoreTrigger){
                return;
            }
                      if (target.tag == "GameOver")
                      {

                          CancelInvoke("Landed");
                          gameOver = true;
                          ignoreTrigger = true;
                          Invoke ("RestartGame", 0.2f);
                      }

    }
}
