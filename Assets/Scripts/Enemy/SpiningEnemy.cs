using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiningEnemy : BaseEnemy
{
    private bool _rotating = false;
    private int _rotationGoal = 0;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        InvokeRepeating("_startAttack", 1, 4f);
    }

    private void _startAttack()
    {
        if (!_rotating)
        {
            _rotationGoal = 360 * 2;
        }
    }

    private void _rotationToDo()
    {
        if(_rotationGoal > 0)
        {
            _rotating = true;
            transform.Rotate(0, 0, 0.5f, Space.Self);
            if (_rotationGoal % 40 == 1)
            {
               shoot(0);
            }
            _rotationGoal--;
        }
        else
        {
            _rotating = false;
        }
    }

    void Update()
    {
        if (!_rotating)
        {
            movement();
            rotation();
        }
        _rotationToDo();
    }
}
