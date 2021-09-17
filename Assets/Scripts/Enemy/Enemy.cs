using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseEnemy
{
    // Start is called before the first frame update
    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        InvokeRepeating("_attack", 1, 0.5f);
    }

    private void _attack()
    {
        shoot(0);
    }

    // Update is called once per frame
    private void Update()
    {
        movement();
        rotation();
    }
}
