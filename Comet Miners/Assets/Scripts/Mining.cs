using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour {

    public float smooth = 1f;

    private Vector3 targetAngles;

    // Use this for initialization
    void Start () {

        

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {

            transform.localRotation = Quaternion.Euler(-40 , 0, 0);

            //targetAngles = transform.eulerAngles + -40f * Vector3.left;

            //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, smooth);

        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.localRotation = Quaternion.Euler(-120, 0, 0);
        }

    }
}
