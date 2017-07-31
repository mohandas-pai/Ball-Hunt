using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class hatcontrol : MonoBehaviour {

    public AudioClip mExpNoise;
    public AudioClip mGulpNoise;
    public Text mScoreText;
    public Text mLifeText;
    public GameObject mrestartButton;
    public Sprite[] Heartsp;
    public Image HeartUi;
    int mScore=00;
    float speed = 10F;
    Rigidbody rb;
    public int curHealth;
    public static bool destob = false;
	void Start () {
       // Debug.Log("Start");
        rb = GetComponent<Rigidbody>(); //*********************this
        curHealth = 4;
        destob = false;
	}
	
	// Update is called once per frame
    void Update () {
    //    Debug.Log("---UPDATE----");
        if(gamecontol.touchb==true)
        {
            Vector3 Pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            this.transform.position = new Vector3(Pos.x,-2.54f,0);
        }
       /* if(gamecontol.tiltb==true)
        {
            Vector3 acc = Input.acceleration;//*********************this
            // rb.AddForce(acc.x * speed, 0, acc.y * speed);
            this.transform.position = new Vector3(acc.x * speed, -2.54f, 0);//*********************this
            //if (curHealth > maxHealth)
            //   curHealth = maxHealth;
        }*/

        if (Count.flagg == true)
            callme();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    //void FixedUpdate()
    //{
      //  Vector3 acc = Input.acceleration;
       // rb.AddForce(acc.x * speed, 0, acc.y * speed);
        //this.transform.position = new Vector3(acc.x * speed, -2.54f, acc.y * speed);
   // }
  

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Bomb")
        {
            if (curHealth <= 0)
            {
                AudioSource.PlayClipAtPoint(mExpNoise, this.transform.position);
                Destroy(other.gameObject);
                HeartUi.sprite = Heartsp[0];
                mrestartButton.SetActive(true);
                gamecontol.sIsGamePlay = false;
                destob = true;
            }
            else
            {
                Destroy(other.gameObject);
                curHealth--;
                checklife(curHealth);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Ball")
        {
            mScore++;
            mScoreText.text = "Score:" + mScore;
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(mGulpNoise, this.transform.position);
        }
        if (other.transform.tag == "Special")
        {
            Destroy(other.gameObject);
            int ran = Random.Range(0, 100);

            if (ran % 10 == 0)
            {
                mScore = mScore + 10;
                mScoreText.text = "Score:" + mScore;
            }
            else if(ran%5 == 0)
            {
                curHealth--;
                curHealth--;
                checklife(curHealth);
                if (curHealth <= 0)
                {
                    AudioSource.PlayClipAtPoint(mExpNoise, this.transform.position);
                    HeartUi.sprite = Heartsp[0];
                    mrestartButton.SetActive(true);
                    gamecontol.sIsGamePlay = false;
                    destob = true;
                }
            }

            else
            {
                if(curHealth<=3)
                {
                    curHealth++;
                    checklife(curHealth);
                }
                else
                {
                    mScore = mScore + 4;
                    mScoreText.text = "Score:" + mScore;
                }
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    void checklife(int h)
    {
        if (h == 4)
                    HeartUi.sprite = Heartsp[5];
                else if (h == 3)
                    HeartUi.sprite = Heartsp[4];
                else if (h == 2)
                    HeartUi.sprite = Heartsp[3];
                else if (h == 1)
                    HeartUi.sprite = Heartsp[2];
                else if (h == 0)
                    HeartUi.sprite = Heartsp[1];
                else
                    HeartUi.sprite = Heartsp[0];
    }


    public  void callme()
    {
        if(Count.balllife==true)
        {
            curHealth--;
            checklife(curHealth);
            Count.balllife = false;
            if (curHealth <= 0)
            {
                AudioSource.PlayClipAtPoint(mExpNoise, this.transform.position);
                HeartUi.sprite = Heartsp[0];
                mrestartButton.SetActive(true);
                gamecontol.sIsGamePlay = false;
                destob = true;
            }
        }
        if (Count.bomblife == true)
        {
            curHealth++;
            checklife(curHealth);
            Count.bomblife = false;
        }
        if (Count.speciallife == true)
        {
            if (curHealth == 2)
            {
                curHealth--;
                checklife(curHealth);
                if (curHealth <= 0)
                {
                    AudioSource.PlayClipAtPoint(mExpNoise, this.transform.position);
                    HeartUi.sprite = Heartsp[0];
                    mrestartButton.SetActive(true);
                    gamecontol.sIsGamePlay = false;
                    destob = true;
                }
            }
            else
            {
                curHealth--;
                curHealth--;
                checklife(curHealth);
                if (curHealth <= 0)
                {
                    AudioSource.PlayClipAtPoint(mExpNoise, this.transform.position);
                    HeartUi.sprite = Heartsp[0];
                    mrestartButton.SetActive(true);
                    gamecontol.sIsGamePlay = false;
                    destob = true;
                }
            }
            Count.speciallife = false;
        }
    }
}
