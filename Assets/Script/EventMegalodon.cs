using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventMegalodon : MonoBehaviour
{
    public GameObject CrewMember;
    public TMP_Text Description;
    public TMP_Text Btn_Yes_Text;
    public TMP_Text Dice_Txt;
    public int ChanceOFWin;
    public GameObject WinPanel;
    public GameObject FailPanel;
    // Start is called before the first frame update
    public void OnEnable()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        CrewMember = GM.GetComponent<GameManager>().CrewList[Random.Range(0, GM.GetComponent<GameManager>().CrewList.Count)];
        ChanceOFWin = ((CrewMember.GetComponent<CrewGestion>().skill_Agil + CrewMember.GetComponent<CrewGestion>().skill_Force) / 2) *10;

        Description.text = "One of your sailors, " + CrewMember.GetComponent<CrewGestion>().Name + "said he saw a megalodon off the coast of our island ! \nMegalodon meat is very profitable.... ";
        Btn_Yes_Text.text = "Send " + CrewMember.GetComponent<CrewGestion>().Name + " to the megalodon hunt (" + ChanceOFWin +" %)";
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
        GM.GetComponent<GameManager>().wood -= 10;
    }
    void DiceWin(int Dice)
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        WinPanel.SetActive(true);
        Dice_Txt.text = ""+Dice;
        Dice_Txt.color = Color.green;
        GM.GetComponent<GameManager>().gold += 5;
    }
}
