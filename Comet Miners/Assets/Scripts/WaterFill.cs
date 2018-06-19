using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterFill : MonoBehaviour {

    public Image Water;
    public float cur_Water;
    public float max_Water = 500f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        cur_Water = PlayerPrefs.GetInt("Ice");

        Water.fillAmount = (cur_Water / max_Water);
		
	}
}
