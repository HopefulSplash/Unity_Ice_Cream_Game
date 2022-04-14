using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner: MonoBehaviour
{
	public GameObject box_Prefab0;
	public GameObject box_Prefab1;
	public GameObject box_Prefab2;
	public GameObject box_Prefab3;
	public GameObject box_Prefab4;
	public GameObject box_Prefab5;
	public GameObject box_Prefab6;
	public GameObject box_Prefab7;
	public GameObject box_Prefab8;
	public GameObject box_Prefab9;
	public GameObject box_Prefab10;
	public GameObject box_Prefab11;
    public Player player;
	public int iceCreamScore;

   public void SpawnBox()
   {
        this.gameObject.tag = "IC";
        layerManager = GamePlayController.instance.layerManager;


        player.LoadPlayer();
        int maxIceCream = player.iceCreamCan;

        if (player.iceCreamCan == 0)
        {
            maxIceCream = 1;
        }
        else if (player.iceCreamCan == 1)
        {
            maxIceCream = 2;
        }
        else if (player.iceCreamCan == 2)
        {
            maxIceCream = 3;
        }
        else if (player.iceCreamCan == 3)
        {
            maxIceCream = 4;
        }
        else if (player.iceCreamCan == 4)
        {
            maxIceCream = 5;
        }
        else if (player.iceCreamCan == 5)
        {
            maxIceCream = 6;
        }
        else if (player.iceCreamCan == 6)
        {
            maxIceCream = 7;
        }
        else if (player.iceCreamCan == 7)
        {
            maxIceCream = 8;
        }
        else if (player.iceCreamCan == 8)
        {
            maxIceCream = 9;
        }
        else if(player.iceCreamCan == 9)
        {
            maxIceCream = 10;
        }
        else if (player.iceCreamCan >= 10)
        {
            maxIceCream = 11;
        }

        int iceCreamType = Random.Range(0, maxIceCream);

        if (iceCreamType == 1)
        {
            iceCreamScore = 20;
            GameObject box_Obj = Instantiate(box_Prefab1);

            Vector3 temp = transform.position;
            temp.z = 10f;
            box_Obj.transform.position = temp;
            box_Obj.GetComponent<SpriteRenderer>().sortingOrder = layerManager ;

        }
        else if (iceCreamType == 2)
        {
            iceCreamScore = 30;
            GameObject box_Obj = Instantiate(box_Prefab2);
            Vector3 temp = transform.position;
            temp.z = 10f;
            box_Obj.transform.position = temp;
            box_Obj.GetComponent<SpriteRenderer>().sortingOrder = layerManager ;

        }
        else if (iceCreamType == 3)
        {
            iceCreamScore = 50;
            GameObject box_Obj = Instantiate(box_Prefab3);
            Vector3 temp = transform.position;
            temp.z = 10f;
            box_Obj.transform.position = temp; box_Obj.GetComponent<SpriteRenderer>().sortingOrder = layerManager ;

        }
        else if (iceCreamType == 4)
        {
            iceCreamScore = 70;
            GameObject box_Obj = Instantiate(box_Prefab4);
            Vector3 temp = transform.position;
            temp.z = 10f;
            box_Obj.transform.position = temp; box_Obj.GetComponent<SpriteRenderer>().sortingOrder = layerManager ;

        }
        else if (iceCreamType == 5)
        {
            iceCreamScore = 90;
            GameObject box_Obj = Instantiate(box_Prefab5);
            Vector3 temp = transform.position;
            temp.z = 10f;
            box_Obj.transform.position = temp; box_Obj.GetComponent<SpriteRenderer>().sortingOrder = layerManager ;

        }
        else if (iceCreamType == 6)
        {
            iceCreamScore = 110;
            GameObject box_Obj = Instantiate(box_Prefab6);
            Vector3 temp = transform.position;
            temp.z = 10f;
            box_Obj.transform.position = temp; box_Obj.GetComponent<SpriteRenderer>().sortingOrder = layerManager ;
 
        }
        else if (iceCreamType == 7)
        {
            iceCreamScore = 130;
            GameObject box_Obj = Instantiate(box_Prefab7);
            Vector3 temp = transform.position;
            temp.z = 10f;
            box_Obj.transform.position = temp; box_Obj.GetComponent<SpriteRenderer>().sortingOrder = layerManager ;
   
        }
        else if (iceCreamType == 8)
        {
            iceCreamScore = 200;
            GameObject box_Obj = Instantiate(box_Prefab8);
            Vector3 temp = transform.position;
            temp.z = 10f;
            box_Obj.transform.position = temp; box_Obj.GetComponent<SpriteRenderer>().sortingOrder = layerManager ;

        }
        else if (iceCreamType == 9)
        {
            iceCreamScore = 350;
            GameObject box_Obj = Instantiate(box_Prefab9);
            Vector3 temp = transform.position;
            temp.z = 10f;
            box_Obj.transform.position = temp; box_Obj.GetComponent<SpriteRenderer>().sortingOrder = layerManager ;

        }
        else if (iceCreamType == 10)
        {
            iceCreamScore = 400;
            GameObject box_Obj = Instantiate(box_Prefab10);
            Vector3 temp = transform.position;
            temp.z = 10f;
            box_Obj.transform.position = temp; box_Obj.GetComponent<SpriteRenderer>().sortingOrder = layerManager ;
  
        }
        else if (iceCreamType == 11)
        {
            iceCreamScore = 600;
            GameObject box_Obj = Instantiate(box_Prefab11);
            Vector3 temp = transform.position;
            temp.z = 10f;
            box_Obj.transform.position = temp; box_Obj.GetComponent<SpriteRenderer>().sortingOrder = layerManager;
 
        }
        else if (iceCreamType == 0)
        {
            iceCreamScore = 10;
            GameObject box_Obj = Instantiate(box_Prefab0);
            Vector3 temp = transform.position;
            temp.z = 10f;
            box_Obj.transform.position = temp;
            box_Obj.GetComponent<SpriteRenderer>().sortingOrder = layerManager;
    
        }
        }


    public int layerManager;


}
