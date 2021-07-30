using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EventLevelUp : MonoBehaviour
{
    public GameObject CrewMember;
    public GameObject[] ArrayOfBtn;
    public GameObject Btn_Close;
    public TMP_Text Description;
    public TMP_Text TxtAgili;
    public TMP_Text TxtForce;
    public TMP_Text TxtCharism;
    public TMP_Text TxtIntel;

    //public TMP_Text Btn_No_Text;
    public void OnEnable()
    {

        ArrayOfBtn[0].SetActive(true);
        ArrayOfBtn[1].SetActive(true);
        ArrayOfBtn[2].SetActive(true);
        ArrayOfBtn[3].SetActive(true);

        Btn_Close.SetActive(false);
        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        CrewMember = GM.GetComponent<GameManager>().CrewList[Random.Range(0, GM.GetComponent<GameManager>().CrewList.Count)];

        Description.text = "Captain ! " + CrewMember.GetComponent<CrewGestion>().Name + "has made a lot of progress! Which of his skills do you want him to improve on?";
    }
    void OnDisable()
    {
        CrewMember = null;
        Btn_Close.SetActive(false);

        //Dice_Txt.text = "";
        //Dice = 0;
    }

    private void Update()
    {
        TxtAgili.text = "Agility : " + CrewMember.GetComponent<CrewGestion>().skill_Agil;
        TxtForce.text = "Strength : " + CrewMember.GetComponent<CrewGestion>().skill_Force;
        TxtCharism.text = "Charism : " + CrewMember.GetComponent<CrewGestion>().skill_Charisme;
        TxtIntel.text = "Inteligence : " + CrewMember.GetComponent<CrewGestion>().skill_Agil;

    }

    public void UpAgility()
    {
        if (CrewMember.GetComponent<CrewGestion>().skill_Agil < 10)
        {
            CrewMember.GetComponent<CrewGestion>().skill_Agil += 1;
            DisableBtn();

        }
    }
    public void UpStrength()
    {
        if (CrewMember.GetComponent<CrewGestion>().skill_Force < 10)
        {
            CrewMember.GetComponent<CrewGestion>().skill_Force += 1;
            DisableBtn();

        }
    }
    public void UpCharisma()
    {
        if (CrewMember.GetComponent<CrewGestion>().skill_Charisme < 10)
        {
            CrewMember.GetComponent<CrewGestion>().skill_Charisme += 1;
            DisableBtn();

        }
    }
    public void UpIntel()
    {
        if (CrewMember.GetComponent<CrewGestion>().skill_Intel < 10)
        {
            CrewMember.GetComponent<CrewGestion>().skill_Intel += 1;
            DisableBtn();
        }
    }

    public void DisableBtn()
    {
        ArrayOfBtn[0].SetActive(false);
        ArrayOfBtn[1].SetActive(false);
        ArrayOfBtn[2].SetActive(false);
        ArrayOfBtn[3].SetActive(false);
        Btn_Close.SetActive(true);

    }

}
