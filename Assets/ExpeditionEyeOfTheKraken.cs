using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpeditionEyeOfTheKraken : MonoBehaviour
{
    public int Stats = 0;
    public int GoldCheck = 0;
    public Button Goldheckbuton;
    public Button CannonCheckBtn;
    public GameObject Road;
    public TradeRoad TradeRoad;
    public GameObject[] EventOfExpedition;
    public GameObject Imgmap;
    public ExpeditionManager ExpeditionM;
    public GameObject SpecialRoad;
    public GameObject Cannon;
    public GameObject CurrenCapitain;
    public Dropdown CapitainChoice;

    public void Checkevent()
    {
        Time.timeScale = 0;
        EventOfExpedition[Stats].SetActive(true);
        if (Stats != 0)
        {
            EventOfExpedition[Stats - 1].SetActive(false);
            Debug.Log("-1");
        }
        Imgmap.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        if (GM.GetComponent<GameManager>().gold < 15)
        {
            Goldheckbuton.interactable = false;
        }
        else if (GM.GetComponent<GameManager>().gold >= 15)
        {
            Goldheckbuton.interactable = true;
        }
        if (TradeRoad.TR_Special)
        {
            CannonCheckBtn.interactable = true;
            Cannon.SetActive(true);
        }
        else
        {
            CannonCheckBtn.interactable = false;
            Cannon.SetActive(false);

        }

    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Imgmap.SetActive(false);

    }

    public void GoldCheckVoid()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        GM.GetComponent<GameManager>().gold -= 15;
        Debug.Log("-15 or");
        ExpeditionM.TimeKracken();
        Road.SetActive(true);
    }

    public void CannonCheckvoid()
    {
        Destroy(Road);
        TradeRoad.BTN_Special.isOn = false;
        TradeRoad.TR_Special = false;
        ExpeditionM.TimeKracken();
    }
    public void CapitainCheckVoid()
    {
        CurrenCapitain = CapitainChoice.GetComponent<CapitainChoice>().TempCapitain.gameObject;
        ExpeditionM.TimeKracken();
    }
    public void CapitainFinalVoid()
    {
        CurrenCapitain = CapitainChoice.GetComponent<CapitainChoice>().TempCapitain;
        //ExpeditionM.TimePirateQueen();
        Stats += 1;
        Checkevent();
    }
}
