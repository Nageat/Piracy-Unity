using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea(5, 10)]
    public string Description = "";
    public GameObject PanelDescription;
    public TMP_Text TxtDescription;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        PanelDescription.SetActive(true);
        TxtDescription.text = Description;
        /*
        var pos = Input.mousePosition;
        pos.z = 10;
        pos = Camera.main.ScreenToWorldPoint(pos);
        PanelDescription.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
     */

    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        PanelDescription.SetActive(false);
        TxtDescription.text = "";
        //IsPlace = false;
    }
}
