using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Shoot effect
    private void OnEnable()
    {
        if(Random.Range(0, 2) == 1)
        {
            GetComponentInChildren<ParticleSystem>().gravityModifier = 1;
        }
        else
        {
            GetComponentInChildren<ParticleSystem>().gravityModifier = -1;
        }
    }

    private void Update()
    {
        if (gameObject.GetComponentInChildren<ParticleSystem>().isStopped)
        {
            Destroy(gameObject);
        }
    }
}
