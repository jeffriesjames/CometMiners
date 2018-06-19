using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class jump : MonoBehaviour {

    public Rigidbody rb;
    public bool isJump;
    public bool isDead;
    private Transform target;
    public GameObject Miner;
    public GameObject Gold;
    public int score;
    private ParticleSystem partsys;
    public bool canDig;

    public Text scoreText;

    public float smooth = 1f;

    private Vector3 targetAngles;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        partsys = gameObject.GetComponentInChildren<ParticleSystem>();

        isDead = false;
        canDig = false;

    }
    void Update()
    {
        if (isJump == false)
        {
            if (Input.GetButtonDown("Jump"))
            {

                rb.velocity = new Vector3(0, 15, 0);
                rb.isKinematic = false;
                isJump = true;
                canDig = true;
                

            }

            if (Input.GetButtonDown("right"))
            {
                rb.velocity = new Vector3(11, 14.5f, 0);
                rb.isKinematic = false;
                isJump = true;
                canDig = true;

                targetAngles = transform.eulerAngles + 180f * Vector3.forward;

                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, smooth);


            }

            if (Input.GetButtonDown("left"))
            {
                rb.velocity = new Vector3(-11, 14.5f, 0);
                rb.isKinematic = false;
                isJump = true;
                canDig = true;

                targetAngles = transform.eulerAngles + 180f * Vector3.forward;

                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, smooth);


            }

            if (isDead == true)
            {
                rb.velocity = new Vector3(0, -3, 0);
                rb.isKinematic = false;
               
                
            }
            

            if (isJump == true)
            {
                Miner.transform.GetChild(1).gameObject.SetActive(false);
                Miner.transform.GetChild(2).gameObject.SetActive(true);
                partsys.Play();
            }

            if(isJump == false)
            {
                Miner.transform.GetChild(1).gameObject.SetActive(true);
                Miner.transform.GetChild(2).gameObject.SetActive(false);
            }

            if(isJump == false && isDead == false && canDig == true && Input.GetKeyDown("space"))
            {
                Instantiate(Gold, transform.position, transform.rotation);
                Gold.SetActive(true);
                //StartCoroutine(Wait());

               
                score++;
            }
            if (rb.velocity.x == 11)
            {
                Miner.transform.GetChild(2).localScale = new Vector3(4.6875F, -2F, -2F);
                Miner.transform.GetChild(2).localPosition = new Vector3(0, 1.186F, 0);
            }
            if (rb.velocity.x == -11)
            {
                Miner.transform.GetChild(2).localScale = new Vector3(4.6875F, 2F, -2F);
                Miner.transform.GetChild(2).localPosition = new Vector3(0, -1.186F, 0);
            }

            //Debug.Log(score);
        }

        scoreText.text = "Score: " + score;
        
    }
    void SetScore()
    {
        PlayerPrefs.SetInt("PlayerScore", score);
    }

    void StoreHighscore()
    {
        
        int oldHighscore = PlayerPrefs.GetInt("highscore");
        if (score > oldHighscore)
            PlayerPrefs.SetInt("highscore", score);
    }

    IEnumerator Wait()
    {
        

        yield return new WaitForSeconds(3);

        //Gold.SetActive(false);

        //Destroy(Gold, 3f);

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "planet")
        {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            //Destroy(collision.gameObject, 3f);
            //LevelManager.numOfPlanets--;

            var currentPos = transform.position;
            transform.position = new Vector3(Mathf.Round(currentPos.x),
                                         Mathf.Round(currentPos.y),
                                         Mathf.Round(currentPos.z));

            rb.isKinematic = true;
            isJump = false;
        }

        if(collision.collider.name == "OB")
        {
            isDead = true;
            Debug.Log("OB");
            SetScore();
            StoreHighscore();
            PlayerPrefs.Save();
            SceneManager.LoadScene("Death");
        }
        if (collision.collider.name == "Laser(Clone)")
        {
            isDead = true;
        }
        if (collision.collider.tag == "Alien")
        {
            isDead = true;
        }




    }
   

}
