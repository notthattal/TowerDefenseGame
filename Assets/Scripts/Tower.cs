using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan = default;
    [SerializeField] ParticleSystem bullets = default;
    [SerializeField] float attackRange = 10f;


    Transform targetEnemy = default;

    void Update()
    {
        SetTargetEnemy();

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

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if ( sceneEnemies.Length == 0 ) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        float distToA= Vector3.Distance(transformA.transform.position, transform.position);
        float distToB = Vector3.Distance(transformB.position, transform.position);
        if (distToA >= distToB)
        {
            return transformB;
        }
        else
        {
            return transformA;
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
