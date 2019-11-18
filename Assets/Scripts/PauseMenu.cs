using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject pausemenu;
  
    public bool resume = false;
    public void ToMainMenu()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    

    public void ResumeGame()
    {
        Time.timeScale = 1;
      
        pausemenu.SetActive(false);
        resume = true;
       
    }
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
