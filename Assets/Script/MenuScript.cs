using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string Scene;
    public void doPlayeGame()
    {
        SceneManager.LoadScene(Scene, LoadSceneMode.Single);

    }
    public void doExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void doDebug()
    {
        Application.OpenURL("https://forms.office.com/r/eu5iARArBB");
    }
    
}
