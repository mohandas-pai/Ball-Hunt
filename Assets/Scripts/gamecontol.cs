using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamecontol : MonoBehaviour {

    public GameObject[] mBallorBomb;
    public Text mdisptext;
    public GameObject mSky;
    float mWidth;
    float mHeight;
    public GameObject mtouchButton;
    public GameObject mtiltButton;
    public GameObject mrestartButton;
    public static bool sIsGamePlay=true;
    public static bool touchb = true;
    public static bool tiltb = true;
    

	// Use this for initialization
	void Start () {










        sIsGamePlay = true;
        mWidth = mSky.GetComponent<Renderer>().bounds.size.x/2;
        mHeight = mSky.GetComponent<Renderer>().bounds.size.y;

        Debug.Log("Width" + mWidth);
        Debug.Log("Height" + mHeight);

       //   InvokeRepeating("InstantiateBallorBomb", 1, 1);

	}
    void InstantiateBallorBomb()
    {
        if (!sIsGamePlay)
            CancelInvoke("InstantiateBallorBomb");
        else
        {
            //random pos
            float randomWidth = Random.Range(-mWidth, mWidth);
            Vector3 pos = new Vector3(randomWidth, mHeight, 0);

            //random object
            int prefabIndex = Random.Range(0, mBallorBomb.Length);
            if(prefabIndex!=2)
                Instantiate(mBallorBomb[prefabIndex], pos, Quaternion.identity);
            else
            {
                int num = Random.Range(1,100);
                if (num % 5==0)
                    Instantiate(mBallorBomb[prefabIndex], pos, Quaternion.identity);
            }
           // Instantiate(mBallorBomb[2], pos, Quaternion.identity);

        }
    }


   /* void InstantiateBallorBomb()
    {
        if (!sIsGamePlay)
            CancelInvoke("InstantiateBallorBomb");
        else
        {
            //random pos
            float randomWidth = Random.Range(-mWidth, mWidth);
            Vector3 pos = new Vector3(randomWidth, mHeight, 0);

            //random object
            int prefabIndex = Random.Range(0, mBallorBomb.Length);

            Instantiate(mBallorBomb[prefabIndex], pos, Quaternion.identity);
        }
    }*/



	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
	}

    public void touch()
    {
        mdisptext.text = "";
        tiltb = false;
        touchb = true;
        InvokeRepeating("InstantiateBallorBomb", 1, 1);
        mtouchButton.SetActive(false);
        mtiltButton.SetActive(false);
        mrestartButton.SetActive(false);
    }

    public void tilt()
    {
        mdisptext.text = "Pay 1000$ and unlock this feature ";
        /*tiltb = true;
        touchb = false;
        InvokeRepeating("InstantiateBallorBomb", 1, 1);
        mtouchButton.SetActive(false);
        mtiltButton.SetActive(false);
         mrestartButton.SetActive(false);*/
    }
    public void rules()
    {
        mdisptext.text = "Figure it out yourself";
    }
   
}
