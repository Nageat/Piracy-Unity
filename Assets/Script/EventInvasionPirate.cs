using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EventInvasionPirate : MonoBehaviour
{
    public GameObject CrewMember;
    public GameObject WinPanel;
    public GameObject FailPanel;

    public TMP_Text Description;
    public TMP_Text Btn_Yes_Text;
    //public TMP_Text Btn_No_Text;
    public TMP_Text Dice_Txt;
    public int ChanceOFWin;
    public void OnEnable()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        CrewMember = GM.GetComponent<GameManager>().CrewList[Random.Range(0, GM.GetComponent<GameManager>().CrewList.Count)];
        ChanceOFWin = ((CrewMember.GetComponent<CrewGestion>().skill_Charisme + CrewMember.GetComponent<CrewGestion>().skill_Charisme) / 2) * 10;

        Description.text = "Captain! Black sails on the horizon and they're not ours! It's the crew of Purple Beard. the most ruthless of all pirates..... They want five golds coins to leave us in peace. ";
        Btn_Yes_Text.text = "Send " + CrewMember.GetComponent<CrewGestion>().Name + " to negotiation (" + ChanceOFWin + " %)";
    }
    void OnDisable()
    {
        CrewMember = null;
        Dice_Txt.text = "";
        //Dice = 0;
    }

    public void DiceRoll()
    {
        int Dice;
        Dice = Random.Range(1, 100);
        if (Dice <= ChanceOFWin)
        {
            DiceWin(Dice);
        }
        else
        {
            DiceFail(Dice);
        }
    }

    void DiceFail(int Dice)
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        FailPanel.SetActive(true);
        Dice_Txt.text = "" + Dice;
        Dice_Txt.color = Color.red;
        GM.GetComponent<GameManager>().gold -= 5;
    }
    void DiceWin(int Dice)
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        WinPanel.SetActive(true);
        Dice_Txt.text = "" + Dice;
        Dice_Txt.color = Color.green;

    }
}
