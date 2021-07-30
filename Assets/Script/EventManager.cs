using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject[] EventsPanel;
    public GameObject EventBank;
    public bool IsBanqueOne = false;
    public GameObject BanqueImage;

    // Start is called before the first frame update
    void Awake()
    {

        InvokeRepeating("RandomEvent", Random.Range(50, 60), Random.Range(50, 60));
    }

    void RandomEvent()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        if (GM.GetComponent<GameManager>().IsTuto == false && GM.GetComponent<GameManager>().CurentCam == 0)
        {
            if ((GM.GetComponent<GameManager>().gold >= 0 || IsBanqueOne) && GM.GetComponent<GameManager>().CrewNb >= 1 && GM.GetComponent<GameManager>().IsOnExpedition == false)
            {
                Time.timeScale = 0;
                EventsPanel[Random.Range(0, EventsPanel.Length)].SetActive(true);
            }
            else if ((GM.GetComponent<GameManager>().gold < 0 && !IsBanqueOne) && GM.GetComponent<GameManager>().IsOnExpedition == false)
            {
                //Debug.Log("Banque : on");
                Time.timeScale = 0;
                BanqueImage.SetActive(true);
                EventBank.SetActive(true);
                IsBanqueOne = true;
            }
        }



    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
