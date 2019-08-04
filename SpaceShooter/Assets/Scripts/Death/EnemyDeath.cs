using System;
using System.Collections;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private float maxMagnitude = 2000f;
    
    private float _magnitude;
    private Vector2 _vector;
    private Transform _targetPoint;

    private void Update()
    {
        KillWhenTooFar();
    }

    private void OnTriggerEnter2D(Collider2D bullet)
    {
        KillWhenHit(bullet);
    }

    private void KillWhenTooFar()
    {
        _targetPoint = GameObject.FindGameObjectWithTag("Player").transform;
        _vector = _targetPoint.position - transform.position;
        _magnitude = _vector.sqrMagnitude;

        if (_magnitude > maxMagnitude)
        {
            Destroy(gameObject);
        }
    }
    
    private void KillWhenHit(Collider2D bullet)
    {
        if (bullet.CompareTag("Bullet"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            GetComponent<AudioSource>().Play();
            GetComponentInChildren<ParticleSystem>().Play();

            Destroy(gameObject, 2f);
            Destroy(bullet.gameObject);
        }
    }
    
    
}
