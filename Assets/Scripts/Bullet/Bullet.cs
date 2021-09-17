using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _destroyEffect;

    private Rigidbody2D _body;

    private int _damage;
    private int _speed;

    private void OnEnable()
    {
        _body = GetComponent<Rigidbody2D>();
    }
 
    /// <param name="owner">0 = player else enemy</param>
    public void Fire(int damage, int speed, int owner)
    {
        if(owner == 0)
        {
            gameObject.layer = 8;
        }
        else
        {
            gameObject.layer = 9;
        }

        _damage = damage;
        _speed = speed;
        _body.AddForce(transform.up * _speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        BaseEnemy enemy = collision.collider.GetComponent<BaseEnemy>();

        if (enemy != null)
        {
            enemy.Hit(_damage);
        }
        else if (player != null)
        {
            player.Hit(_damage);
        }
        _destroyBullet();
    }

    private void _destroyBullet()
    {
        Instantiate(_destroyEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
