using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 300;
    void Update()
    {
        var mouseScroll = Input.GetAxis("Mouse ScrollWheel");

        if (mouseScroll != 0)
        {
            transform.Translate(transform.forward * mouseScroll * zoomSpeed * Time.deltaTime, Space.Self);
        }
    }

}
