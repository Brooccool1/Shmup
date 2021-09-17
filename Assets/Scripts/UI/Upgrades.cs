using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    private static Text _text;
    private static int _fadeToDo = 0;
    private static int _fadeTime = 100;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    public static void show(string text)
    {
        _text.text = text;
        _fadeToDo = _fadeTime;
    }

    private void FixedUpdate()
    {
        if(_fadeToDo > 0)
        {
            _fadeToDo--;
        }

        _text.color = new Color(255, 255, 0, (_fadeToDo * 0.01f));
    }
}
