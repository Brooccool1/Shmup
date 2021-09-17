using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int health = 10;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private Canvas _gameOver;

    public void Hit(int damage)
    {
        health -= damage;
    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            // Dead player
            if (gameObject.name == "Player")
            {
                Instantiate(_gameOver, transform.position, Quaternion.identity);
            }
            // Dead Enemy
            else
            {
                GameObject.Find("GameUI").GetComponentInChildren<Kills>().addKill();
                GameObject.Find("Player")?.GetComponent<Player>().addXp();
            }

            Instantiate(_explosion, transform.position, Quaternion.identity)?.GetComponentInChildren<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }
}
