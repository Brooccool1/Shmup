using System;
using UnityEngine;

public class BaseEnemy : Health
{
    [NonSerialized] public Rigidbody2D _body;
    [SerializeField] private int _speed = 10;
    [SerializeField] private int _damage = 1;

    [SerializeField, Range(1f, 100f)] private float _enemySpeed = 1f;
    [SerializeField, Range(1f, 100f)] private float _topSpeed = 10f;
    [SerializeField, Range(5f, 50f)] private float _area = 10f;

    [SerializeField] private GameObject _teleportPrefab;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _shootEffect;
    [SerializeField] public GameObject Player;

    private Vector3 _distance;
    private Vector3 _lookAt;

    private void Awake()
    {
        if (UnityEngine.Random.Range(0, 5) == 0)
        {
            InvokeRepeating("_teleport", 1, 11);
        }
    }

    // Teleports enemy close to the player
    private void _teleport()
    {
        if (Player)
        {
            _body.velocity = new Vector2(0, 0);
            transform.position = new Vector3(Player.transform.position.x + UnityEngine.Random.Range(-10, 11), Player.transform.position.y + UnityEngine.Random.Range(-10, 11), 0);
            Instantiate(_teleportPrefab, transform.position + transform.up, transform.rotation);
        }
    }

    public void shoot(float rotationOffset)
    {
        if (Player != null)
        {
            Quaternion tempRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w + rotationOffset);

            Instantiate(_bulletPrefab, transform.position + transform.up, tempRotation)?.GetComponent<Bullet>().Fire(_damage, _speed, 1);
            Instantiate(_shootEffect, transform.position + transform.up, transform.rotation)?.GetComponentInChildren<ParticleSystem>().Play();
        }
    }

    public void rotation()
    {
        if (Player != null)
        {
            _lookAt = Player.transform.position;
        }

        float AngleRad = Mathf.Atan2(_lookAt.y - transform.position.y, _lookAt.x - transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
    }

    public void movement()
    {
        // Player is alive, gets the distance between the enemy and the player.
        if (Player != null)
        {
            _distance = transform.position - Player.transform.position;
        }
        // Accelerate
        if (_distance.x > _area || _distance.x < -_area || _distance.y > _area || _distance.y < -_area)
        {

            if (_body.velocity.x <= _topSpeed || _body.velocity.y <= _topSpeed)
            {
                _body.AddForce(transform.up * _enemySpeed, ForceMode2D.Force);
            }
        }
        // Break
        else
        {
            if (_body.velocity != Vector2.zero)
            {
                _body.velocity = new Vector2(Mathf.Lerp(_body.velocity.x, 0, 0.001f), Mathf.Lerp(_body.velocity.y, 0, 0.001f));
            }
        }
        _body.angularVelocity = 0;
    }
}
