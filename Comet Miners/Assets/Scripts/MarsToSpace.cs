﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarsToSpace : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Miner")
        {
            GoMine();
        }
    }
    public void GoMine()
    {
        SceneManager.LoadScene("Main_Scene");
    }
}
