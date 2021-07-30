using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpeditionGhostShip : MonoBehaviour
{

    public int Stats = 0;
    public GameObject[] EventOfExpedition;
    public GameObject Imgmap;
    public ExpeditionManager ExpeditionM;
    public GameObject CurrenCapitain;
    public Dropdown CapitainChoice;

    public void Checkevent()
    {
        Time.timeScale = 0;
        EventOfExpedition[Stats].SetActive(true);
        if (Stats != 0)
        {
            EventOfExpedition[Stats - 1].SetActive(false);
            Debug.Log("-1");
        }
        Imgmap.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Imgmap.SetActive(false);

    }

}
