using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan = default;
    [SerializeField] Transform targetEnemy = default;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem bullets = default;

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            LookAtEnemy();
            ShootEnemy();
        }
        else
        {
            Shoot(false);
        }

    }

    private void ShootEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = bullets.emission;
        emissionModule.enabled = isActive;
    }

    private void LookAtEnemy()
    {
        objectToPan.LookAt(targetEnemy);
    }
}
