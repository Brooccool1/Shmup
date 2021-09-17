using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kills : MonoBehaviour
{
    private int _kills = 0;
    [SerializeField] private Text _killsText;

    public void addKill()
    {
        _kills++;
    }

    private void Update()
    {
        _killsText.text = _kills.ToString();
    }
}
