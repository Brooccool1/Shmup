using UnityEngine;

public class ShotgunEnemy : BaseEnemy
{
    // Start is called before the first frame update
    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        InvokeRepeating("_attack", 1, 1.5f);
    }

    private void _attack()
    {
        for (int i = -1; i < 2; i++)
        {
            shoot(i * 0.1f);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        movement();
        rotation();
    }
}