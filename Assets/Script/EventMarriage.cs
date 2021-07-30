using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EventMarriage : MonoBehaviour
{
    public GameObject CrewMember;
    public TMP_Text Description;
    public TMP_Text Btn_Yes_Text;
    public TMP_Text Btn_No_Text;

    public void OnEnable()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        CrewMember = GM.GetComponent<GameManager>().CrewList[Random.Range(0, GM.GetComponent<GameManager>().CrewList.Count)];
        //ChanceOFWin = ((CrewMember.GetComponent<CrewGestion>().skill_Charisme + CrewMember.GetComponent<CrewGestion>().skill_Charisme) / 2) * 10;

        Description.text = "Capitaine ! " + CrewMember.GetComponent<CrewGestion>().Name + " has finally found his soul mate!Their wedding will take place at sea, as per pirate tradition!Should we bring rum to the wedding? It will make him happy!";
        Btn_Yes_Text.text = "Yes Rum, women and goddamn beer !";
        Btn_No_Text.text = "No, we don't care, we're not going";
    }
    void OnDisable()
    {
        CrewMember = null;
        //Dice_Txt.text = "";
        //Dice = 0;
    }

    public void yes()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        GM.GetComponent<GameManager>().Rhum -= 5;
        CrewMember.GetComponent<CrewGestion>().Motivation += 0.25f;

    }

    public void no()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        CrewMember.GetComponent<CrewGestion>().Motivation -= 0.10f;
    }
}
