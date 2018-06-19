using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    public GameObject tool;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 a = tool.transform.position;

        Vector2 b = new Vector2(Mathf.Round(a.x), Mathf.Round(a.y));

        tool.transform.position = b;
	}
}
