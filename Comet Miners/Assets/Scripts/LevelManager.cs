using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject Left_Planet;
    public GameObject Right_Planet;
    public GameObject Current_Planet;
    public GameObject[] Scene;
   

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 10; i++)
            SpawnTile();
    }
	
	// Update is called once per frame
	void Update () {

        Scene = GameObject.FindGameObjectsWithTag("Scene");


        if (Scene.Length < 10)
        {
            SpawnTile();
        }

    }

    public void SpawnTile()
    {

        int randomNum = Random.Range(0, 2);
        

        if (randomNum == 0)
        {
            Current_Planet = (GameObject)Instantiate(Left_Planet, Current_Planet.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity);
            

        }

        else
        {
            Current_Planet = (GameObject)Instantiate(Right_Planet, Current_Planet.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity);
            


        }

        int spawnAlien = Random.Range(0, 3);
        if (spawnAlien == 0)
        {
            Current_Planet.transform.GetChild(1).gameObject.SetActive(true);
        }

    }
    


}
