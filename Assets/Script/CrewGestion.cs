using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrewGestion : MonoBehaviour
{
    [System.Serializable]
    public enum eRace
    {
        Human,
        Elf,
        Drawf,
        Special,
        Empty
    }
    public enum eJob
    {
        Tavern,
        Crewmate,
        Scierie,
        Empty
    }

    public eRace Race;
    public eJob Job;
    public Sprite HumanSprit;
    public Sprite ElfSprit;
    public Sprite DrawfSprit;

    public string Name;

    public int skill_Charisme;
    public int skill_Force;
    public int skill_Intel;
    public int skill_Agil;

    public float Motivation;
    public int Live;

    public TMP_Text NameZone;
    public Animator anim;

    public bool IsNotInList = true;
    public bool IsNotInTavernDropDown = true;
    public bool IsNotInTScierieDropDown = true;
    public int ID;

    private void Awake()
    {
        CrewRandom();
        InvokeRepeating("MotivationDown", 10, 10);

    }

    // Update is called once per frame
    void Update()
    {
        NameZone.text = Name;
        if(Motivation > 1)
        {
            Motivation = 0.99f;
        }
        if (Motivation < 0)
        {
            Motivation = 0.01f;
        }
    }

    void CrewRandom()
    {
        //RaceRandom
        int raceRandom;
        raceRandom = Random.Range(0, 15);
        /*
        switch (raceRandom)
        {
            case 1:
                Race = eRace.Human;
                break;
            case 2:
                Race = eRace.Elf;
                break;
            case 3:
                Race = eRace.Drawf;
                break;
            default :
                Race = eRace.Human;
                Destroy(gameObject);
                Debug.Log("ERREUR LORS DE LA CREATION (sprit) " + raceRandom);
                break;
        }*/

        if (raceRandom <= 5)
        {
            Race = eRace.Human;
        } 
        else if (raceRandom > 5 && raceRandom <= 10)
        {
            Race = eRace.Elf;
        }
        else if (raceRandom > 10)
        {
            Race = eRace.Drawf;
        }


        //NameRandom
        int NameRandom;
        NameRandom = Random.Range(0, 41);
        switch (NameRandom)
        {
            case 1:
                Name = "John Blackbeard";
                break;
            case 2:
                Name = "Long Pete";
                break;
            case 3:
                Name = "DreadfulJohn";
                break;
            case 4:
                Name = "Bill Largeparrot";
                break;
            case 5:
                Name = "Linda McKracken";
                break;
            case 6:
                Name = "Andy Staples";
                break;
            case 7:
                Name = "Emily Williams";
                break;
            case 8:
                Name = "Rummy McKracken";
                break;
            case 9:
                Name = "Dorthey Landlubber";
                break;
            case 10:
                Name = "Oliver Prichard";
                break;
            case 11:
                Name = "Christine Gallo";
                break;
            case 12:
                Name = "Andrew Fishfood";
                break;
            case 13:
                Name = "Karlos McLifetaker";
                break;
            case 14:
                Name = "Kathleen Watso";
                break;
            case 15:
                Name = "Joe Smith";
                break;
            case 16:
                Name = "Shannon Kegsteeler";
                break;
            case 17:
                Name = "Emlissa Grogmaster";
                break;
            case 18:
                Name = "Mark Van Horne";
                break;
            case 19:
                Name = "Karla Williams";
                break;
            case 20:
                Name = "Lanky Condent";
                break;
            case 21:
                Name = "Thovin Torergrer";
                break;
            case 22:
                Name = "Thorin Torergrer";
                break;
            case 23:
                Name = "Gellert Tvarivich";
                break;
            case 24:
                Name = "Caesar Ventrue";
                break;
            case 25:
                Name = "Edward Cannowey";
                break;
            case 26:
                Name = "Liam O'connor";
                break;
            case 27:
                Name = "Lucy Queen";
                break;
            case 28:
                Name = "Luna Bysse";
                break;
            case 29:
                Name = "Sola Bysse";
                break;
            case 30:
                Name = "Jack Céparou";
                break;
            case 31:
                Name = "Maki Corgi";
                break;
            case 32:
                Name = "Jaques Moineau";
                break;
            case 33:
                Name = "Henry Martin";
                break;
            case 34:
                Name = "John Paul Jones";
                break;
            case 35:
                Name = "John Draper";
                break;
            case 36:
                Name = "Kevin Mitnick";
                break;
            case 37:
                Name = "Mary Read";
                break;
            case 38:
                Name = "Hanry Bridgeman";
                break;
            case 39:
                Name = "Rachel Wall";
                break;
            case 40:
                Name = "Jonas Connook";
                break;
            default:
                Name = "John Smith";
                break;
        }

        //Competance = Random.Range(50, 85);

        Motivation = Random.Range(65, 75);
        Motivation = Motivation / 100;
        CrewGeneration();

    }
    void CrewGeneration()
    {
        Job = eJob.Crewmate;
        if (Race == eRace.Human)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = HumanSprit;
            skill_Agil = Random.Range(3, 8);
            skill_Force = Random.Range(3, 8);
            skill_Charisme = Random.Range(1, 5);
            skill_Intel = Random.Range(5, 10);

            anim.SetBool("Human", true);
        }
        else if (Race == eRace.Elf)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ElfSprit;
            skill_Agil = Random.Range(5, 10);
            skill_Force = Random.Range(1, 5);
            skill_Charisme = Random.Range(3, 8);
            skill_Intel = Random.Range(3, 8);
            anim.SetBool("Elf", true);
        }
        else if (Race == eRace.Drawf)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = DrawfSprit;
            skill_Agil = Random.Range(1, 5);
            skill_Force = Random.Range(5, 10);
            skill_Charisme = Random.Range(3, 8);
            skill_Intel = Random.Range(3, 8);
            anim.SetBool("Drawf", true);
        }
    }
    public void SetRandomPos()
    {
        Vector3 temp = new Vector3(Random.Range(-1f, 1f), Random.Range(1f, -1f), 0);
        transform.position = temp;
        //transform.Translate(temp * Time.deltaTime);
    }
    public void MotivationDown()
    {
        int randMotvation;
        randMotvation = Random.Range(1, 100);
        if (randMotvation >= 50)
        {
            Motivation -= Random.Range(0.01f, 0.03f);

        }
        if (Motivation > 1)
        {
            Motivation = 1;
        }
    }
}
