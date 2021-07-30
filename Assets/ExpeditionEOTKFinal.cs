using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpeditionEOTKFinal : MonoBehaviour
{

    [TextArea(5, 10)]
    public string[] TxtDial;
    public int CPT_Dial = 0;
    public bool win;
    public int random;
    public int ChanceOFWin;
    public TMP_Text Text_TxtDial;
    public GameObject Txt_Panel;
    public GameObject Btn_Laws;

    public TMP_Text Txt_Name;
    public ExpeditionEyeOfTheKraken ExpeditionKrakenScript;


    public void OnEnable()
    {
        Text_TxtDial.color = Color.black;

        random = Random.Range(1, 100);
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        StartCoroutine(Timer());
        GM.GetComponent<GameManager>().IsOnExpedition = true;
        Text_TxtDial.SetText("" + TxtDial[0]);
        Txt_Panel.SetActive(true);
        ChanceOFWin = ((ExpeditionKrakenScript.GetComponent<ExpeditionEyeOfTheKraken>().CurrenCapitain.GetComponent<CrewGestion>().skill_Force
            +
            ExpeditionKrakenScript.GetComponent<ExpeditionEyeOfTheKraken>().CurrenCapitain.GetComponent<CrewGestion>().skill_Charisme) / 2) * 10;
    }

    public void Update()
    {
        Text_TxtDial.SetText("" + TxtDial[CPT_Dial]);
        if (ExpeditionKrakenScript.GetComponent<ExpeditionEyeOfTheKraken>().CurrenCapitain.GetComponent<CrewGestion>().Name != null)
        {
            Txt_Name.SetText("Diary of : " + ExpeditionKrakenScript.GetComponent<ExpeditionEyeOfTheKraken>().CurrenCapitain.GetComponent<CrewGestion>().Name);
        }


    }

    public void nextDial()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        if (ExpeditionKrakenScript.GetComponent<ExpeditionEyeOfTheKraken>().CurrenCapitain == null)
        {
            ExpeditionKrakenScript.GetComponent<ExpeditionEyeOfTheKraken>().CurrenCapitain = GM.GetComponent<GameManager>().CrewList[0];
            Debug.Log("Il y a un eu  soucis avec le CurrenCapitain, affectation du matelot en position 0");
        }
        random = Random.Range(1, 100);
        ChanceOFWin = ((ExpeditionKrakenScript.GetComponent<ExpeditionEyeOfTheKraken>().GetComponent<ExpeditionEyeOfTheKraken>().CurrenCapitain.GetComponent<CrewGestion>().skill_Force + 1) * 10);
        if (ChanceOFWin >= random && CPT_Dial == 2)
        {
            Text_TxtDial.color = Color.green;
            TxtDial[3] = "haha we got it! Right in the eye! Come on guys, cut a tantacula and bring it back to the boss! He will be happy!  ";
            win = true;

        }
        else if (ChanceOFWin < random && CPT_Dial == 2)
        {
            Text_TxtDial.color = Color.red;
            TxtDial[3] = "We're out of balls, guys! Damn it, we have to go! But just know, you guys, that we will be back!";
            win = false;
        }
        StartCoroutine(Timer());
        if (!win && CPT_Dial == 3)
        {
            ExpeditionKrakenScript.GetComponent<ExpeditionEyeOfTheKraken>().Stats = 3;
            ExpeditionKrakenScript.GetComponent<ExpeditionEyeOfTheKraken>().Checkevent();
            GM.GetComponent<GameManager>().IsOnExpedition = false;
            CPT_Dial = 0;
            //ExpeditionPirateQueenScript.GetComponent<GameObject>().SetActive(false);
            this.gameObject.SetActive(false);

        }
        else if (win && CPT_Dial == 3)
        {
            ExpeditionKrakenScript.GetComponent<ExpeditionEyeOfTheKraken>().Stats = 6;
            ExpeditionKrakenScript.GetComponent<ExpeditionEyeOfTheKraken>().Checkevent();
            // ExpeditionPirateQueenScript.GetComponent<GameObject>().SetActive(false);
            CPT_Dial = 0;

            GM.GetComponent<GameManager>().IsOnExpedition = false;

            this.gameObject.SetActive(false);
            Btn_Laws.SetActive(true);
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
