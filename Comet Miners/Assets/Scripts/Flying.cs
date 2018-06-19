using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        transform.localRotation = Quaternion.Euler(-40, 0, 0);


    }
}
