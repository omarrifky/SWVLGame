using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMovement : MonoBehaviour
{
    public bool busarrived = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log((int)Time.time);
        if(transform.position.z >= 650 && transform.position.x >= 3.6){
            busarrived = true;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if((transform.position.z <= 666 && vertical > 0) || (transform.position.z >= -11.6 && vertical < 0)){
            transform.Translate(0, 0, 10* vertical * Time.deltaTime);
            if((transform.position.x<=3.640127&& horizontal>0) || (transform.position.x >= -3.560907 && horizontal < 0))
            transform.Translate(5 * horizontal * Time.deltaTime, 0,0);  
        }
    }
}
