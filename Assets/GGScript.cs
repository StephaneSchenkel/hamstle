using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GGScript : MonoBehaviour, IPointerClickHandler
{
    public Text text;

    private int count = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        text.text = count.ToString();
        count++;
    }
}