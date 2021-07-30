using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class crewdisplay : MonoBehaviour
{
    public Dropdown Crew_Dropdown;

    public TMP_Text NameTxt;
    public TMP_Text MotivTxt;
    public TMP_Text ChariTxt;
    public TMP_Text ForceTxT;
    public TMP_Text IntelTxT;
    public TMP_Text AgilTxT;

    public GameObject BackPanel;

    public Image ImageSprit;
    private bool init = true;
    private void Awake()
    {
        //DropdownValueChanged(Crew_Dropdown);
        Crew_Dropdown = GetComponent<Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        Crew_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(Crew_Dropdown);
        });
    }
    public void Update()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        if(GM.GetComponent<GameManager>().CrewNb == 0)
        {
            BackPanel.SetActive(false);
        }
        else
        {
            BackPanel.SetActive(true);
            if (init)
            {
                NameTxt.text = "" + GM.GetComponent<GameManager>().CrewList[0].GetComponent<CrewGestion>().Name;
                MotivTxt.text = "Motivation : " + Mathf.Round(GM.GetComponent<GameManager>().CrewList[0].GetComponent<CrewGestion>().Motivation * 100) + " %";
                ChariTxt.text = "Charisma : " + GM.GetComponent<GameManager>().CrewList[0].GetComponent<CrewGestion>().skill_Charisme;
                AgilTxT.text = "Agility : " + GM.GetComponent<GameManager>().CrewList[0].GetComponent<CrewGestion>().skill_Agil;
                ForceTxT.text = "Strength : " + GM.GetComponent<GameManager>().CrewList[0].GetComponent<CrewGestion>().skill_Force;
                IntelTxT.text = "Intelligence : " + GM.GetComponent<GameManager>().CrewList[0].GetComponent<CrewGestion>().skill_Intel;
                ImageSprit.sprite = GM.GetComponent<GameManager>().CrewList[0].GetComponent<SpriteRenderer>().sprite;
                init = false;
            }
        }
    }
    void DropdownValueChanged(Dropdown Crew_Dropdown)
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        Debug.Log("Valeur :" + GM.GetComponent<GameManager>().CrewList[0].GetComponent<CrewGestion>().Name);

        for (int i = 0; i < GM.GetComponent<GameManager>().CrewNb + 1; i++)
        {
            if (Crew_Dropdown.value == i)
            {
                NameTxt.text = "" + GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Name;
                MotivTxt.text = "Motivation : " + Mathf.Round(GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Motivation * 100) + " %";
                ChariTxt.text = "Charisma : " + GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().skill_Charisme;
                AgilTxT.text = "Agility : " + GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().skill_Agil;
                ForceTxT.text = "Strength : " + GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().skill_Force;
                IntelTxT.text = "Intelligence : " + GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().skill_Intel;
                ImageSprit.sprite = GM.GetComponent<GameManager>().CrewList[i].GetComponent<SpriteRenderer>().sprite;
            }
        }

            /*
            switch (Crew_Dropdown.value)
            {
                case 0:
                    NameTxt.text = ""+ GM.GetComponent<GameManager>().CrewList[0].GetComponent<CrewGestion>().Name;
                    MotivTxt.text = "Motivation : " + GM.GetComponent<GameManager>().CrewList[0].GetComponent<CrewGestion>().Motivation * 100;
                    ChariTxt.text = "Charisma : " + GM.GetComponent<GameManager>().CrewList[0].GetComponent<CrewGestion>().skill_Charisme;
                    AgilTxT.text = "Agility : " + GM.GetComponent<GameManager>().CrewList[0].GetComponent<CrewGestion>().skill_Agil;
                    ForceTxT.text = "Strength : " + GM.GetComponent<GameManager>().CrewList[0].GetComponent<CrewGestion>().skill_Force;
                    IntelTxT.text = "Intelligence : " + GM.GetComponent<GameManager>().CrewList[0].GetComponent<CrewGestion>().skill_Intel;
                    ImageSprit.sprite =  GM.GetComponent<GameManager>().CrewList[0].GetComponent<SpriteRenderer>().sprite;
                    //ImageSprit.spriteRenderer.sprite = GM.GetComponent<GameManager>().CrewList[0].GetComponent<SpriteRenderer>();
                    break;
                case 1:
                    NameTxt.text = "" + GM.GetComponent<GameManager>().CrewList[1].GetComponent<CrewGestion>().Name;
                    MotivTxt.text = "Motivation :" + GM.GetComponent<GameManager>().CrewList[1].GetComponent<CrewGestion>().Motivation * 100;
                    ChariTxt.text = "Charisma :" + GM.GetComponent<GameManager>().CrewList[1].GetComponent<CrewGestion>().skill_Charisme;
                    AgilTxT.text = "Agility :" + GM.GetComponent<GameManager>().CrewList[1].GetComponent<CrewGestion>().skill_Agil;
                    ForceTxT.text = "Strength :" + GM.GetComponent<GameManager>().CrewList[1].GetComponent<CrewGestion>().skill_Force;
                    ForceTxT.text = "Intelligence :" + GM.GetComponent<GameManager>().CrewList[1].GetComponent<CrewGestion>().skill_Intel;
                    ImageSprit.sprite = GM.GetComponent<GameManager>().CrewList[1].GetComponent<SpriteRenderer>().sprite;
                    break;
                default:
                    Debug.Log("DROPDOWN BUG");
                    break;
            }*/
        }


}

