using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] GameObject deathFX = default;
    [SerializeField] Transform parent = default;

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
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hitpoints = hitpoints - 1;
    }
}
