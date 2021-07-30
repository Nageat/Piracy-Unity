using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ExpeditionPirateQueen : MonoBehaviour
{
    public int Stats = 0;
    public int WoodCheck = 0;
    public int JoyCheck = 0;
    public GameObject[] EventOfExpedition;
    public GameObject Imgmap;
    public GameObject CurrenCapitain;
    public Dropdown CapitainChoice;
    public Button Woodcheckbuton;
    public Button Joycheckbuton;
    public bool IsGoodEnd;
    public ExpeditionManager ExpeditionM;

    public void Checkevent()
    {
        Time.timeScale = 0;
        EventOfExpedition[Stats].SetActive(true); 
        if (Stats != 0) {
            EventOfExpedition[Stats - 1].SetActive(false);
            Debug.Log("-1");
        }
        Imgmap.SetActive(true);
    }
    public void Update()
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        if (Stats == 1)
        {
            WoodCheck = 10;
        }

        if (GM.GetComponent<GameManager>().wood < 10)
        {
            Woodcheckbuton.interactable = false;
        }
        else if (GM.GetComponent<GameManager>().wood >= 10)
        {
            Woodcheckbuton.interactable = true;
        }

        if (GM.GetComponent<GameManager>().GlobalMotivation < 0.6)
        {
            Joycheckbuton.interactable = false;
        }
        else
        {
            Joycheckbuton.interactable = true;
        }
    }

    public void WoodCheckVoid()
    {

        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        GM.GetComponent<GameManager>().wood -= 10;
        ExpeditionM.TimePirateQueen();

    }
    public void JoyCheckVoid()
    {

        GameObject GM = GameObject.FindGameObjectWithTag("GM");
        ExpeditionM.TimePirateQueen();

    }

    public void CapitainCheckVoid()
    {
        CurrenCapitain = CapitainChoice.GetComponent<CapitainChoice>().TempCapitain.gameObject;
        ExpeditionM.TimePirateQueen();
    }

    public void CapitainFinalVoid()
    {
        CurrenCapitain = CapitainChoice.GetComponent<CapitainChoice>().TempCapitain;
        //ExpeditionM.TimePirateQueen();
        Stats += 1;
        Checkevent();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Imgmap.SetActive(false);

    }
}
