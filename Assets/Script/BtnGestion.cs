using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnGestion : MonoBehaviour
{
    public GameObject BtnExpedition;
    public GameObject BtnCrew;
    public GameObject BtnTavern;
    public GameObject BtnScierie;
    //public GameObject Btn
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Port(Clone)") != null)
        {
            BtnExpedition.SetActive(true);
        }
        if (GameObject.Find("House(Clone)") != null)
        {
            BtnCrew.SetActive(true);
        }
        if (GameObject.Find("Taverne(Clone)") != null)
        {
            BtnTavern.SetActive(true);
        }
        if (GameObject.Find("Scierie(Clone)") != null)
        {
            BtnScierie.SetActive(true);
        }
    }
}
