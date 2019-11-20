using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class child2controller : MonoBehaviour
{
    Animator anim;
    bool waving = false;
    bool getonbus = false;
    public AudioSource cashsound;
    public AudioSource latebuzzer;
    public GameObject Bus;
    public GameObject station1;
    bool late = false;
    bool destinationlate = false;
    bool busarrived = false;
     float animover;
     bool onetime = false;

    bool once = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        busarrived = GameObject.Find("Bus").GetComponent<BusMovement>().busarrived;
         if(busarrived==true && Time.time <= 89&& once == false){
            destinationlate = false;
            once = true;
            print("ARRIVED");
        }

        if(busarrived==true && Time.time > 89 && once == false){
            destinationlate = true;
            once = true;
        }
        if (station1.transform.position.z <= Bus.transform.position.z + 2 && station1.transform.position.z + 5 >= Bus.transform.position.z && Bus.transform.position.x >= 3.6 && Time.time < 31)
        {
            late = false;
        }

        if (station1.transform.position.z <= Bus.transform.position.z + 2 && station1.transform.position.z + 5 >= Bus.transform.position.z && Bus.transform.position.x >= 3.6 && Time.time >= 31)
        {
            late = true;
        }
        if (station1.transform.position.z <= Bus.transform.position.z + 2 && station1.transform.position.z + 5 >= Bus.transform.position.z && Bus.transform.position.x >= 3.6 && getonbus == false && late == false)
        {
            waving = true;
            anim.SetBool("StartWaving", waving);
            getonbus = true;
            anim.SetBool("GetOnBus", getonbus);
           
            cashsound.Play();
        }

        if (station1.transform.position.z <= Bus.transform.position.z + 2 && station1.transform.position.z + 5 >= Bus.transform.position.z && Bus.transform.position.x >= 3.6 && getonbus == false && late == true)
        {
            anim.SetBool("Late", late);
            getonbus = true;
            anim.SetBool("GetOnBus", getonbus);
            latebuzzer.Play();
        }

        if(getonbus==true){
         if(onetime == false){
            if(late==false)
            animover = Time.time + 5.8f;
            else
             animover = Time.time + 7f;
            onetime = true;
            
            }
            if(Time.time > animover&& onetime == true){
            
               transform.position = new Vector3(500f, 0.42f, 666);
                onetime = false;
            }
        }

        if(busarrived ==true && destinationlate == false)
        {
            
            anim.SetBool("StartDancing", busarrived);
             transform.position = new Vector3(5.71f, 0.42f, 664.89f);
        }

        if (busarrived == true && destinationlate == true)
        {
            anim.SetBool("StartYelling", destinationlate);
           transform.position = new Vector3(5.56f, 0.42f, 665.92f);
        }
        
    }
}
