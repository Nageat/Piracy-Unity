using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Taverngestion : MonoBehaviour
{
    public GameObject tavernKeeper;
    public Dropdown Crew_Dropdown;
    public TMP_Text NameTxt;
    public TMP_Text TavernMultiplTxt;
    public bool bSellRum = false;
    public bool bDrinkRum = false;

    private void Awake()
    {
        //DropdownValueChanged(Crew_Dropdown);
        Crew_Dropdown = GetComponent<Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        Crew_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(Crew_Dropdown);
        });
    }
    public void Update()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        if (tavernKeeper != null)
        {
            tavernKeeper.GetComponent<CrewGestion>().Job = CrewGestion.eJob.Tavern;
            if (!bDrinkRum)
            {
                if (tavernKeeper.GetComponent<CrewGestion>().Motivation >= 0.90)
                {
                    GM.GetComponent<GameManager>().TavernMultipl = (tavernKeeper.GetComponent<CrewGestion>().skill_Agil + tavernKeeper.GetComponent<CrewGestion>().skill_Charisme) / 2;
                }
                else if (tavernKeeper.GetComponent<CrewGestion>().Motivation < 0.90 && tavernKeeper.GetComponent<CrewGestion>().Motivation > 0.25)
                {
                    GM.GetComponent<GameManager>().TavernMultipl = (tavernKeeper.GetComponent<CrewGestion>().skill_Agil + tavernKeeper.GetComponent<CrewGestion>().skill_Charisme) / 4;
                }
                else if (tavernKeeper.GetComponent<CrewGestion>().Motivation < 0.25)
                {
                    GM.GetComponent<GameManager>().TavernMultipl = (tavernKeeper.GetComponent<CrewGestion>().skill_Agil + tavernKeeper.GetComponent<CrewGestion>().skill_Charisme) / 6;
                }
            }
            else if (bDrinkRum)
            {
                if (tavernKeeper.GetComponent<CrewGestion>().Motivation > 0.90)
                {
                    GM.GetComponent<GameManager>().TavernMultipl = ((tavernKeeper.GetComponent<CrewGestion>().skill_Agil + tavernKeeper.GetComponent<CrewGestion>().skill_Charisme) / 2) /2;
                }
                else if (tavernKeeper.GetComponent<CrewGestion>().Motivation < 0.90 && tavernKeeper.GetComponent<CrewGestion>().Motivation > 0.25)
                {
                    GM.GetComponent<GameManager>().TavernMultipl = ((tavernKeeper.GetComponent<CrewGestion>().skill_Agil + tavernKeeper.GetComponent<CrewGestion>().skill_Charisme) / 4)/2;
                }
                else if (tavernKeeper.GetComponent<CrewGestion>().Motivation < 0.25)
                {
                    GM.GetComponent<GameManager>().TavernMultipl = ((tavernKeeper.GetComponent<CrewGestion>().skill_Agil + tavernKeeper.GetComponent<CrewGestion>().skill_Charisme) / 6) / 2;
                }
            }
        }

        TavernMultiplTxt.text = GM.GetComponent<GameManager>().TavernMultipl.ToString();
        if (GM.GetComponent<GameManager>().TavernMultipl < 2)
        {
            TavernMultiplTxt.color = Color.red;
        }
        if (GM.GetComponent<GameManager>().TavernMultipl == 2)
        {
            TavernMultiplTxt.color = Color.black;
        }
        if (GM.GetComponent<GameManager>().TavernMultipl > 2)
        {
            TavernMultiplTxt.color = Color.green;
        }
    }
    public void RoundOfDrinks()
    {
        Debug.Log("Clic");
        if (bDrinkRum) bDrinkRum = false;
        else bDrinkRum = true;

        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        if (bDrinkRum)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You crew start to drink the rum";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            InvokeRepeating("RoundOfDrinksByTime", 10, 10);

        }
        if (!bDrinkRum)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You crew stop to drink the rum";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            CancelInvoke("RoundOfDrinksByTime");
        }
        /*
 */
    }
    public void RoundOfDrinksByTime()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        if (GM.GetComponent<GameManager>().Rhum >= 5)
        {
            //GM.GetComponent<GameManager>().Rhum -= 5;
            for (int i = 0; i < GM.GetComponent<GameManager>().CrewNb; i++)
            {
                if (GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Race == CrewGestion.eRace.Human)
                {
                    GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Motivation += Random.Range(0.05f, 0.10f);
                }
                else if (GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Race == CrewGestion.eRace.Elf)
                {
                    GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Motivation += Random.Range(0.00f, 0.01f);
                }
                else if (GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Race == CrewGestion.eRace.Drawf)
                {
                    GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Motivation += Random.Range(0.10f, 0.15f);
                }
            }
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You made a Round Of Drinks ! ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
        }
        else if (GM.GetComponent<GameManager>().Rhum < 5)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You don't have enough rum !";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
        }
    }
    public void SellRum()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        Debug.Log("Clic");
        if (bSellRum) bSellRum = false;
        else bSellRum = true;

        if (bSellRum)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You start selling your rum";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            InvokeRepeating("SellRumbytime", 10, 10);

        }
        if (!bSellRum)
        {   
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You stop selling your rum";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            CancelInvoke("SellRumbytime");

        }


    }
    public void SellRumbytime()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        Debug.Log("10 seconde");

        if (GM.GetComponent<GameManager>().Rhum >= 5)
        {
            GM.GetComponent<GameManager>().Rhum -= 5;
            Debug.Log("-5r");
            GM.GetComponent<GameManager>().gold += 1;
            Debug.Log(("+1o"));
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You selling your rum...";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
        }
        else
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You don't have enough rum for sale....";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
        }
    }

    private void DropdownValueChanged(Dropdown crew_Dropdown)
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

//        Debug.Log("Valeur :" + GM.GetComponent<GameManager>().CrewList[0].GetComponent<CrewGestion>().Name);

        for (int i = 0; i < GM.GetComponent<GameManager>().CrewNb; i++)
        {
            if (Crew_Dropdown.value == i)
            {
                NameTxt.text = "" + GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Name;
                tavernKeeper = GM.GetComponent<GameManager>().CrewList[i];
                tavernKeeper.GetComponent<CrewGestion>().Job = CrewGestion.eJob.Tavern;

            }

            if (GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Job == CrewGestion.eJob.Scierie)
            {
                GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Job = CrewGestion.eJob.Scierie;
            }
            else
            {
                GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Job = CrewGestion.eJob.Crewmate;

            }
        }
    }
}
