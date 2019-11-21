using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMovement : MonoBehaviour
{
    public bool busarrived = false;
    public bool gamepaused = false;
    public GameObject pausemenu;
    Animation animationcomponent;
    // Start is called before the first frame update
    void Start()
    {
         animationcomponent =GetComponent<Animation>();
        
        
    }
    public void Pause(){

        Time.timeScale = 0;
        gamepaused = true;
        animationcomponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        print((int)Time.timeSinceLevelLoad);
        if(transform.position.z >= 666 && transform.position.x >= 3.6){
            busarrived = true;
            // animation on
            transform.position = new Vector3(0f,0.27f,666f);
            animationcomponent.enabled=true;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if((transform.position.z <= 666 && vertical > 0) || (transform.position.z >= -11.6 && vertical < 0)){
            transform.Translate(0, 0, 10* vertical * Time.deltaTime);
            if((transform.position.x<=3.640127&& horizontal>0) || (transform.position.x >= -3.560907 && horizontal < 0))
            transform.Translate(5 * horizontal * Time.deltaTime, 0,0);  
        }

        if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale ==1 ){
         pausemenu.SetActive(true);
         Pause();
        }
    }
}
