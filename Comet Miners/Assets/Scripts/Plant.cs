using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{

    bool noPlant, GrowingTimer, DestroyTimer;
    bool potatoPlanted;
    bool potatoWatered;
    bool potatoReady;
    float waterTimeLeft = 60.0f;
    float destroyTimeLeft = 20.0f;

    public Text GoldText, IronText, WaterText, SeedText;

    public int goldhave, ironhave, waterhave, seedhave;

    private static bool created = false;

    // Use this for initialization
    void Start()
    {
        noPlant = true;
    }
    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            //created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        goldhave = PlayerPrefs.GetInt("Gold");
        waterhave = PlayerPrefs.GetInt("Ice");
        ironhave = PlayerPrefs.GetInt("Iron");
        seedhave = PlayerPrefs.GetInt("Seeds");


        if (GrowingTimer == true)
        {
            waterTimeLeft -= Time.deltaTime;
            if (waterTimeLeft < 0)
            {
                potatoWatered = true;
            }
        }
        if(DestroyTimer == true)
        {
            destroyTimeLeft -= Time.deltaTime;
            if(destroyTimeLeft < 0)
            {
                Destroy(gameObject);
            }
        }
        if (potatoWatered == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            potatoWatered = false;
            potatoReady = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (other.gameObject.tag == "Seed" && noPlant == true && seedhave > 0)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                Debug.Log("Seed is Planted");
                potatoPlanted = true;
                noPlant = false;
                potatoWatered = false;

                PlayerPrefs.SetInt("Seeds", PlayerPrefs.GetInt("Seeds") - 1);
            }

            else if (other.gameObject.tag == "Water" && potatoPlanted == true && waterhave > 0)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                Debug.Log("Seed has been watered");
                GrowingTimer = true;
                potatoPlanted = false;

                PlayerPrefs.SetInt("Ice", PlayerPrefs.GetInt("Ice") - 1);
            }

            else if (other.gameObject.tag == "Hands" && potatoReady == true)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.clear;
                Debug.Log("Good job you didnt fuck up");
                noPlant = true;
                potatoPlanted = false;
                potatoWatered = false;
                potatoReady = false;
                GrowingTimer = false;
                waterTimeLeft = 1f;
                DestroyTimer = true;
            }
        }
    }
}
    

