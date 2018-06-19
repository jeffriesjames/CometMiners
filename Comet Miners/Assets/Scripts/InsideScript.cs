using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InsideScript : MonoBehaviour {

    public GameObject Canvas;
    public GameObject Crew2, Crew3, Crew4;
    public Text GoldText, WaterText;

    public int goldhave;

	// Use this for initialization
	void Start () {

        
		
	}
	
	// Update is called once per frame
	void Update () {

        goldhave = PlayerPrefs.GetInt("Gold");

        GoldText.text = "Gold: " + (PlayerPrefs.GetInt("Gold"));
        WaterText.text = (PlayerPrefs.GetInt("Ice")) + " / 500";

        if(PlayerPrefs.GetInt("Bought2") != 1)
        {
            Canvas.transform.GetChild(1).gameObject.SetActive(true);
            Canvas.transform.GetChild(6).gameObject.SetActive(false);
            Crew2.transform.gameObject.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("Bought2") == 1)
        {
            Canvas.transform.GetChild(1).gameObject.SetActive(false);
            Canvas.transform.GetChild(6).gameObject.SetActive(true);
            Crew2.transform.gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Bought3") != 1)
        {
            Canvas.transform.GetChild(2).gameObject.SetActive(true);
            Canvas.transform.GetChild(7).gameObject.SetActive(false);
            Crew3.transform.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Bought3") == 1)
        {
            Canvas.transform.GetChild(2).gameObject.SetActive(false);
            Canvas.transform.GetChild(7).gameObject.SetActive(true);
            Crew3.transform.gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Bought4") != 1)
        {
            Canvas.transform.GetChild(3).gameObject.SetActive(true);
            Canvas.transform.GetChild(8).gameObject.SetActive(false);
            Crew4.transform.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Bought4") == 1)
        {
            Canvas.transform.GetChild(3).gameObject.SetActive(false);
            Canvas.transform.GetChild(8).gameObject.SetActive(true);
            Crew4.transform.gameObject.SetActive(true);
        }

    }

    public void BuyCrew2()
    {
        if(goldhave >= 100)
        {
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - 100);

            PlayerPrefs.SetInt("Bought2", 1);
        }
    }

    public void BuyCrew3()
    {
        if (goldhave >= 1000)
        {
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - 1000);

            PlayerPrefs.SetInt("Bought3", 1);
        }
    }

    public void BuyCrew4()
    {
        if (goldhave >= 5000)
        {
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - 5000);

            PlayerPrefs.SetInt("Bought4", 1);
        }
    }


    public void GoMine()
    {
        SceneManager.LoadScene("2");
    }
    public void LandOnMars()
    {
        SceneManager.LoadScene("Mars");
    }

    public void CHEAT()
    {
        PlayerPrefs.SetInt("Gold", 5000);
    }
}
