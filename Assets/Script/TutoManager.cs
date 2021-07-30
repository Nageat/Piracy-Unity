using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoManager : MonoBehaviour
{
    [TextArea(5, 10)]
    public string[] TxtDial;
    public int tutostat = 0;
    public int CPT_Tuto = 0;
    public TMP_Text Text_Tuto;
    public Button btn_Store;
    public Button btn_Scierie;
    public Button btn_Taverne;
    public Button btn_port;
    public Button btn_Crew;
    public Button btn_House;

    // Start is called before the first frame update


    private void OnDisable()
    {
        switch (tutostat)
        {
            case 0:
                btn_House.interactable = true;
                btn_Store.interactable = true;
                btn_Taverne.interactable = false;
                btn_Scierie.interactable = false;
                btn_Crew.interactable = false;
                btn_port.interactable = false;
                Debug.Log("TUTO 0");
                break;
            case 1:
                btn_House.interactable = false;
                btn_Store.interactable = true;
                btn_Taverne.interactable = false;
                btn_Scierie.interactable = false;
                btn_Crew.interactable = true;
                btn_port.interactable = false;
                Debug.Log("TUTO 1");
                break;
            case 2:
                btn_House.interactable = false;
                btn_Store.interactable = true;
                btn_Taverne.interactable = true;
                btn_Scierie.interactable = true;
                btn_Crew.interactable = false;
                btn_port.interactable = false;
                break;
            case 3:
                btn_House.interactable = false;
                btn_Store.interactable = false;
                btn_Taverne.interactable = false;
                btn_Scierie.interactable = false;
                btn_Crew.interactable = false;
                btn_port.interactable = false;
                break;
            case 4:
                btn_House.interactable = true;
                btn_Store.interactable = true;
                btn_Taverne.interactable = true;
                btn_Scierie.interactable = true;
                btn_Crew.interactable = true;
                btn_port.interactable = true;
                break;
        }
    }
    void Update()
    {
        Text_Tuto.SetText("" + TxtDial[CPT_Tuto]);
    }
    public void OpenTuto()
    {
        gameObject.SetActive(true);

    }
    public void CloseTuto()
    {
        if (CPT_Tuto == 2 || CPT_Tuto == 6 || CPT_Tuto == 10 || CPT_Tuto == 14 || CPT_Tuto == 18 || CPT_Tuto == 20 || CPT_Tuto == 22)
        {
            gameObject.SetActive(false);
        }
        CPT_Tuto++;

    }
    public void SkipTuto()
    {
        tutostat = 4;
        CPT_Tuto = 18;
        CloseTuto();
        gameObject.SetActive(false);
    }
}
