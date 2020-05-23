using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed = 0.5f;
    [SerializeField] ParticleSystem attackParticles = default;

    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }


    private void AttackEnemyBase()
    {
        var vfx = Instantiate(attackParticles, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(gameObject);
        Destroy(vfx.gameObject, vfx.main.duration);

    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementSpeed);
        }
        AttackEnemyBase();
    }

}
