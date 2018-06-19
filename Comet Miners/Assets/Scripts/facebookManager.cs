using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine.SceneManagement;

public class facebookManager : MonoBehaviour {
	
	public GameObject StartPanel;
	public GameObject SuccPanel;
	public GameObject userName;
	public GameObject userPhoto;

	void Awake(){
		//Initialize Facebook
		FB.Init (SetInit, HideUnity);

	}
	 
	private void SetInit(){
		//Determine if facebook user is logged in or not
		if (FB.IsLoggedIn)
			Debug.Log ("Facebook user is logged in...");
		else 
			Debug.Log ("Facebook user is not logged in...");

		SwitchPanel(FB.IsLoggedIn);
	}

	private void HideUnity(bool showGame){
		//
		if (showGame)
			Time.timeScale = 1;
		else 
			Time.timeScale = 0;
	}


	public void FBlogin(){
        // Create list array of items to grab from user profile
        //List<string> permissions = new List<string>();
        //permissions.Add ("public_profile");

        // Log into Facebook and request profile info
        //FB.LogInWithPublishPermissions(permissions, LoginResults);
        FB.LogInWithReadPermissions(new List<string>() { "email" }, LoginResults);
        FB.LogInWithPublishPermissions(new List<string>() { "publish_actions" }, LoginResults);

    }

	public void LoginResults(IResult result){

		if (result.Error != null)
			Debug.Log (result.Error);
		else {
			if (FB.IsLoggedIn)
				Debug.Log ("Facebook user is logged in...");
			else 
				Debug.Log ("Facebook user is not logged in...");

			SwitchPanel(FB.IsLoggedIn);
		}

	}

	public void SwitchPanel(bool isLoggedIn){

		if (isLoggedIn) {
			SuccPanel.SetActive(true);
			StartPanel.SetActive(false);

			//Get username and user profile photo
			FB.API("/me?fields=name", HttpMethod.GET, DisplayUserName);
			FB.API("/me/picture?type=square&height=128&width128", HttpMethod.GET, DisplayUserPhoto);


        }
		else {
			SuccPanel.SetActive(false);
			StartPanel.SetActive(true);
		}



	}

	public void DisplayUserName(IResult result){	
		Text newUserName = userName.GetComponent<Text> ();

		if (result.Error != null) {
			Debug.Log (result.Error);
		}
		else {
			newUserName.text = "Hi there, " + result.ResultDictionary ["name"];
		}

	}

	public void DisplayUserPhoto(IGraphResult result){
		Image newUserPhoto = userPhoto.GetComponent<Image> ();

		if (result.Error != null)
			Debug.Log (result.Error);
		else
			newUserPhoto.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), Vector2.zero);
	}

	public void ShareStuff(){
		FB.FeedShare (
		             "",
		             new System.Uri ("http://www.pct.edu"),
		             "CIT312 is okay sometimes",
		             "Link Caption",
		             "This is where a description would go",
			new System.Uri ("http://i3.kym-cdn.com/entries/icons/original/000/022/022/C2AAMCLVQAESU6Z.jpg"),
		             "",
		             LoginResults);
	}

    public void LoadGame()
    {
        SceneManager.LoadScene("Main_Scene");

    }
    public void ResetValues()
    {
        PlayerPrefs.SetInt("Gold", 0);
        PlayerPrefs.SetInt("Iron", 0);
        PlayerPrefs.SetInt("Ice", 0);
        PlayerPrefs.SetInt("Seeds", 0);
        PlayerPrefs.SetInt("Bought2", 0);
        PlayerPrefs.SetInt("Bought3", 0);
        PlayerPrefs.SetInt("Bought4", 0);
    }

}
