using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlanets : MonoBehaviour {

    
        

	// Use this for initialization
	void Start () {
        //GameObject LevelManager = GameObject.Find("LevelManager");

    }
	
	// Update is called once per frame
	void Update () {
        //LevelManager levelManager = GetComponent<LevelManager>();

        //if(isDel == true)
        //{
        // levelManager.numOfPlanets -= 1;
        //}
        

    }
   

    private void OnTriggerExit(Collider other)
    {

        if(other.gameObject.tag == ("Player"))
        {
            Destroy(gameObject, 6f);
        }
        
        

        
    }
}
