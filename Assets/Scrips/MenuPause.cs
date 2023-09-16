using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{

    private bool isActive;
    [SerializeField] private GameObject menuPause;
    [SerializeField] private ControllerRB pj1;
    [SerializeField] private ControllerRB pj2;
    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    [SerializeField] private GameObject winnerMenu;
   

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            menuPause.SetActive(false);
            winnerMenu.SetActive(false);
        }
       
    }

    void Update()
    {
        if(((Input.GetKeyDown(KeyCode.Escape) ||Input.GetKeyDown(KeyCode.KeypadMinus))  && SceneManager.GetActiveScene().buildIndex==1))
        {
            isActive = !isActive;
            menuPause.SetActive(isActive);
            if (isActive)
            {
                Pause();
            }
            else
            {
                Resume();
            }  
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 0)
        {
            QuitMenu();
        }
        if (pj1.ILive==false)
        {
            PlayerWin(2);
            pj2.SetOnPause(true);
            pj2.setNormalSpeed(0);
        }
        else if (pj2.ILive == false)
        {
            PlayerWin(1);
            pj1.SetOnPause(true);
            pj1.setNormalSpeed(0);
            
        }
      

    }


    public void Pause()
    {
        pj1.SetOnPause(true);
        pj2.SetOnPause(true);
        Time.timeScale = 0;        
    }


    public void Resume()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1;
        pj1.SetOnPause(false);
        pj2.SetOnPause(false);
    }

    public void PlayGame()
    {
        
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }

    public void PlayerWin (int ganador)
    {
         if(ganador==1)
        {
            winnerMenu.SetActive(true);
            text2.gameObject.SetActive(false);
        }
        else
        {
            winnerMenu.SetActive(true);
            text1.gameObject.SetActive(false);
        }
    }

    public void EnableWinnerMenu()
    {
            winnerMenu.gameObject.SetActive(true);
    }

    public void DisableWinnerMenu()
    {
       
            winnerMenu.gameObject.SetActive(false);
    }    

    public void QuitMenu()
    {
        Application.Quit();
    }
}
