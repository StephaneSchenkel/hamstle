using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorClick : MonoBehaviour, IPointerClickHandler {

    private enum State { WHITE, COLORED, BLINK };
    private Color _color = Color.white;
    private Text _text;

    private State _currentState;

    private Coroutine _blinkingRoutine;

	// Use this for initialization
	void Start () {
        _currentState = State.WHITE;
        _text = this.GetComponent<Text>();
        SetColor();
	}
	
	// Update is called once per frame
	void Update () {
        if (_currentState == State.BLINK)
        {
            if(_blinkingRoutine == null)
                _blinkingRoutine = StartCoroutine(Blinking());
        }
	}

    private IEnumerator Blinking()
    {
        while (true)
        {
            if (_text.color == _color)
                _text.color = Color.white;
            else
                _text.color = _color;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void SetColor()
    {
        switch (_text.text)
        {
            case "Red":
                _color = Color.red;
                break;
            case "Blue":
                _color = Color.blue;
                break;
            case "Green":
                _color = Color.green;
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (_currentState)
        {
            case State.WHITE:
                ColorText();
                break;
            case State.COLORED:
                BlinkText();
                break;
            case State.BLINK:
                NormalText();
                break;
        }
    }

    private void ColorText()
    {
        _text.color = _color;
        _currentState = State.COLORED;
    }

    private void BlinkText()
    {
        _currentState = State.BLINK;
    }

    private void NormalText()
    {
        _text.color = Color.white;
        _currentState = State.WHITE;
        if (_blinkingRoutine != null)
        {
            StopCoroutine(_blinkingRoutine);
            _blinkingRoutine = null;
        }
    }
}
