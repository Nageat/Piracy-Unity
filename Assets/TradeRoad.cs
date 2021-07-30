using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TradeRoad : MonoBehaviour
{
    public bool TR_Tortugua;
    public Toggle BTN_Tortugua;
    public bool TR_Donkey;
    public Toggle BTN_Donkey;
    public bool TR_Queen;
    public Toggle BTN_Queen;
    public Toggle BTN_Special;
    public bool TR_Special = false;
    public TMP_Text BoatAvalid;

    public int AvalidBoat = 1;
    public int BoatOnRoad = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BoatAvalid.text = "Boat at sea : " + BoatOnRoad + " / " + AvalidBoat;
        if (AvalidBoat == BoatOnRoad)
        {
            if (TR_Tortugua)
            {
                BTN_Donkey.interactable = false;
                BTN_Queen.interactable = false;
                BTN_Tortugua.interactable = true;
                BTN_Special.interactable = false;
            }
            if (TR_Donkey)
            {
                BTN_Donkey.interactable = true;
                BTN_Queen.interactable = false;
                BTN_Tortugua.interactable = false;
                BTN_Special.interactable = false;

            }
            if (TR_Queen)
            {
                BTN_Donkey.interactable = false;
                BTN_Queen.interactable = true;
                BTN_Tortugua.interactable = false;
                BTN_Special.interactable = false;
            }
            if (TR_Special)
            {
                BTN_Donkey.interactable = false;
                BTN_Queen.interactable = false;
                BTN_Tortugua.interactable = false;
                BTN_Special.interactable = true;
            }
        }
        else if (AvalidBoat > BoatOnRoad)
        {
            BTN_Donkey.interactable = true;
            BTN_Queen.interactable = true;
            BTN_Tortugua.interactable = true;
            BTN_Special.interactable = true;

        }
        else if (AvalidBoat < BoatOnRoad)
        {
            BTN_Donkey.isOn = false;
            BTN_Queen.isOn = false;
            BTN_Tortugua.isOn = false;
            BTN_Special.isOn = false;
        }

    }
    public void TortuguaRoad()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        Debug.Log("Clic");
        if (TR_Tortugua) TR_Tortugua = false;
        else TR_Tortugua = true;

        if (TR_Tortugua)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have started a comercial route with Tortuga ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            InvokeRepeating("TortuguaRoadbytime", 10, 10);
            BTN_Tortugua.interactable = false;
            BoatOnRoad += 1;
        }
        if (!TR_Tortugua)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have stoped a comercial route with Tortuga ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            CancelInvoke("TortuguaRoadbytime");
            BoatOnRoad -= 1;

        }
    }

    public void TortuguaRoadbytime()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        GM.GetComponent<GameManager>().gold -= 3;
        GM.GetComponent<GameManager>().Rhum += 5;
        GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have a comercial route with Tortuga ";
        GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
        GM.GetComponent<GameManager>().Scrollbar.value = 0;
        BTN_Tortugua.interactable = true;

    }
    public void DonkeyRoad()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        Debug.Log("Clic");
        if (TR_Donkey) TR_Donkey = false;
        else TR_Donkey = true;

        if (TR_Donkey)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have started a comercial route with Donkey island ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            InvokeRepeating("DonkeyRoadbytime", 10, 10);
            BTN_Donkey.interactable = false;
            BoatOnRoad += 1;

        }
        if (!TR_Donkey)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have stoped a comercial route with Donkey island ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            CancelInvoke("DonkeyRoadbytime");
            BoatOnRoad -= 1;

        }
    }

    public void DonkeyRoadbytime()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        GM.GetComponent<GameManager>().gold -= 3;
        GM.GetComponent<GameManager>().wood += 5;
        GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have a comercial route with Donkey island ";
        GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
        GM.GetComponent<GameManager>().Scrollbar.value = 0;
        BTN_Donkey.interactable = true;
    }
    public void QueenRoad()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        Debug.Log("Clic");
        if (TR_Queen) TR_Queen = false;
        else TR_Queen = true;

        if (TR_Queen)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have started a comercial route with Queen's port ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            InvokeRepeating("QueenRoadbytime", 10, 10);
            BTN_Queen.interactable = false;
            BoatOnRoad += 1;

        }
        else if (!TR_Donkey)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have stoped a comercial route with Queen's port ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            CancelInvoke("QueenRoadbytime");
            BoatOnRoad -= 1;


        }
    }

    public void QueenRoadbytime()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        if (GM.GetComponent<GameManager>().wood >= 5 && GM.GetComponent<GameManager>().Rhum >= 5)
        {
            GM.GetComponent<GameManager>().gold += 5;
            GM.GetComponent<GameManager>().wood -= 5;
            GM.GetComponent<GameManager>().Rhum -= 5;
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You have a comercial route with Queen's port ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
        }
        else
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You don't have enough wood and rum to sell in Queen's port! You are subject to a penalty of one gold";
            GM.GetComponent<GameManager>().gold -= 1;

        }
        BTN_Queen.interactable = true;

    }

    public void BtnSpecial()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        Debug.Log("Clic");
        if (TR_Special) TR_Special = false;
        else TR_Special = true;

        if (TR_Special)
        {

            BTN_Special.interactable = false;
            BoatOnRoad += 1;
            Debug.Log("Queen + 1");
            InvokeRepeating("SpecialBytime", 10, 10);

        }
        else if (!TR_Special)
        {

            BoatOnRoad -= 1;
            CancelInvoke("SpecialBytime");


        }
    }

    public void SpecialBytime()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You paye the cannon";
        GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
        GM.GetComponent<GameManager>().Scrollbar.value = 0;
        GM.GetComponent<GameManager>().gold -= 3;
    }



}
