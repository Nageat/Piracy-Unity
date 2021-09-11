using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class devconsol : MonoBehaviour
{
    public TMP_InputField Consol;
    public GameObject[] enable;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void checkcode()
    {
        Debug.Log("CODE");
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        if (Consol.text == "gold")
        {
            GM.GetComponent<GameManager>().gold += 5;
            Consol.text = "";
        }
        if (Consol.text == "gold+")
        {
            GM.GetComponent<GameManager>().gold += 50;
            Consol.text = "";
        }
        if (Consol.text == "gold-")
        {
            GM.GetComponent<GameManager>().gold -= 50;
            Consol.text = "";
        }
        if (Consol.text == "rum")
        {
            GM.GetComponent<GameManager>().Rhum += 5;
            Consol.text = "";
        }
        if (Consol.text == "rum+")
        {
            GM.GetComponent<GameManager>().Rhum += 50;
            Consol.text = "";
        }
        if (Consol.text == "rum-")
        {
            GM.GetComponent<GameManager>().Rhum -= 50;
            Consol.text = "";
        }
        if (Consol.text == "wood")
        {
            GM.GetComponent<GameManager>().wood += 5;
            Consol.text = "";
        }
        if (Consol.text == "wood+")
        {
            GM.GetComponent<GameManager>().wood += 50;
            Consol.text = "";
        }
        if (Consol.text == "wood-")
        {
            GM.GetComponent<GameManager>().wood -= 50;
            Consol.text = "";
        }
        if (Consol.text == "treasure")
        {
            GM.GetComponent<GameManager>().wood = 500;
            GM.GetComponent<GameManager>().Rhum = 500;
            GM.GetComponent<GameManager>().gold = 500;

            Consol.text = "";
        }
        if (Consol.text == "happy")
        {
            GM.GetComponent<GameManager>().GlobalMotivation += 999;
            GM.GetComponent<GameManager>().Ishappycheat = true;
            Consol.text = "";
        }
        if (Consol.text == "unhappy")
        {
            GM.GetComponent<GameManager>().GlobalMotivation = 0;
            GM.GetComponent<GameManager>().Ishappycheat = false;
            Consol.text = "";
        }
        if (Consol.text == "crew")
        {
            GM.GetComponent<GameManager>().CrewNb += 1;
            Consol.text = "";
        }
        if (Consol.text == "crew+")
        {
            GM.GetComponent<GameManager>().CrewNb = 20;
            Consol.text = "";
        }
        if (Consol.text == "crewspawn")
        {
            GM.GetComponent<GameManager>().gold++;
            GM.GetComponent<GameManager>().CrewNb = (GM.GetComponent<GameManager>().HouseNb * GM.GetComponent<GameManager>().PlaceParHouse) - 1;
            GM.GetComponent<GameManager>().buyCrew();
            Consol.text = "";
        }
        
        if (Consol.text == "clear")
        {
            GM.GetComponent<GameManager>().ClearTxt();
            Consol.text = "";
        }
        if (Consol.text== "enable")
        {
            for (int i = 0; i < enable.Length; i++)
            {
                enable[i].SetActive(true);
            }
            Consol.text = "";

        }


    }
}
