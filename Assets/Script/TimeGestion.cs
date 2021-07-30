using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGestion : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void FastGame()
    {
        Time.timeScale = 2;
    }
}
