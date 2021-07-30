using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scieriegestion : MonoBehaviour
{
    public GameObject Charpenter;
    public Dropdown Crew_Dropdown;
    public TMP_Text NameTxt;
    public TMP_Text ScierieMultiplTxt;
    public bool bSellRWood = false;
    public bool bRecycleWood = false;

    private void Awake()
    {
        //DropdownValueChanged(Crew_Dropdown);
        Crew_Dropdown = GetComponent<Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        Crew_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(Crew_Dropdown);
        });
    }
    // Update is called once per frame
    void Update()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        if (Charpenter != null)
        {

            Charpenter.GetComponent<CrewGestion>().Job = CrewGestion.eJob.Scierie;
            if (!bRecycleWood)
            {
                if(Charpenter.GetComponent<CrewGestion>().Motivation > 0.90)
                {
                    GM.GetComponent<GameManager>().ScierieMultipl = (Charpenter.GetComponent<CrewGestion>().skill_Force + Charpenter.GetComponent<CrewGestion>().skill_Intel) / 2;
                }
                else if (Charpenter.GetComponent<CrewGestion>().Motivation < 0.90 && Charpenter.GetComponent<CrewGestion>().Motivation > 0.25)
                {
                    GM.GetComponent<GameManager>().ScierieMultipl = (Charpenter.GetComponent<CrewGestion>().skill_Force + Charpenter.GetComponent<CrewGestion>().skill_Intel) / 4;
                }
                else if (Charpenter.GetComponent<CrewGestion>().Motivation < 0.25)
                {
                    GM.GetComponent<GameManager>().ScierieMultipl = (Charpenter.GetComponent<CrewGestion>().skill_Force + Charpenter.GetComponent<CrewGestion>().skill_Intel) / 6;
                }
            }
            else if (bRecycleWood)
            {
                if (Charpenter.GetComponent<CrewGestion>().Motivation > 0.75)
                {
                    GM.GetComponent<GameManager>().ScierieMultipl = ((Charpenter.GetComponent<CrewGestion>().skill_Force + Charpenter.GetComponent<CrewGestion>().skill_Intel) / 2) / 2;
                }
                else if (Charpenter.GetComponent<CrewGestion>().Motivation < 0.75 && Charpenter.GetComponent<CrewGestion>().Motivation > 0.25)
                {
                    GM.GetComponent<GameManager>().ScierieMultipl = ((Charpenter.GetComponent<CrewGestion>().skill_Force + Charpenter.GetComponent<CrewGestion>().skill_Intel) / 4) / 2;
                }
                else if (Charpenter.GetComponent<CrewGestion>().Motivation < 0.25)
                {
                    GM.GetComponent<GameManager>().ScierieMultipl = ((Charpenter.GetComponent<CrewGestion>().skill_Force + Charpenter.GetComponent<CrewGestion>().skill_Intel) / 6) / 2;
                }

            }

        }

        ScierieMultiplTxt.text = GM.GetComponent<GameManager>().ScierieMultipl.ToString();
        if (GM.GetComponent<GameManager>().ScierieMultipl < 2)
        {
            ScierieMultiplTxt.color = Color.red;
        }
        if (GM.GetComponent<GameManager>().ScierieMultipl == 2)
        {
            ScierieMultiplTxt.color = Color.black;
        }
        if (GM.GetComponent<GameManager>().ScierieMultipl > 2)
        {
            ScierieMultiplTxt.color = Color.green;
        }
    }

    public void RecycleWood()
    {
        Debug.Log("Clic");
        if (bRecycleWood) bRecycleWood = false;
        else bRecycleWood = true;
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        if (bRecycleWood)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You crew start to recycled the wood ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            InvokeRepeating("RecycleWoodByTime", 10, 10);

        }
        if (!bRecycleWood)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You crew stop  to recycled the wood";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            CancelInvoke("RecycleWoodByTime");

        }
    }

    public void RecycleWoodByTime()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        if (GM.GetComponent<GameManager>().wood >= 5)
        {
            //GM.GetComponent<GameManager>().wood -= 5;
            for (int i = 0; i < GM.GetComponent<GameManager>().CrewNb; i++)
            {
                if (GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Race == CrewGestion.eRace.Human)
                {
                    GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Motivation += Random.Range(0.000f, 0.005f);
                }
                else if (GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Race == CrewGestion.eRace.Elf)
                {
                    GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Motivation += Random.Range(0.08f, 0.09f);
                }
                else if (GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Race == CrewGestion.eRace.Drawf)
                {
                    GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Motivation += Random.Range(0.00f, 0.05f);
                }
            }
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You recycled the wood  ! ";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
        }
        else if (GM.GetComponent<GameManager>().wood < 5)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You don't have enough wood !";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
        }
    }
    public void SellWood()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        Debug.Log("Clic");
        if (bSellRWood) bSellRWood = false;
        else bSellRWood = true;

        if (bSellRWood)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You start selling your Wood";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            InvokeRepeating("SellWoodbytime", 10, 10);

        }
        if (!bSellRWood)
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You stop selling your Wood";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
            CancelInvoke("SellWoodbytime");

        }
    }


    public void SellWoodbytime()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        Debug.Log("10 seconde");

        if (GM.GetComponent<GameManager>().wood >= 5)
        {
            GM.GetComponent<GameManager>().wood -= 5;
            Debug.Log("-5w");
            GM.GetComponent<GameManager>().gold += 1;
            Debug.Log(("+1o"));
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You selling your wood...";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
        }
        else
        {
            GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You don't have enough wood for sale....";
            GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
            GM.GetComponent<GameManager>().Scrollbar.value = 0;
        }
    }



    private void DropdownValueChanged(Dropdown crew_Dropdown)
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        for (int i = 0; i < GM.GetComponent<GameManager>().CrewNb; i++)
        {
            if (Crew_Dropdown.value == i)
            {
                NameTxt.text = "" + GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Name;
                Charpenter = GM.GetComponent<GameManager>().CrewList[i];
                Charpenter.GetComponent<CrewGestion>().Job = CrewGestion.eJob.Scierie;
                //GM.GetComponent<GameManager>().ScierieMultipl = (Charpenter.GetComponent<CrewGestion>().skill_Force + Charpenter.GetComponent<CrewGestion>().skill_Intel) / 4;

            }

            if (GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Job == CrewGestion.eJob.Tavern)
            {
                GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Job = CrewGestion.eJob.Tavern;
            }
            else
            {
                GM.GetComponent<GameManager>().CrewList[i].GetComponent<CrewGestion>().Job = CrewGestion.eJob.Crewmate;

            }
        }
    }
}
