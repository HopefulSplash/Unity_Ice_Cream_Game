using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
    public static void SavePlayer (Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.dvo";
        
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void checkIfSystemFile()
    {
        string path = Application.persistentDataPath + "/player.dvo";

        if (File.Exists(path))
        {
        }
        else
        {
            Player newPlayer = new Player();
            newPlayer.scoops = 0;
            newPlayer.highscores = new List<int> {};
            newPlayer.iceCreamCan = 0;
            newPlayer.speed = 40f;
            newPlayer.gravity = 10f;
            SaveSystem.SavePlayer(newPlayer);
        }
    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.dvo";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
