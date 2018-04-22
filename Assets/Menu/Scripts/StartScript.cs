using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text text;

    public void OnPointerDown(PointerEventData eventData)
    {
        text.text = "NICE";
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        text.text = "PAS NICE";
        SceneManager.LoadScene("GG", LoadSceneMode.Single);
    }
}
