using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class cameraMove : MonoBehaviour
{
    public Camera[] Cam;
    public Button NextCam;
    public Button PrevCam;
    public int cptcam = 0;
    public float speed = 1;
    public float sensitivity = 50;


    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.up * speed * Time.deltaTime);

        }


    }


    public void Gonext()
    {
       if (cptcam == 0) {
            Cam[0].enabled = false;
            Cam[1].enabled = true;
            Cam[2].enabled = false;
            cptcam = 1;
       }
       else if (cptcam == 1)
       {
            Cam[0].enabled = false;
            Cam[1].enabled = false;
            Cam[2].enabled = true;
            cptcam = 2;
        }
        else if (cptcam == 2)
       {
            Cam[0].enabled = true;
            Cam[1].enabled = false;
            Cam[2].enabled = false;
            cptcam = 0;

        }
        else if (cptcam > 2 )
       {
            cptcam = 0;
       }
    }
    public void GoPrev()
    {
        if (cptcam == 0)
        {
            Cam[0].enabled = false;
            Cam[1].enabled = false;
            Cam[2].enabled = true;
            cptcam = 2;

        }
        else if (cptcam == 1)
        {
            Cam[0].enabled = true;
            Cam[1].enabled = false;
            Cam[2].enabled = false;
            cptcam = 0;
        }
        else if (cptcam == 2)
        {
            Cam[0].enabled = false;
            Cam[1].enabled = true;
            Cam[2].enabled = false;
            cptcam = 1;
        }
        else if (cptcam > 2)
        {
            cptcam = 2;
        }
    }
}

