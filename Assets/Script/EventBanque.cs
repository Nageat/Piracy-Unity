using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBanque : MonoBehaviour
{
    public bool iSBanque = false;
    public GameObject EventM;
    //public GameObject BanqueImg;
    public GameObject BanquePanel;
    public void Banque ()
    {
        StartCoroutine(BanqueGo(60));

        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        Debug.Log("Banque : Credit");
        GM.GetComponent<GameManager>().gold += 10;
        GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >Ruby, the pirate queen lent you 10 gold coins";
        GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
        GM.GetComponent<GameManager>().Scrollbar.value = 0;
    }

    public void NoBanque()
    {
        EventM.GetComponent<EventManager>().IsBanqueOne = false;

    }

    IEnumerator BanqueGo(int secs)
    {
        GameObject GM = GameObject.FindGameObjectWithTag("GM");

        yield return new WaitForSeconds(secs);
        GM.GetComponent<GameManager>().gold -= 15;
        GM.GetComponent<GameManager>().ScrollTxt.text = GM.GetComponent<GameManager>().ScrollTxt.text + "\n >You returned 15 gold coins to Ruby the pirate queen";
        GM.GetComponent<GameManager>().ScrollContent.sizeDelta = new Vector2(GM.GetComponent<GameManager>().ScrollContent.sizeDelta.x, GM.GetComponent<GameManager>().ScrollContent.sizeDelta.y + 25);
        GM.GetComponent<GameManager>().Scrollbar.value = 0;
        EventM.GetComponent<EventManager>().IsBanqueOne = false;
        BanquePanel.SetActive(false);
        Debug.Log("Banque : Off");

    }
}
