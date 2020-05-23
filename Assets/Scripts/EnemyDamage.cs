using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] GameObject deathFX = default;
    [SerializeField] ParticleSystem hitParticles = default;
    [SerializeField] AudioClip damageSFX = default;
    [SerializeField] AudioClip deathSFX = default;

    AudioSource audioSource = default;

    [SerializeField] int hitpoints = 5;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        Destroy(gameObject);

    }

    private void ProcessHit()
    {
        hitpoints = hitpoints - 1;
        hitParticles.Play();
        audioSource.PlayOneShot(damageSFX);
    }
}
