using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Health
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _playerSpeed = 1;
    [SerializeField] private GameObject _shootEffect;
    [SerializeField] private float _shootDelay = 0;

    // Bullets
    [SerializeField] private int _bulletSpeed = 1;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _shootTime = 2f;

    // XP
    private int _currentXp = 0;
    [SerializeField] private int _xpToLevelUp = 5;

    private Vector2 _direction = new Vector2(0, 0);

    // Material for showing health
    private Material _damageShader;
    void Start()
    {
        _damageShader = GetComponentInChildren<SpriteRenderer>().material;
    }

    private void _rotation()
    {
        Vector3 lookAt = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float AngleRad = Mathf.Atan2(lookAt.y - transform.position.y, lookAt.x - transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
    }

    private void _input()
    {
        if (_shootDelay >= 0)
        {
            _shootDelay -= Time.deltaTime;
        }
        if (_shootDelay <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(_bulletPrefab, transform.position + transform.up, transform.rotation)?.GetComponent<Bullet>()?.Fire(_damage, _bulletSpeed, 0);
                Instantiate(_shootEffect, transform.position + transform.up, transform.rotation)?.GetComponentInChildren<ParticleSystem>().Play();
                _shootDelay = _shootTime;
            }
        }

        // accelerate
        if (Input.GetKey(KeyCode.W))
        {
            _direction.y = _playerSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _direction.y = -_playerSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction.x = -_playerSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _direction.x = _playerSpeed;
        }

        // stop
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            _direction.y = 0;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _direction.x = 0;
        }

        // add the force
        GetComponent<Rigidbody2D>().velocity = _direction;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
    }

    public void addXp()
    {
        _currentXp++;
    } 

    private void _levelUp()
    {
        if(_currentXp % _xpToLevelUp == 0)
        {
            int whichUpgrad = Random.Range(0, 3);
            switch(whichUpgrad)
            {
                case 0:
                    Upgrades.show("Damge +1");
                    _damage++;
                    break;

                case 1:
                    Upgrades.show("BulletSpeed +1");
                    _bulletSpeed++;
                    break;

                case 2:
                    Upgrades.show("Attack speed +1");
                    _shootTime -= 0.02f;
                    break;

                default:
                    break;
            }
            _currentXp++;
        }
    }

    void Update()
    {
        _input();
        _rotation();
        _levelUp();

        // modify shader depending on health
        float damageTaken = (10 - health) * 0.08f;
        _damageShader.SetFloat("_fade", damageTaken);
    }
}
