using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomDespawner : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.GetComponentInChildren<ParticleSystem>().isStopped)
        {
            Destroy(gameObject);
        }
    }
}
