using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CircleEffect : MonoBehaviour
{
    [SerializeField] private Color color;
    private SpriteRenderer _spriteRenderer;
    private Color _nativeColor;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _nativeColor = _spriteRenderer.color;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(nameof(SetBallEffect));
        }
    }

    private IEnumerator SetBallEffect()
    {
        _spriteRenderer.color = color;
        yield return new WaitForSeconds(1.5f);
        _spriteRenderer.color = _nativeColor;
    }
}
