using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PirateLaws : MonoBehaviour
{
    public bool Piratesbyprofession;
    public Toggle BTN_Piratesbyprofession;

    public bool Capiratelism;
    public Toggle BTN_Capiratelism;

    public bool Militarytraining;
    public Toggle BTN_Militarytraining;

    public bool publicschool;
    public Toggle BTN_publicschool;
    public bool Boat;
    public TradeRoad sTradeRoad;
    public void PiratePro()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        Debug.Log("Clic");
        if (Piratesbyprofession) Piratesbyprofession = false;
        else Piratesbyprofession = true;

        if (Piratesbyprofession)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have implemented the 'pirate by profession' law ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            InvokeRepeating("PirateProbytime", 10, 10);
            BTN_Capiratelism.interactable = false;
        }
        if (!Piratesbyprofession)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have cancel the 'pirate by profession' law";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            CancelInvoke("PirateProbytime");
            BTN_Capiratelism.interactable = true;

        }
    }

    public void PirateProbytime()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        GameObject[] CrewObj = GameObject.FindGameObjectsWithTag("Crew");
        //Creation gameobject temp
        for (int i = 0; i < CrewObj.Length; i++)
        {
            GM.GetComponent<GameManager>().gold -= 1;
            if(CrewObj[i].GetComponent<CrewGestion>().Motivation < 0.75f)
            {
                CrewObj[i].GetComponent<CrewGestion>().Motivation += Random.Range(0.10f, 0.20f); ;
            }
        }
    }

    public void LawCapiratelism()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        Debug.Log("Clic");
        if (Piratesbyprofession) Piratesbyprofession = false;
        else Piratesbyprofession = true;

        if (Piratesbyprofession)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have implemented the 'Capiratelism' law ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            InvokeRepeating("Capiratelismbytime", 10, 10);
            BTN_Piratesbyprofession.interactable = false;
        }
        if (!Piratesbyprofession)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have cancel the 'Capiratelism' law";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            CancelInvoke("Capiratelismbytime");
            BTN_Piratesbyprofession.interactable = true;

        }
    }

    public void Capiratelismbytime()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        GameObject[] CrewObj = GameObject.FindGameObjectsWithTag("Crew");
        //Creation gameobject temp
        for (int i = 0; i < CrewObj.Length; i++)
        {
            GM.GetComponent<GameManager>().gold += 1;
            if (CrewObj[i].GetComponent<CrewGestion>().Motivation > 0.25f)
            {
                CrewObj[i].GetComponent<CrewGestion>().Motivation -= Random.Range(0.10f, 0.20f); ;
            }
        }
    }

    public void LawMilitarytraining()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        Debug.Log("Clic");
        if (Militarytraining) Militarytraining = false;
        else Militarytraining = true;

        if (Militarytraining)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have implemented the 'Military training' law ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            InvokeRepeating("Militarytrainingtime", 10, 10);
            BTN_publicschool.interactable = false;
        }
        if (!Militarytraining)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have cancel the 'Military training' law";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            CancelInvoke("Militarytrainingtime");
            BTN_publicschool.interactable = true;

        }
    }

    public void Militarytrainingtime()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        GameObject[] CrewObj = GameObject.FindGameObjectsWithTag("Crew");
        GM.GetComponent<GameManager>().gold -= 10;
        //Creation gameobject temp
        int i = Random.Range(0, CrewObj.Length);
        if (CrewObj[i].GetComponent<CrewGestion>().skill_Force < 10 && CrewObj[i].GetComponent<CrewGestion>().skill_Agil < 10)
        {
            CrewObj[i].GetComponent<CrewGestion>().skill_Force += 1;
            CrewObj[i].GetComponent<CrewGestion>().skill_Agil += 1;

        }

    }

    public void LawEcolePublic()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        Debug.Log("Clic");
        if (publicschool) publicschool = false;
        else publicschool = true;

        if (publicschool)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have implemented the 'public school' law ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            InvokeRepeating("EcolePublicbytime", 10, 10);
            BTN_Militarytraining.interactable = false;
        }
        if (!publicschool)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have cancel the 'public school' law";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            CancelInvoke("EcolePublicbytime");
            BTN_Militarytraining.interactable = true;

        }
    }

    public void EcolePublictime()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        GameObject[] CrewObj = GameObject.FindGameObjectsWithTag("Crew");
        GM.GetComponent<GameManager>().gold -= 10;
        //Creation gameobject temp
        int i = Random.Range(0, CrewObj.Length);
        if (CrewObj[i].GetComponent<CrewGestion>().skill_Intel < 10 && CrewObj[i].GetComponent<CrewGestion>().skill_Charisme < 10)
        {
            CrewObj[i].GetComponent<CrewGestion>().skill_Intel += 1;
            CrewObj[i].GetComponent<CrewGestion>().skill_Charisme += 1;

        }

    }

    public void LawBoatbuild()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        Debug.Log("Clic");
        if (Boat) Boat = false;
        else Boat = true;

        if (Boat)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have implemented the 'Boat building' law ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            InvokeRepeating("Boattime", 10, 10);
            sTradeRoad.AvalidBoat += 1;
        }
        if (!Boat)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have cancel the 'Boat building' law";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            sTradeRoad.AvalidBoat -= 1;
            CancelInvoke("Boattime");

        }
    }

    public void Boattime()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        GameObject[] CrewObj = GameObject.FindGameObjectsWithTag("Crew");
        GM.GetComponent<GameManager>().gold -= 2;

    }
}

