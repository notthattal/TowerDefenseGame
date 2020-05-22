using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] GameObject deathFX = default;
    [SerializeField] ParticleSystem hitParticles = default;

    [SerializeField] int hitpoints = 5;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitpoints <= 1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hitpoints = hitpoints - 1;
        hitParticles.Play();
    }
}
