using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private void Update()
    {
        // Follows player
        if (_player)
        {
            transform.position = _player.transform.position - new Vector3(0, 0, 10);
        }
    }
}
