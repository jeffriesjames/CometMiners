using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Transform player;
    public Rigidbody projectile;
    public int speed = 70;
  
    public bool inRange;
    private float distance;

    float originalY;

    public float floatStrength = 2;

    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            originalY + ((float)Mathf.Sin(Time.time) * floatStrength),
            transform.position.z);

        if (player == null)
        {
            GameObject go = GameObject.Find("Miner");

            if(go != null)
            {
                player = go.transform;
            }
        }

        if(player == null)
        {
            return;
        }

        Vector3 dir = player.position - transform.position;

        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.Euler(0, 0, zAngle);

       distance = Vector3.Distance(transform.position, player.position);

      
    }


   

   
}
