using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

    public Rigidbody rb;
    public GameObject gold;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();

        int rand = Random.Range(-3, 3);

        if (gameObject)
        {
            rb.velocity = new Vector3(rand, 5, 0);
            gold.SetActive(true);
            StartCoroutine(Wait());
        }

        

    }
	
	// Update is called once per frame
	void Update () {

        

    }

    IEnumerator Wait()
    {


        yield return new WaitForSeconds(3);

        gold.SetActive(false);

        Destroy(gold, 10f);

    }



}
