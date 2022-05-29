using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject[] bullet;
    [SerializeField] private Transform gunTip;
    [SerializeField] private float timeToShoot;

    private bool _canShoot;
    private float _counter;
    
    private void Update()
    {
        PrepareBulletToShoot();
    }

    private void PrepareBulletToShoot()
    {
        _counter += Time.deltaTime;
        _canShoot = _counter >= timeToShoot;

        if (!_canShoot) return;
        
        //Ball 1 (White Ball)
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(bullet[0], gunTip.position, quaternion.identity);
            _counter = 0;
        }
        
        //Ball 2 (Blue Ball)
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(bullet[1], gunTip.position, quaternion.identity);
            _counter = 0;
        }
        
        //Ball 3 (Pink Ball)
        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(bullet[2], gunTip.position, quaternion.identity);
            _counter = 0;
        }
    }
}