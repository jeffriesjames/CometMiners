using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventFollow : MonoBehaviour {

    public GameObject miner;

	// Use this for initialization
	void Start () {
        //miner = GameObject.Find("Miner");
	}
	
	// Update is called once per frame
	void Update () {


        miner = GameObject.Find("Miner");
        transform.position = miner.transform.localPosition;


            
        
	}
}
