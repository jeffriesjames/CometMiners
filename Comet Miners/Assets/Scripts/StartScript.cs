using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

    public Rigidbody rb;
    public GameObject Miner;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(15f, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        Miner.gameObject.SetActive(true);

    }

    public void OnTriggerExit(Collider other)
    {
        Destroy(gameObject, 2f);
    }
}
