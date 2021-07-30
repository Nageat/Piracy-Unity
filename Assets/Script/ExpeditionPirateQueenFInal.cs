using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpeditionPirateQueenFInal : MonoBehaviour
{
    [TextArea(5, 10)]
    public string[] TxtDial;
    public int CPT_Dial = 0;
    public bool win;
    public int random;
    public int ChanceOFWin;
    public TMP_Text Text_TxtDial;
    public GameObject Txt_Panel;
    public GameObject Btn_Traderoad;

    public TMP_Text Txt_Name;
    public ExpeditionPirateQueen ExpeditionPirateQueenScript;


    public void OnEnable()
    {
        Text_TxtDial.color = Color.black;

        random = Random.Range(1, 100);
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        StartCoroutine(Timer());
        GM.GetComponent<GameManager>().IsOnExpedition = true;
        Text_TxtDial.SetText("" + TxtDial[0]);
        Txt_Panel.SetActive(true);
        ChanceOFWin = ((ExpeditionPirateQueenScript.GetComponent<ExpeditionPirateQueen>().CurrenCapitain.GetComponent<CrewGestion>().skill_Force 
            +
            ExpeditionPirateQueenScript.GetComponent<ExpeditionPirateQueen>().CurrenCapitain.GetComponent<CrewGestion>().skill_Charisme) /2) * 10;
    }

    public void Update()
    {
        Text_TxtDial.SetText("" + TxtDial[CPT_Dial]);
        if (ExpeditionPirateQueenScript.GetComponent<ExpeditionPirateQueen>().CurrenCapitain.GetComponent<CrewGestion>().Name != null)
        {
            Txt_Name.SetText("Diary of : " + ExpeditionPirateQueenScript.GetComponent<ExpeditionPirateQueen>().CurrenCapitain.GetComponent<CrewGestion>().Name);
        }

      
    }

    public void nextDial()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        if (ExpeditionPirateQueenScript.GetComponent<ExpeditionPirateQueen>().CurrenCapitain == null)
        {
            ExpeditionPirateQueenScript.GetComponent<ExpeditionPirateQueen>().CurrenCapitain = GM.GetComponent<GameManager>().CrewList[0];
            Debug.Log("Il y a un eu  soucis avec le CurrenCapitain, affectation du matelot en position 0");
        }
        random = Random.Range(1, 100);
        ChanceOFWin = ((ExpeditionPirateQueenScript.GetComponent<ExpeditionPirateQueen>().GetComponent<ExpeditionPirateQueen>().CurrenCapitain.GetComponent<CrewGestion>().skill_Force + 1) * 10);
        if (ChanceOFWin >= random && CPT_Dial == 2)
        {
            Text_TxtDial.color = Color.green;
            TxtDial[3] = "day 14 \nWe saw David Jaunne's boat in the distance! It was an epic fight ! I knocked out some of his crew and we caught that traitor David Jaunne ! The Expedition is a success !  ";
            win = true;

        }
        else if (ChanceOFWin < random && CPT_Dial == 2)
        {
            Text_TxtDial.color = Color.red;
            TxtDial[3] = "day 14 \nWe saw David Jaunne's boat in the distance! It's a disaster, a lot of our guys got hurt.... The expedition is failed ";
            win = false;
        }
        StartCoroutine(Timer());
        if (!win && CPT_Dial == 3)
        {
            ExpeditionPirateQueenScript.GetComponent<ExpeditionPirateQueen>().Stats = 3;
            ExpeditionPirateQueenScript.GetComponent<ExpeditionPirateQueen>().Checkevent();
            GM.GetComponent<GameManager>().IsOnExpedition = false;
            CPT_Dial = 0;
            //ExpeditionPirateQueenScript.GetComponent<GameObject>().SetActive(false);
            this.gameObject.SetActive(false);

        }
        else if (win && CPT_Dial == 3)
        {
            ExpeditionPirateQueenScript.GetComponent<ExpeditionPirateQueen>().Stats = 6;
            ExpeditionPirateQueenScript.GetComponent<ExpeditionPirateQueen>().Checkevent();
            // ExpeditionPirateQueenScript.GetComponent<GameObject>().SetActive(false);
            CPT_Dial = 0;

            GM.GetComponent<GameManager>().IsOnExpedition = false;

            this.gameObject.SetActive(false);
            Btn_Traderoad.SetActive(true);
        }
        CPT_Dial++;
    }

    IEnumerator Timer()
    {
        Txt_Panel.SetActive(false);
        yield return new WaitForSeconds(1);
        Txt_Panel.SetActive(true);


    }
}
