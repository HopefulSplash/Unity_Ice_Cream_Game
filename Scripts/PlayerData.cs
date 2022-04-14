using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
    public int score;
    public int scoops;
    public List<int> highscores;
    public int iceCreamCan;
    public float gravity;
    public float speed;
    public PlayerData (Player player)
    {
        score = 0;
        scoops = player.scoops;
        highscores = player.highscores;
        iceCreamCan = player.iceCreamCan;
        gravity = player.gravity;
        speed = player.speed;

    }
}
