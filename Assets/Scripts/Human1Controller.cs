﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class Human1Controller : MonoBehaviour
{
    Animator anim;
    public AudioSource cashsound;
    public AudioSource latebuzzer;
    bool waving = false;
    bool getonbus = false;
    bool late = false;
    bool destinationlate = false;
    bool busarrived = false;
     float animover;
     bool onetime = false;
     private int requiredtime;

    bool once = false;
    public GameObject Bus;
    public GameObject station;
    private BusCollision busCollisionScript ;
    private bool onBoard;
    ArrayList charactersPostions;

    void Start()
    {
        anim = GetComponent<Animator>();
        busCollisionScript = GameObject.FindGameObjectWithTag("Cube").GetComponent<BusCollision>();
        onBoard =  false;
        charactersPostions = new ArrayList();
        charactersPostions.Add(new Vector3(6.35f, 0.42f, 664.46f));//woman 1
        charactersPostions.Add(new Vector3(5.71f, 0.42f, 664.89f));//woman 2
        charactersPostions.Add(new Vector3(5.56f, 0.42f, 670.33f));//woman 3
        charactersPostions.Add(new Vector3(5.81f, 0.42f, 671.85f));//man 1
        charactersPostions.Add(new Vector3(5.91f, 0.42f, 665.92f));//man 2
        charactersPostions.Add(new Vector3(6.66f, 0.42f, 669.41f));// man 3
        charactersPostions.Add(new Vector3(6.35f, 0.42f, 663.68f));// child 1
        charactersPostions.Add(new Vector3(5.71f, 0.42f, 662.42f));// child 2
        charactersPostions.Add(new Vector3(5.56f, 0.42f, 674.33f));// child 3
       
    }

    // Update is called once per frame
    void Update()
    {
        busarrived = GameObject.Find("Bus").GetComponent<BusMovement>().busarrived;
        if(busarrived==true && Time.timeSinceLevelLoad <= 89&& once == false){
            destinationlate = false;
            once = true;
        }

        if(busarrived==true && Time.timeSinceLevelLoad > 89 && once == false){
            destinationlate = true;
            once = true;
                
        }
        if(station.CompareTag("1")){
         requiredtime = 18;
        }
        if(station.CompareTag("2")){
           requiredtime = 35; 
        }
        if(station.CompareTag("3")){
            requiredtime = 60;
        }

        if (station.transform.position.z <= Bus.transform.position.z + 2 && station.transform.position.z + 5 >= Bus.transform.position.z && Bus.transform.position.x >= 3.6 && Time.time < requiredtime)
        {
            late = false;
                
        }

        if (station.transform.position.z <= Bus.transform.position.z + 2 && station.transform.position.z + 5 >= Bus.transform.position.z && Bus.transform.position.x >= 3.6 && Time.time >= requiredtime)
        {
            late = true;
        }
        if (station.transform.position.z<=Bus.transform.position.z +2 && station.transform.position.z + 5>= Bus.transform.position.z && Bus.transform.position.x >= 3.6 && getonbus == false && late==false )
        {
            waving = true;
            anim.SetBool("StartWaving", waving);
            getonbus = true;
            anim.SetBool("GetOnBus", getonbus);
            cashsound.Play();
            busCollisionScript.cashIn();
            onBoard = true;
           

        }
       

        if (station.transform.position.z <= Bus.transform.position.z + 2 && station.transform.position.z + 5 >= Bus.transform.position.z && Bus.transform.position.x >= 3.6 && getonbus == false&&late==true)
        {
            anim.SetBool("Late", late);
            getonbus = true;
            anim.SetBool("GetOnBus", getonbus);
            latebuzzer.Play();
            onBoard = true;
        }
         
         if(getonbus==true){
         if(onetime == false){

             if(late==false){
        if(gameObject.CompareTag("4")||gameObject.CompareTag("5")||gameObject.CompareTag("6"))
         animover = Time.timeSinceLevelLoad + 2f;
        else if(gameObject.CompareTag("7")||gameObject.CompareTag("8")||gameObject.CompareTag("9"))
         animover = Time.timeSinceLevelLoad  + 4.8f;
        else
        animover = Time.timeSinceLevelLoad  + 5.8f;

             }
            else{
                
             animover = Time.timeSinceLevelLoad  + 9f;
            }
            onetime = true;
            
            }
            if(Time.timeSinceLevelLoad  > animover&& onetime == true){
            
               transform.position = new Vector3(500f, 0.42f, 666);
                onetime = false;
            }
        }



        if(busarrived)
        {  
            if(onBoard == true){
                transform.position = (Vector3)charactersPostions[Int32.Parse(gameObject.tag)-1];
            }
            if(destinationlate){
                anim.SetBool("StartYelling", destinationlate);
            }
            else{
                anim.SetBool("StartDancing", busarrived);
            }
             
        }



    }
}