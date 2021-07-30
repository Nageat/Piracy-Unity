using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ExpeditionManager : MonoBehaviour
{
    [System.Serializable]

    public enum ECurentExpedition
    {
        PirateQueen,
        EyeOfTheKraken,
        GhostShip,
        EdgeOfTheWord,
        Empty
    }
    public GameManager GM;
    public AudioManager Audio;
    public GameObject ExpeditionPanel;
    public GameObject PirateQueenPanel;
    public GameObject EyeOfTheKrakenPanel;
    public GameObject GhostShipPanel;


    public GameObject BtnNotifPirateQueen;
    public GameObject BtnNotifKraken;
    public GameObject BtnNotifGhost;


    public bool IsPirateQueenEnd = false;
    public bool IsEyeOfTheKrakenEnd = false;
    public bool IsGhostShipEnd = false;
    public bool IsEdgeOfTheWordEnd = false;

    public TMP_Text Txt_ExpeditionPirateQueen;
    public Button ExpeditionBtn;
    public Button PirateQueenBtn;
    public Button EyeOfTheKrakenBtn;
    public Button GostShipBtn;

    public ECurentExpedition CurentExpedition;

    void Start()
    {
        CurentExpedition = ECurentExpedition.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurentExpedition != ECurentExpedition.Empty)
        {
            ExpeditionBtn.interactable = false;
        }
        else
        {
            ExpeditionBtn.interactable = true;
            Txt_ExpeditionPirateQueen.text = "Expedition : None";

        }

        if (IsPirateQueenEnd)
        {
            PirateQueenBtn.interactable = false;
            EyeOfTheKrakenBtn.interactable = true;
        }
        if (IsEyeOfTheKrakenEnd)
        {
            EyeOfTheKrakenBtn.interactable = false;
            GostShipBtn.interactable = true;
        }
        if (IsGhostShipEnd)
        {
            GostShipBtn.interactable = false;

        }

    }

    public void StartPirateQueen()
    {
        if (GM.CrewNb >= 5)
        {
            PirateQueenPanel.SetActive(true);
            Txt_ExpeditionPirateQueen.text = "Expedition : The treasure of the pirate queen";
            CurentExpedition = ECurentExpedition.PirateQueen;
            Audio.AudioSwitch(1);
            ExpeditionPanel.SetActive(false);
            PirateQueenPanel.GetComponent<ExpeditionPirateQueen>().Checkevent();
        }
        else
        {
            ExpeditionPanel.SetActive(false);
            PirateQueenPanel.SetActive(false);

            GM.ScrollTxt.text = GM.ScrollTxt.text + "\n >You don't have enough crew ";
            GM.ScrollContent.sizeDelta = new Vector2(GM.ScrollContent.sizeDelta.x, GM.ScrollContent.sizeDelta.y + 25);
            GM.Scrollbar.value = 0;
        }

    }

    public void StopPirateQueen()
    {
        PirateQueenPanel.SetActive(false);
        CurentExpedition = ECurentExpedition.Empty;
        IsPirateQueenEnd = true;
        PirateQueenBtn.interactable = false;
        Audio.AudioSwitch(0);

    }


    public void TimePirateQueen()
    {
        Debug.Log("Start Timer");
        StartCoroutine(TimerNext(30));
    }

    public void TimePirateQueenReset()
    {
        Debug.Log("Start Timer reset");
        StartCoroutine(TimerReset(30));
    }
    IEnumerator TimerNext(int secs)
    {

        yield return new WaitForSeconds(secs);
        PirateQueenPanel.GetComponent<ExpeditionPirateQueen>().Stats += 1;
        BtnNotifPirateQueen.SetActive(true);//FAIRE NOTIF
        //PirateQueenPanel.GetComponent<ExpeditionPirateQueen>().Checkevent();

        Debug.Log("End Timer -> Next Steps");
    }

    IEnumerator TimerReset(int secs)
    {

        yield return new WaitForSeconds(secs);
        BtnNotifPirateQueen.SetActive(true);// FAIRE NOTIF 
        //PirateQueenPanel.GetComponent<ExpeditionPirateQueen>().Checkevent();

        Debug.Log("End Timer -> reset steps");
    }


    public void StartTheKraken()
    {
        if (GM.CrewNb >= 10)
        {
            EyeOfTheKrakenPanel.SetActive(true);
            Txt_ExpeditionPirateQueen.text = "Expedition : The eye of the kraken";
            CurentExpedition = ECurentExpedition.EyeOfTheKraken;
            Audio.AudioSwitch(2);
            ExpeditionPanel.SetActive(false);
            EyeOfTheKrakenPanel.GetComponent<ExpeditionEyeOfTheKraken>().Checkevent();
        }
        else
        {
            ExpeditionPanel.SetActive(false);
            EyeOfTheKrakenPanel.SetActive(false);

            GM.ScrollTxt.text = GM.ScrollTxt.text + "\n >You don't have enough crew ";
            GM.ScrollContent.sizeDelta = new Vector2(GM.ScrollContent.sizeDelta.x, GM.ScrollContent.sizeDelta.y + 25);
            GM.Scrollbar.value = 0;
        }

    }
    public void TimeKracken()
    {
        Debug.Log("Start Timer");
        StartCoroutine(TimerNext2(30));
    }
    IEnumerator TimerNext2(int secs)
    {

        yield return new WaitForSeconds(secs);
        EyeOfTheKrakenPanel.GetComponent<ExpeditionEyeOfTheKraken>().Stats += 1;
        BtnNotifKraken.SetActive(true);//FAIRE NOTIF
        //PirateQueenPanel.GetComponent<ExpeditionPirateQueen>().Checkevent();

        Debug.Log("End Timer -> Next Steps");
    }

    public void TimeKrackenReset()
    {
        Debug.Log("Start Timer reset");
        StartCoroutine(TimerReset2(30));
    }
    IEnumerator TimerReset2(int secs)
    {

        yield return new WaitForSeconds(secs);
        BtnNotifKraken.SetActive(true);// FAIRE NOTIF 
        //PirateQueenPanel.GetComponent<ExpeditionPirateQueen>().Checkevent();

        Debug.Log("End Timer -> reset steps");
    }

    public void StopKraken()
    {
        EyeOfTheKrakenPanel.SetActive(false);
        CurentExpedition = ECurentExpedition.Empty;
        IsEyeOfTheKrakenEnd = true;
        EyeOfTheKrakenBtn.interactable = false;
        Audio.AudioSwitch(0);
        GM.GetComponent<GameManager>().gold += 20;
    }

    public void StartTheGhostShip()
    {
        if (GM.CrewNb >= 15)
        {
            GhostShipPanel.SetActive(true);
            Txt_ExpeditionPirateQueen.text = "Expedition : The ghost ship";
            CurentExpedition = ECurentExpedition.GhostShip;
            Audio.AudioSwitch(3);
            ExpeditionPanel.SetActive(false);
            GhostShipPanel.GetComponent<ExpeditionGhostShip>().Checkevent();
        }
        else
        {
            ExpeditionPanel.SetActive(false);
            GhostShipPanel.SetActive(false);

            GM.ScrollTxt.text = GM.ScrollTxt.text + "\n >You don't have enough crew ";
            GM.ScrollContent.sizeDelta = new Vector2(GM.ScrollContent.sizeDelta.x, GM.ScrollContent.sizeDelta.y + 25);
            GM.Scrollbar.value = 0;
        }
    }

    public void TimeGhostShip()
    {
        Debug.Log("Start Timer");
        StartCoroutine(TimerNext3(30));
    }
    IEnumerator TimerNext3(int secs)
    {

        yield return new WaitForSeconds(secs);
        GhostShipPanel.GetComponent<ExpeditionGhostShip>().Stats += 1;
        BtnNotifGhost.SetActive(true);
        Debug.Log("End Timer -> Next Steps");
    }

    public void TimeGhostShipReset()
    {
        Debug.Log("Start Timer reset");
        StartCoroutine(TimerReset3(30));
    }
    IEnumerator TimerReset3(int secs)
    {

        yield return new WaitForSeconds(secs);
        BtnNotifGhost.SetActive(true);// FAIRE NOTIF 
        //PirateQueenPanel.GetComponent<ExpeditionPirateQueen>().Checkevent();

        Debug.Log("End Timer -> reset steps");
    }

}
