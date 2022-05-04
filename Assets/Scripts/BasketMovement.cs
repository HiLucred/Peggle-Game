using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BasketMovement : MonoBehaviour
{
    [SerializeField] private float speedMovement;
    [SerializeField] private Transform pointOne;
    [SerializeField] private Transform pointTwo;
    [SerializeField] private LayerMask layer;
    
    private Rigidbody2D _rigidbody2D;
    private bool _changeDirection;
    
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        _rigidbody2D.velocity = new Vector2(speedMovement, _rigidbody2D.velocity.y);
        _changeDirection = Physics2D.Linecast(pointOne.position, pointTwo.position, layer);

        if (!_changeDirection) return;
        
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speedMovement *= -1;
    }
}
