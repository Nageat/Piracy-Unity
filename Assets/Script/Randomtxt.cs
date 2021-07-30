using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Randomtxt : MonoBehaviour
{
    public string[] TxtDial;
    public TMP_Text Text_Random;
    // Start is called before the first frame update
    void Start()
    {
        Text_Random.text = "" + TxtDial[Random.Range(0, TxtDial.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
