using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour {

    private ParticleSystem ps;
    public bool isCharging;
    public bool isShooting;

    Transform player;
    public Rigidbody projectile;
    public int speed = 1500;

    public bool inRange;
    private float distance;

    

    // Use this for initialization
    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        ps.Stop();
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("Miner");

            if (go != null)
            {
                player = go.transform;
            }
        }

        if (player == null)
        {
            return;
        }

        Vector3 dir = player.position - transform.position;

        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.Euler(0, 0, zAngle);

        distance = Vector3.Distance(transform.position, player.position);

        if (distance < 9)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        int charging = Random.Range(0, 200);

        

        if (charging == 1 && isCharging == false && inRange == true)
        {
            ps.Play();
            isCharging = true;
            isShooting = false;
            
        }
        //if(charging != 1)
        //{
            
        //    isShooting = false;
        //}
        

        if (!ps.IsAlive(true) && isCharging == true)
        {
            isCharging = false;
            isShooting = true;
        }
        if(isShooting == true)
        {
            Fire();
            isShooting = false;
        }
        

    }

    public void Fire()
    {

        Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
        instantiatedProjectile.velocity = transform.TransformDirection(Vector3.up * speed);

    }

   

       


}
