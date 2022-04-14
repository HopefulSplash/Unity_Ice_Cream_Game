using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public Player player = new Player();
    public List<int> highscores;
    public TextMeshProUGUI diamondText = null;
    public TextMeshProUGUI goldText = null;
    public TextMeshProUGUI silverText = null;
    public TextMeshProUGUI bronzeText = null;


    private void Awake()
    {
        SaveSystem.checkIfSystemFile();

        player.LoadPlayer();
        highscores = player.highscores;
        highscores.Sort();

        // Removing duplicate elements
        List<int> distinct = highscores.Distinct().ToList();
        distinct.Sort();

        string diamond = "Play Again";
        string gold = "Play Again";
        string silver = "Play Again";
        string bronze = "Play Again";

        if (distinct.Count >= 1)
        {
            diamond = distinct[distinct.Count - 1].ToString();
            if (distinct.Count >= 2)
            {
                gold = distinct[distinct.Count - 2].ToString();
                if (distinct.Count >= 3)
                {
                    silver = distinct[distinct.Count - 3].ToString();
                    if (distinct.Count >= 4)
                    {
                        bronze = distinct[distinct.Count - 4].ToString();
                    }
                    else
                    {
                        bronze = "Play Again";
                    }
                }
                else
                {
                    silver = "Play Again";
                }
            }
            else
            {
                gold = "Play Again";
            }
        }
        else
        {
            diamond = "Play Again";
        }

        diamondText.GetComponent<TMPro.TextMeshProUGUI>().text = diamond;
        goldText.GetComponent<TMPro.TextMeshProUGUI>().text = gold;
        silverText.GetComponent<TMPro.TextMeshProUGUI>().text = silver;
        bronzeText.GetComponent<TMPro.TextMeshProUGUI>().text = bronze;
    }
}
