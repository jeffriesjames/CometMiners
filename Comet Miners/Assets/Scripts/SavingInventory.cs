﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingInventory : MonoBehaviour {

    //private static bool created = false;
    //public static SavingInventory Instance;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        
            DontDestroyOnLoad(gameObject);
            
        }
    }


