using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Swipe : MonoBehaviour
{

    public Rigidbody rb;
    public bool isJump;
    public bool isDead;
    private Transform target;
    public GameObject Miner;
    public GameObject Gold;
    public GameObject Iron;
    public GameObject Ice;
    public GameObject Seeds;
    public int mine,gold,iron,ice,seeds;
    private ParticleSystem partsys;
    public bool canDig;

    public Text GoldText, IronText, IceText, SeedText;

    public float smooth = 1f;

    private Vector3 targetAngles;

    private Vector2 initialPos;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        partsys = gameObject.GetComponentInChildren<ParticleSystem>();

        isDead = false;
        canDig = false;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Calculate(Input.mousePosition);
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

        if (isJump == false)
        {
            Miner.transform.GetChild(1).gameObject.SetActive(true);
            Miner.transform.GetChild(2).gameObject.SetActive(false);
        }

        if (isJump == false && isDead == false && canDig == true && Input.GetMouseButtonDown(0))
        {
            Mining();
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
        GoldText.text = "Gold: " + (PlayerPrefs.GetInt("Gold") + gold);
        IronText.text = "Iron: " + (PlayerPrefs.GetInt("Iron") + iron);
        IceText.text = "Ice: " + (PlayerPrefs.GetInt("Ice") + ice);
        SeedText.text = "Seeds: " + (PlayerPrefs.GetInt("Seeds") + seeds);
    }
    void SetScore()
    {
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold")+ gold);
        PlayerPrefs.SetInt("Iron", PlayerPrefs.GetInt("Iron")+ iron);
        PlayerPrefs.SetInt("Ice", PlayerPrefs.GetInt("Ice")+ ice);
        PlayerPrefs.SetInt("Seeds", PlayerPrefs.GetInt("Seeds")+ seeds);
    }

    IEnumerator Wait()
    {


        yield return new WaitForSeconds(3);

        //Gold.SetActive(false);

        //Destroy(Gold, 3f);

    }
    void Mining()
    {
        mine = Random.Range(0, 14);

        if(mine < 4)
        {
            Instantiate(Gold, transform.position, transform.rotation);
            Gold.SetActive(true);
            gold++;
        }
        else if(mine == 5)
        {
            Instantiate(Ice, transform.position, transform.rotation);
            Ice.SetActive(true);
            ice++;
        }
        else if(mine == 6)
        {
            Instantiate(Iron, transform.position, transform.rotation);
            Iron.SetActive(true);
            iron++;
        }
        else if (mine == 7)
        {
            Instantiate(Seeds, transform.position, transform.rotation);
            Seeds.SetActive(true);
            seeds++;
        }


    }

    void Calculate(Vector3 finalPos)
    {
        float disX = Mathf.Abs(initialPos.x - finalPos.x);
        float disY = Mathf.Abs(initialPos.y - finalPos.y);
        if (disX > 0 || disY > 0)
        {
            if (disX > disY)
            {
                if (initialPos.x > finalPos.x)
                {
                    if (isJump == false && rb.position.x > 0)
                    {
                        rb.velocity = new Vector3(-11, 14.5f, 0);
                        rb.isKinematic = false;
                        isJump = true;
                        canDig = true;

                        targetAngles = transform.eulerAngles + 180f * Vector3.forward;

                        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, smooth);


                    }
                }
                else
                {
                    if (isJump == false && rb.position.x < 0)
                    {
                        rb.velocity = new Vector3(11, 14.5f, 0);
                        rb.isKinematic = false;
                        isJump = true;
                        canDig = true;

                        targetAngles = transform.eulerAngles + 180f * Vector3.forward;

                        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, smooth);


                    }
                }
            }
            else
            {
                if (initialPos.y > finalPos.y)
                {
                    Debug.Log("Down");
                }
                else
                {
                    if (isJump == false)
                    {

                            rb.velocity = new Vector3(0, 15, 0);
                            rb.isKinematic = false;
                            isJump = true;
                            canDig = true;


                        }
                    }
            }
        }
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

        if (collision.collider.name == "OB")
        {
            isDead = true;
            Debug.Log("OB");
            SetScore();
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