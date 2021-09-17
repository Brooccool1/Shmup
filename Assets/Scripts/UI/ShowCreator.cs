using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowCreator : MonoBehaviour
{
    [SerializeField] private Text _creatorText;
    private void Update()
    {
        if (GetComponent<BoxCollider2D>().OverlapPoint(Input.mousePosition))
        {
            _creatorText.enabled = true;
        }
        else
        {
            _creatorText.enabled = false;
        }
    }
}
