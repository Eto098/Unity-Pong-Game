using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public void HandleStartButtonOnClickEvent()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }
}
