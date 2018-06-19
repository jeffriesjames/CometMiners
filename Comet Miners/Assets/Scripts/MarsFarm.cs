using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarsFarm : MonoBehaviour {
    public Rigidbody rb;
    int walkSpeed = 3;
    int seedsTot, potTot;
    public GameObject shovel,hands, seed, water, axe, player;
    bool axeOut, canPlant;
    public Transform PlantSpot;
    public Text GoldText, IronText, WaterText, SeedText;

    public int goldhave, ironhave, waterhave, seedhave;

    // Use this for initialization
    public void Start () {
        rb = GetComponent<Rigidbody>();
        seed = gameObject.transform.GetChild(1).gameObject;
        water = gameObject.transform.GetChild(2).gameObject;
        shovel = gameObject.transform.GetChild(3).gameObject;
        axe = gameObject.transform.GetChild(4).gameObject;
        hands = gameObject.transform.GetChild(5).gameObject;

        seed.SetActive(false);
        water.SetActive(false);
        shovel.SetActive(false);
        axe.SetActive(false);
        hands.SetActive(true);
        canPlant = true;
	}

    // Update is called once per frame
    public void Update () {

        //SET UP PLAYERPREFS!!!!!!!!!!!!!!!!
        goldhave = PlayerPrefs.GetInt("Gold");
        waterhave = PlayerPrefs.GetInt("Ice");
        ironhave = PlayerPrefs.GetInt("Iron");
        seedhave = PlayerPrefs.GetInt("Seeds");

        GoldText.text = "Gold: " + (PlayerPrefs.GetInt("Gold"));
        WaterText.text = "Water: " + (PlayerPrefs.GetInt("Ice"));
        IronText.text = "Iron: " + (PlayerPrefs.GetInt("Iron"));
        SeedText.text = "Seeds: " + (PlayerPrefs.GetInt("Seeds"));

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector3(0, walkSpeed, 0);

            transform.localEulerAngles = new Vector3(0, 0, z: -90);

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = new Vector3(0, -(walkSpeed), 0);

            transform.localEulerAngles = new Vector3(0, 0, z: -270);
        }

        // no else here. Combinations of up/down and left/right are fine.
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector3(-(walkSpeed), 0, 0);
            transform.localEulerAngles = new Vector3(0, 0, z: 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector3(walkSpeed, 0, 0);
            transform.localEulerAngles = new Vector3(0, 0, z: -180);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)){
            rb.velocity = new Vector3(0, 0, 0);
        
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && canPlant == true && axeOut == true)
        {
            Plant();
        }
        
       
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Dirt")
        {
            canPlant = false;
            //Debug.Log(canPlant);
        }
        
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Dirt")
        {
            canPlant = true;
            //Debug.Log(canPlant);
        }
    }
    public void Hoe()
    {
            hands.SetActive(false);
            seed.SetActive(false);
            water.SetActive(false);
            shovel.SetActive(false);
            axe.SetActive(true);
            axeOut = true;
        
    }
    public void Seeds()
    {
        hands.SetActive(false);
        seed.SetActive(true);
        water.SetActive(false);
        shovel.SetActive(false);
        axe.SetActive(false);
        axeOut = false;
    }
    public void Water()
    {
        hands.SetActive(false);
        seed.SetActive(false);
        water.SetActive(true);
        shovel.SetActive(false);
        axe.SetActive(false);
        axeOut = false;
    }
    public void Shovel()
    {
        hands.SetActive(false);
        seed.SetActive(false);
        water.SetActive(false);
        shovel.SetActive(true);
        axe.SetActive(false);
        axeOut = false;
    }
    public void Hands()
    {
        hands.SetActive(true);
        seed.SetActive(false);
        water.SetActive(false);
        shovel.SetActive(false);
        axe.SetActive(false);
        axeOut = false;
    }
    public void Plant()
    {
            Vector2 playerPos = player.transform.position;
            Vector2 playerDirection = player.transform.forward;
            Quaternion playerRotation = player.transform.rotation;
            float spawnDistance = 1f;

            Vector2 spawnPos = playerPos + playerDirection * spawnDistance;
            spawnPos.x = Mathf.Round(spawnPos.x);
            spawnPos.y = Mathf.Round(spawnPos.y);

            Instantiate(PlantSpot, spawnPos, playerRotation);
            Debug.Log(spawnPos);

            
    }
}
