using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public const int PlaceParHouse = 5;
    
    //Stats du joueur
    public int gold;
    public int Rhum;
    public int wood;
    public int tavernPrice;
    public int ScieriePrice;
    public int HousePrice;
    public float GlobalMotivation = 0;

    //Array Zone placement port et autre 
    private GameObject[] Btn;
    public GameObject[] PortZone;

    public GameObject[] TavernZone;

    public GameObject[] ScierieZone;


    public GameObject[] HouseZone;
    public List<GameObject> CrewList;


    List<GameObject> ObjectPlaced = new List<GameObject>();

    private int cpt;
    public bool IsBuymod = false;// Mode achat 
    public bool HaveAPort = false;//Check si on a un port
    public bool IsOnExpedition = false;
    public bool IsTuto = true;
    public bool Isbuyisland2 = false;
    public bool Isbuyisland3 = false;
    public int TavernNb = 0;//Nombre
    public int TavernMultipl = 1;
    public int TavernNbMax = 4;
    public int ScierieNb = 0;
    public int ScierieMultipl = 1;
    public int ScierieMax = 4;
    public int HouseNb = 0;
    public int CrewNb = 0;
    public int Modifskill = 0;
    public int CurentCam = 0;
    public GameObject BtnBuyPort;
    public GameObject Port;
    public GameObject BtnBuyTavern;
    public GameObject Tavern;
    public GameObject BtnBuySie;
    public GameObject Scierie;
    public GameObject BtnBuyHouse;
    public GameObject House;
    public GameObject Crew;
    public GameObject Island2Panel;
    public GameObject Island3Panel;
    public GameObject IslandNext;
    public GameObject IslandPrev;
    public GameObject WoodObj;
    public GameObject goldobj;
    public Transform CrewSpawn;

    public RectTransform ScrollContent;
    public Text ScrollTxt;
    public Scrollbar Scrollbar;
    public TMP_Text GoldTxt;
    public TMP_Text RhumTxt;
    public TMP_Text WoodTxt;
    public TMP_Text CrewTxt;
    public TMP_Text MoralTxt;
    public TMP_Text TavernPriceTxt;
    public TMP_Text ScieriePriceTxt;
    public TMP_Text HousePriceTxt;


    //public crewdisplay sCrewdisplay;
    public Dropdown Crew_Dropdown;
    public Dropdown Taverne_Dropdown;
    public Dropdown Scierie_Dropdown;
    public Dropdown[] Capitaine_Dropdown;

    public TutoManager Tuto;
    public cameraMove Cameras;
    public void DeactivateAllButtons()
    {

        Btn = GameObject.FindGameObjectsWithTag("MenuButton");

        foreach (GameObject button in Btn)
        {

            button.GetComponent<Button>().interactable = false;

        }

    }
    public void activateAllButtons()
    {

        Btn = GameObject.FindGameObjectsWithTag("MenuButton");

        foreach (GameObject button in Btn)
        {

            button.GetComponent<Button>().interactable = true;

        }

    }

    void Start()
    {
        ScrollContent = ScrollContent.GetComponent<RectTransform>();
        InvokeRepeating("GestionRessource", 10f, 10f);
        InvokeRepeating("GestionMotivation", 0.05f, 0.05f);
        InvokeRepeating("CheckDropdown", 1, 1);
        InvokeRepeating("CheckTuto", 1, 1);
        InvokeRepeating("ClearTxt", 120, 120);

        tavernPrice = 3;
        ScieriePrice = 3;
        HousePrice = 2;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsBuymod)
        {
            Debug.Log("MousDown");
            //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.transform.tag)
                {
                    case "ZonePort":
                        Placeport(hit);
                        break;
                    case "ZoneTavern":
                        Placetavern(hit);
                        break;
                    case "ZoneScierie":
                        PlaceScierie(hit);
                        break;
                    case "ZoneHouse":
                        PlaceHouse(hit);
                        break;
                }
                Debug.Log(hit.transform.name);
            }
        }

        if (IsBuymod)
        {
            DeactivateAllButtons();
        }
        else if (!IsBuymod && Tuto.tutostat != 3)
        {
            activateAllButtons();
        }

        GoldTxt.text = ": " + gold;
        RhumTxt.text = ": " + Rhum;
        WoodTxt.text = ": " + wood;
        CrewTxt.text = "" + CrewNb + " / " + (HouseNb * 5).ToString(); ;
        MoralTxt.text = "Moral : " + Mathf.Round(GlobalMotivation * 100) + " %";
        if (CrewNb < 1)
        {
            MoralTxt.text = "";
        }
        if (wood < 0)
        {
            wood = 0;
        }
        if (wood > 500)
        {
            wood = 500;
        }
        if (wood > 10)
        {
            WoodObj.SetActive(true);
        }else
        {
            WoodObj.SetActive(false);

        }
        if (gold > 10)
        {
            goldobj.SetActive(true);
        }
        else
        {
            goldobj.SetActive(false);

        }
        if (Rhum < 0)
        {
            Rhum = 0;
        }
        if (Rhum > 500)
        {
            Rhum = 500;
        }

        if (gold < 0)
        {
            GoldTxt.color = Color.red;
        }
        else
        {
            GoldTxt.color = Color.black;
        }
        tavernPrice = 3 * (TavernNb+1);
        TavernPriceTxt.text = tavernPrice.ToString() + " Golds";

        ScieriePrice = 3 * (ScierieNb + 1);
        ScieriePriceTxt.text = ScieriePrice.ToString() + " Golds";

        HousePrice = 2 * (HouseNb + 1);
        HousePriceTxt.text = HousePrice.ToString() + " Golds";

        if (IsOnExpedition && Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }

        CurentCam = Cameras.cptcam;

        if (!Isbuyisland2 && CurentCam == 1)
        {
            Island2Panel.SetActive(true);
            Island3Panel.SetActive(false);
        }
        else if (!Isbuyisland3 && CurentCam == 2)
        {
            Island3Panel.SetActive(true);
            Island2Panel.SetActive(false);
        }
        else if (CurentCam == 0)
        {
            Island2Panel.SetActive(false);
            Island3Panel.SetActive(false);
        }
    }

    public void buyisland2()
    {
        if (HaveAPort && gold >= 20)
        {
            Debug.Log("Vous avez acheté une nouvelle ile");
            ScrollTxt.text = ScrollTxt.text + "\n >You have bought a new island";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 1;

            gold -= 20;
            Island2Panel.SetActive(false);
            Isbuyisland2 = true;
            TavernNbMax += 4;
            ScierieMax += 4;
        }
    }

    public void buyisland3()
    {
        if (HaveAPort && gold >= 20)
        {
            Debug.Log("Vous avez acheté une nouvelle ile");
            ScrollTxt.text = ScrollTxt.text + "\n >You have bought a new island";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 1;

            gold -= 20;
            Island3Panel.SetActive(false);
            Isbuyisland3 = true;
            TavernNbMax += 4;
            ScierieMax += 4;
        }
    }
    public void buyport()
    {
        if (!HaveAPort && gold >= 2)
        {
            Debug.Log("Vous avez acheté un port");
            ScrollTxt.text = ScrollTxt.text + "\n >You have bought a port";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 1;

            gold -= 2;
            IsBuymod = true;
            for (int i = 0; i < PortZone.Length; i++)
            {
                PortZone[i].SetActive(true);
            }
            BtnBuyPort.GetComponent<Button>().interactable = false;
        }
        else if (HaveAPort)
        {
            Debug.Log("Vous ne pouvez pas achetez un port");
            ScrollTxt.text = ScrollTxt.text + "\n >You can't buy an extra port";
            Scrollbar.value = 0;
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);

        }
        else if (gold < 2)
        {
            ScrollTxt.text = ScrollTxt.text + "\n >You don't have enough gold!";
            Scrollbar.value = 0;
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);

        }

    }
    public void Placeport(RaycastHit hit)
    {
        Instantiate(Port, new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z), transform.rotation * Quaternion.Euler(0f, 180f, 0f));
        Debug.Log("Vous avez placé un port");
        ScrollTxt.text = ScrollTxt.text + "\n >You have placed a port";
        ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
        Scrollbar.value = 0;

        IsBuymod = false;

        for (int i = 0; i < PortZone.Length; i++)
        {
            PortZone[i].SetActive(false);
        }
        IslandNext.SetActive(true);
        HaveAPort = true;
        IslandPrev.SetActive(true);
    }
    public void buytavern()
    {
        if (TavernNb < TavernNbMax && gold >= tavernPrice)
        {
            Debug.Log("Vous avez acheté une taverne");
            ScrollTxt.text = ScrollTxt.text + "\n >You bought a tavern";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 0;
            gold -= tavernPrice;
            IsBuymod = true;

            for (int i = 0; i < TavernZone.Length; i++)
            {
                TavernZone[i].SetActive(true);
            }
            //TavernNb++;
        }
        else if (TavernNb == TavernNbMax)
        {
            BtnBuyTavern.GetComponent<Button>().interactable = false;
            ScrollTxt.text = ScrollTxt.text + "\n >You have too much tavern";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 0;

            Debug.Log("Nombre Max d'objets");
        }
        else if (gold < tavernPrice)
        {
            ScrollTxt.text = ScrollTxt.text + "\n >You don't have enough gold!";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 0;

        }
    }
    public void Placetavern(RaycastHit hit)
    {
        Destroy(hit.collider);//Pas bon

        Instantiate(Tavern, new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z), Quaternion.identity);

        Debug.Log("Vous avez placé une taverne");
        ScrollTxt.text = ScrollTxt.text + "\n >You have placed a tavern";
        ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
        Scrollbar.value = 0;

        IsBuymod = false;

        for (int i = 0; i < TavernZone.Length; i++)
        {
            TavernZone[i].SetActive(false);
        }


        TavernNb++;
    }
    public void buyScierie()
    {
        if (ScierieNb < ScierieMax && gold >= ScieriePrice)
        {
            Debug.Log("Vous avez acheté une Scierie");
            ScrollTxt.text = ScrollTxt.text + "\n >You have bought a sawmill";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 0;

            gold -= ScieriePrice;
            IsBuymod = true;

            for (int i = 0; i < ScierieMax; i++)
            {
                ScierieZone[i].SetActive(true);
            }
        }
        else if (ScierieNb == ScierieZone.Length)
        {
            BtnBuySie.GetComponent<Button>().interactable = false;
            ScrollTxt.text = ScrollTxt.text + "\n >You have too much Sawmill";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 0;

        }
        else if (gold < ScieriePrice)
        {
            ScrollTxt.text = ScrollTxt.text + "\n >You don't have enough gold !";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 0;

        }
    }
    public void PlaceScierie(RaycastHit hit)
    {
        Destroy(hit.collider);//Pas bon

        Instantiate(Scierie, new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z), Quaternion.identity);

        Debug.Log("Vous avez placé une Scierie");
        ScrollTxt.text = ScrollTxt.text + "\n >You have placed a Sawmill";
        ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
        Scrollbar.value = 0;

        IsBuymod = false;

        for (int i = 0; i < ScierieZone.Length; i++)
        {
            ScierieZone[i].SetActive(false);
        }

        ScierieNb++;
    }
    public void buyHouse()
    {
        if (HouseNb < HouseZone.Length && gold >= HousePrice)
        {
            Debug.Log("Vous avez acheté une maison");
            ScrollTxt.text = ScrollTxt.text + "\n >You have bought a house";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 0;

            gold -= HousePrice;
            IsBuymod = true;

            for (int i = 0; i < HouseZone.Length; i++)
            {
                HouseZone[i].SetActive(true);
            }
            //TavernNb++;
        }
        else if (HouseNb == HouseZone.Length)
        {
            BtnBuyHouse.GetComponent<Button>().interactable = false;
            ScrollTxt.text = ScrollTxt.text + "\n >You have too much house !";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 0;

        }
        else if (gold < HousePrice)
        {
            ScrollTxt.text = ScrollTxt.text + "\n >You don't have enough gold!";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 0;

        }
    }
    public void PlaceHouse(RaycastHit hit)
    {

        Destroy(hit.collider);//Pas bon

        Instantiate(House, new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z), Quaternion.identity);

        Debug.Log("Vous avez placé une maison");
        ScrollTxt.text = ScrollTxt.text + "\n >You have placed a house";
        ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
        Scrollbar.value = 0;

        IsBuymod = false;

        for (int i = 0; i < HouseZone.Length; i++)
        {
            HouseZone[i].SetActive(false);
        }

        HouseNb++;
    }
    public void buyCrew()
    {
        if (gold >= 1 && CrewNb < HouseNb * PlaceParHouse)
        {
            Instantiate(Crew, new Vector3(CrewSpawn.transform.position.x, CrewSpawn.transform.position.y, CrewSpawn.transform.position.z), Quaternion.identity);

            GameObject[] CrewObj = GameObject.FindGameObjectsWithTag("Crew");

            for (int i = 0; i < CrewNb + 1; i++)
            {
                CrewGestion CrewGestion = CrewObj[i].GetComponent<CrewGestion>();
                if (CrewGestion.IsNotInList)
                {

                    //Debug.Log(CrewObj[i].GetComponent<CrewGestion>().Name);
                    ScrollTxt.text = ScrollTxt.text + "\n >You have hired : " + CrewGestion.Name;

                    ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
                    Scrollbar.value = 0;

                    CrewList.Add(CrewObj[i]);
                    //sCrewdisplay.check();
                    CrewGestion.ID = CrewNb;
                    Crew_Dropdown.options.Add(new Dropdown.OptionData() { text = CrewGestion.Name.ToString() });
                    Capitaine_Dropdown[0].options.Add(new Dropdown.OptionData() { text = CrewGestion.Name.ToString() });
                    Capitaine_Dropdown[1].options.Add(new Dropdown.OptionData() { text = CrewGestion.Name.ToString() });

                    CrewGestion.IsNotInList = false;



                }
            }
            CrewNb++;
            gold -= 1;
        }
        else if (gold < 1)
        {
            ScrollTxt.text = ScrollTxt.text + "\n >You don't have enough gold!";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 0;
        }
        else
        {
            ScrollTxt.text = ScrollTxt.text + "\n >You don't have enough house !";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 0;
        }

    }
    public void GestionRessource()
    {
        Rhum += (TavernNb * TavernMultipl);
        wood += (ScierieNb * ScierieMultipl);
        Debug.Log(Time.time);

        if (GlobalMotivation < 0.25)
        {
            gold -= 1;
            ScrollTxt.text = ScrollTxt.text + "\n >The sailors are angry! You must pay a gold coin.... ";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 0;
        }
        else if (GlobalMotivation > 0.75)
        {
            gold += 1;
            ScrollTxt.text = ScrollTxt.text + "\n >The sailors are happy! You win a gold coin ";
            ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, ScrollContent.sizeDelta.y + 25);
            Scrollbar.value = 0;
        }

    }
    public void GestionMotivation()
    {
        GlobalMotivation = 0;

        foreach (GameObject Crew in CrewList)
        {
            GlobalMotivation += (Crew.GetComponent<CrewGestion>().Motivation);
            //Debug.Log("+ " + Crew.GetComponent<CrewGestion>().Motivation);
        }
        GlobalMotivation = GlobalMotivation / CrewNb;

        if (GlobalMotivation < 0.25)
        {
            MoralTxt.color = Color.red;
            Modifskill = -1;
        }
        else if (GlobalMotivation > 0.25 && GlobalMotivation < 0.75)
        {
            Modifskill = 0;
            MoralTxt.color = Color.black;
        }
        else if (GlobalMotivation > 0.75)
        {
            MoralTxt.color = Color.green;
            Modifskill = 1;
        }


    }

    public void CheckDropdown()
    {
        GameObject[] CrewObj = GameObject.FindGameObjectsWithTag("Crew");
        //Creation gameobject temp
        for (int i = 0; i < CrewObj.Length ; i++)
        {
            CrewGestion CrewGestion = CrewObj[i].GetComponent<CrewGestion>();
            //Crewmate
            if(CrewGestion.Job != CrewGestion.eJob.Tavern && CrewGestion.Job != CrewGestion.eJob.Scierie)
            {
                CrewGestion.Job = CrewGestion.eJob.Crewmate;
            }


            //Taverne : 
            if ((CrewGestion.Job == CrewGestion.eJob.Crewmate || CrewGestion.Job == CrewGestion.eJob.Tavern) && CrewGestion.Job != CrewGestion.eJob.Scierie)
            {//Si le marin est un simple marin, ou le tavernier ; 
                if (CrewGestion.IsNotInTavernDropDown)
                {//Si il n'es pas déja dans le drop down;
                    Taverne_Dropdown.options.Add(new Dropdown.OptionData() { text = CrewGestion.ID.ToString() });
                    CrewGestion.IsNotInTavernDropDown = false;
                    //Il est dans le dropdown
                }
            }
            else if ((CrewGestion.Job != CrewGestion.eJob.Crewmate || CrewGestion.Job != CrewGestion.eJob.Tavern) && CrewGestion.Job == CrewGestion.eJob.Scierie)
            {//Si le marin n'es pas un simple marin ni le tavernier 
                if (!CrewGestion.IsNotInTavernDropDown)
                {//Si il n'es pas déja dans le drop down;
                    Taverne_Dropdown.options.RemoveAt(CrewGestion.ID);
                    CrewGestion.IsNotInTavernDropDown = true;
                    /*
                    for (int x = 0; x < Taverne_Dropdown.options.Count; x++)
                    {
                        if (Taverne_Dropdown.options[x].text == CrewGestion.Name)
                        {
                            Taverne_Dropdown.options.RemoveAt(x);
                            CrewGestion.IsNotInTavernDropDown = true;
                            break;
                        }
                    }*/


                }
            }





            //Scierie : 
            if ((CrewGestion.Job == CrewGestion.eJob.Crewmate || CrewGestion.Job == CrewGestion.eJob.Scierie) && CrewGestion.Job != CrewGestion.eJob.Tavern)
            {//Si le marin est un simple marin, ou le tavernier ; 
                if (CrewGestion.IsNotInTScierieDropDown)
                {//Si il n'es pas déja dans le drop down;
                    Scierie_Dropdown.options.Add(new Dropdown.OptionData() { text = CrewGestion.ID.ToString() });
                    CrewGestion.IsNotInTScierieDropDown = false;
                    //Il est dans le dropdown
                }
            }
            else if ((CrewGestion.Job != CrewGestion.eJob.Crewmate || CrewGestion.Job != CrewGestion.eJob.Scierie) && CrewGestion.Job == CrewGestion.eJob.Tavern)
            {//Si le marin n'es pas un simple marin ni le tavernier 
                if (!CrewGestion.IsNotInTScierieDropDown)
                {//Si il n'es pas déja dans le drop down;
                    Scierie_Dropdown.options.RemoveAt(CrewGestion.ID);
                    CrewGestion.IsNotInTScierieDropDown = true;
                    /*for (int x = 0; x < Scierie_Dropdown.options.Count; x++)
                    {
                        if (Scierie_Dropdown.options[x].text == CrewGestion.Name)
                        {
                            Scierie_Dropdown.options.RemoveAt(x);
                            CrewGestion.Job = CrewGestion.eJob.Crewmate;
                            CrewGestion.IsNotInTScierieDropDown = true;
                            break;
                        }
                    }*/
                }
            }
        }
    }

    public void CheckTuto()
    {
        if ((HouseNb == 1 && IsTuto) && Tuto.tutostat == 0)
        {

            Tuto.OpenTuto();

            Tuto.CPT_Tuto++;
            Tuto.tutostat++;
        }
        if ((CrewNb == 3 && IsTuto) && Tuto.tutostat == 1)
        {
            Tuto.CPT_Tuto++;
            Tuto.OpenTuto();
            Tuto.tutostat++;
        }
        if (((TavernNb == 1 || ScierieNb == 1) && IsTuto) && Tuto.tutostat == 2)
        {
            Tuto.CPT_Tuto++;
            Tuto.OpenTuto();
            Tuto.tutostat++;
        }
        GameObject[] CrewObj = GameObject.FindGameObjectsWithTag("Crew");
        //Creation gameobject temp
        for (int i = 0; i < CrewObj.Length; i++)
        {
            CrewGestion CrewGestion = CrewObj[i].GetComponent<CrewGestion>();

            if (((CrewGestion.Job == CrewGestion.eJob.Tavern || CrewGestion.Job == CrewGestion.eJob.Scierie) && IsTuto) && Tuto.tutostat == 3)
            {
                Tuto.CPT_Tuto++;
                Tuto.OpenTuto();
                Tuto.tutostat++;
            }
        }

        if(Tuto.tutostat == 4)
        {
            IsTuto = false;
            CancelInvoke("CheckTuto");
        }

    }

    public void ClearTxt()
    {
        ScrollTxt.text = "Logbook :";
        ScrollContent.sizeDelta = new Vector2(ScrollContent.sizeDelta.x, 90);

    }
}
