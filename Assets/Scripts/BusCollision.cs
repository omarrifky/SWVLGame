using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusCollision : MonoBehaviour
{
    AudioSource crashsound;
    public int moneycollected = 0;
    public Text moneytext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "car")
        {
            crashsound = GetComponent<AudioSource>();
            crashsound.Play();
            moneycollected = moneycollected - 20;
            moneytext.text = "MONEY COLLECTED:"+moneycollected;
            GameObject.Destroy(collision.gameObject);



        }

        if (collision.gameObject.tag == "Obstacle")
        {
            crashsound = GetComponent<AudioSource>();
            crashsound.Play();
            moneycollected = moneycollected - 10;
            moneytext.text = "MONEY COLLECTED:"+moneycollected;
            GameObject.Destroy(collision.gameObject);



        }
    }

    public void cashIn(){
        moneycollected+=80;

    }
    void Update()
    {
        moneytext.text = "MONEY COLLECTED: "+moneycollected;
    }
}
