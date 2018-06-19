using UnityEngine;
using System.Collections;

public class AttractToObject : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody attractedTo;
    public float strengthOfAttraction;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        attractedTo = GameObject.Find("Miner").GetComponent<Rigidbody>();

        strengthOfAttraction = -60f;

    }
    void Update()
    {
        //get the offset between the objects
        Vector3 offset = attractedTo.transform.position -
        transform.position;
        //we're doing 2d physics, so don't want to try and apply z forces!
        offset.z = 0;

        //get the squared distance between the objects
        float magsqr = offset.sqrMagnitude;

        //check distance is more than 0 (to avoid division by 0) and then apply a gravitational force to the object
        //note the force is applied as an acceleration, as acceleration created by gravity is independent of the mass of the object
        if (magsqr < 6f && magsqr > 0.0001f)
        {
            attractedTo.AddForce(strengthOfAttraction * offset.normalized / magsqr, ForceMode.Acceleration);
        }

        if (Input.GetButtonDown("Jump") || (Input.GetButtonDown("right") || (Input.GetButtonDown("left"))))
        {
            //attractedTo.isKinematic = false;
            attractedTo.AddForce(-(strengthOfAttraction * offset.normalized / magsqr), ForceMode.Acceleration);

        }

        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log (this);
            //Destroy(GetComponent<AttractToObject>());
            this.enabled = false;
        }
    }


}