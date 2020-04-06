using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tower : MonoBehaviour
{   //parameters
    [SerializeField] Transform objectCanMove;
    [SerializeField] float attackrange = 55f;
    [SerializeField] ParticleSystem projectileParticle;
    public Waypoint baseWaypoint;
    //State
    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            AttackRange();
            objectCanMove.LookAt(targetEnemy);
        }
        else
        {
            shoot(false);
        }
        
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<Enemy>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (Enemy testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var towerpos = transform.position;
        var distance1 = Vector3.Distance(towerpos, transformA.position);
        var distance2 = Vector3.Distance(towerpos, transformB.position);
        if (distance1 < distance2) { return transformA; }
        return transformB;

    }

    void AttackRange()
    {
        float Distance = Vector3.Distance(gameObject.transform.position, targetEnemy.transform.position);
        if (Distance <= attackrange){shoot(true); }
        else{shoot(false);}
    }
    private void shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }

}
