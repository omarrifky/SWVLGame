using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusCollision : MonoBehaviour
{
    AudioSource crashsound;
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

            GameObject.Destroy(collision.gameObject);



        }

        if (collision.gameObject.tag == "Obstacle")
        {
            crashsound = GetComponent<AudioSource>();
            crashsound.Play();

            GameObject.Destroy(collision.gameObject);



        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
