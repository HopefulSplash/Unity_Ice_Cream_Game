using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int scoreAdd;
    public int scoops;
    public List<int> highscores;
    public int iceCreamCan;
    public float gravity;
    public float speed;


    public void setPlayerScore(int playerScore)
    {
        LoadPlayer();
        int numberOfScoops = playerScore / 50;
        scoops = scoops + numberOfScoops;
        scoreAdd = playerScore;

        SavePlayer();
    }
   public void SavePlayer()
    {
        
        highscores.Add(scoreAdd);
        SaveSystem.SavePlayer(this);
      
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        scoops = data.scoops;
        highscores = data.highscores;
        iceCreamCan = data.iceCreamCan;
        gravity = data.gravity;
        speed = data.speed;
    }


}
