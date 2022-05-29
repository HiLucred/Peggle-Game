using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    [SerializeField] private float ballForce;
    //[SerializeField] private ParticleSystem dustParticle;

    private Camera _camera;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _bulletDirection;
    private ScoreManager _scoreManager;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        _camera = Camera.main;
    }

    private void Start()
    {
        InitializeTheBullet();
    }

    private void InitializeTheBullet()
    {
        RotateBullet();
        ShootBullet();
    }
    private void RotateBullet()
    {
        var targetCamera = _camera.ScreenToWorldPoint(Input.mousePosition);
        _bulletDirection = (targetCamera - transform.position).normalized;
    }

    private void ShootBullet()
    {
        _rigidbody2D.AddForce(_bulletDirection * ballForce);
    }

    private void DestroyBall()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Collision"))
        {
            //dustParticle.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dead Zone"))
        {
            DestroyBall();
        }

        if (other.CompareTag("Basket"))
        {
            _scoreManager.ScorePoint();
            DestroyBall();
        }
    }
}