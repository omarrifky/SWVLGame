using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human1AnimationController : MonoBehaviour
{
    Animator anim;
    AudioSource cashsound;
    bool waving = false;
    bool getonbus = false;
    bool late = false;
    bool destinationlate = false;
    bool busarrived = false;
    public GameObject Bus;
    public GameObject station1;
    public GameObject station2;
    public GameObject station3;
    public GameObject station4;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        busarrived = GameObject.Find("Bus").GetComponent<BusMovement>().busarrived;


        if (station1.transform.position.z<=Bus.transform.position.z +2 && station1.transform.position.z + 5>= Bus.transform.position.z && Bus.transform.position.x >= 3.6 && getonbus == false && late==false )
        {
            waving = true;
            anim.SetBool("StartWaving", waving);
            getonbus = true;
            anim.SetBool("GetOnBus", getonbus);
            cashsound = GetComponent<AudioSource>();
            cashsound.Play();
        }

        if (station1.transform.position.z <= Bus.transform.position.z + 2 && station1.transform.position.z + 5 >= Bus.transform.position.z && Bus.transform.position.x >= 3.6 && getonbus == false&&late==true)
        {
            anim.SetBool("Late", late);
            getonbus = true;
            anim.SetBool("GetOnBus", getonbus);
        }

       // print(busarrived);

        if(busarrived ==true && destinationlate == false)
        {
            
            anim.SetBool("StartDancing", busarrived);
        }

        if (busarrived == true && destinationlate == true)
        {
            anim.SetBool("StartYelling", destinationlate);
        }


    }
}
