using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {

            rb.velocity = new Vector3(0, 4, 0);
            
        }
      

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Miner")
        {
            rb.isKinematic = true;
        }
    }
}
