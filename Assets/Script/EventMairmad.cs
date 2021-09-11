using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EventMairmad : MonoBehaviour
{
    public GameObject CrewMember;
    public GameObject WinPanel;
    public GameObject FailPanel;
    public GameObject GM;

    public TMP_Text Description;
    public TMP_Text Btn_Rum_Text;
    public TMP_Text Btn_Wood_Text;
    public TMP_Text Btn_Fight_Text;
    public TMP_Text Dice_Txt;

    public Button btnWood;
    public Button btnrum;
    public Button battaque;

    public int ChanceOFWin;


    public void Update()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        if (GM.GetComponent<GameManager>().wood < 5)
        {
            btnWood.interactable = false;
        }
        else if (GM.GetComponent<GameManager>().wood >= 5)
        {
            btnWood.interactable = true;
        }

        if (GM.GetComponent<GameManager>().Rhum < 5)
        {
            btnrum.interactable = false;
        }
        else
        {
            btnrum.interactable = true;
        }
    }
    // Start is called before the first frame update
    public void OnEnable()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        CrewMember = GM.GetComponent<GameManager>().CrewList[Random.Range(0, GM.GetComponent<GameManager>().CrewList.Count)];
        Description.text = 
        "Captain? Do you hear that? It's the siren song! We should offer them something .... Maybe they will give us a present!  Or we can push them away";
        Btn_Wood_Text.text = "Mermaids need wood !";
        Btn_Rum_Text.text = "I'm sure they love rum ! ";
        Btn_Fight_Text.text = "Get them off my island !";
        CrewMember = GM.GetComponent<GameManager>().CrewList[Random.Range(0, GM.GetComponent<GameManager>().CrewList.Count)];
        ChanceOFWin = ((CrewMember.GetComponent<CrewGestion>().skill_Charisme + CrewMember.GetComponent<CrewGestion>().skill_Charisme) / 2) * 10;
    }

    void OnDisable()
    {
        CrewMember = null;
        //Dice_Txt.text = "";
        //Dice = 0;
    }

    public void GiveWood()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        GM.GetComponent<GameManager>().wood -= 5;
        GM.GetComponent<GameManager>().gold += 10;
    }
    public void GiveRhum()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        GM.GetComponent<GameManager>().Rhum -= 5;
        GM.GetComponent<GameManager>().gold += 10;
    }
    public void attaque()
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
