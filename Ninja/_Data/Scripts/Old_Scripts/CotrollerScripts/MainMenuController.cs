using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    private void Awake()
    {
       
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    } 
    public void SettingLevelMenu()
    {
        SceneManager.LoadScene(22);
    }    
    
}
