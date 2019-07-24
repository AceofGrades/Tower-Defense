using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public int damage = 10;
    public float fireDelay = .5f;
    public float range = 5f;
    public int cost = 5;
    public int level = 1; // Convert to level -1 for array

    private float fireTimer = 0; // Elapse time from last fire

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Update()
    {
        // Increase the fireTimer
        fireTimer += Time.deltaTime;
        // If fireTimer > fireDelay
        if(fireTimer > fireDelay)
        {
            // Detect targets
            List<Transform> targets = DetectTargets();
            // Get Closest target
            Transform closestTarget = GetClosestTarget(targets);

            Aim(closestTarget);
            Fire(closestTarget);

            // Reset timer
            fireTimer = 0;
        }
        // Aim
    }

    public Transform GetClosestTarget(List<Transform> targets)
    {
        // Set float min to infinity
        float min = float.MaxValue;
        // Set Transform closest to null
        Transform closest = null;
        // Loop through each target
        foreach (var target in targets)
        {
            // get distance between target and current (tower)
            float distance = Vector3.Distance(target.position, transform.position);
            // If distance < min
            if (distance < min)
            {
                // min = distance
                min = distance;
                // closest = target
                closest = target;
            }
        }
        // return closest
        return closest;
    }

    protected List<Transform> DetectTargets()
    {
        List<Transform> result = new List<Transform>();
        // Performs an OverlapSphere Physics Detection
        Collider[] hits = Physics.OverlapSphere(transform.position, range);
        // Loop through all hits
        foreach (var hit in hits)
        {
            // If hits contain Enemy
            Enemy enemy = hit.GetComponent<Enemy>();
            // Add to Transform list
            if (enemy)
            {
            result.Add(enemy.transform);

            }
        }
        // Return Transform list
        return result;
    }
    
    // Fires and applies damage to given target
    public virtual void Fire(Transform target)
    {

    }

    // Aims or rotates barrel towards given target
    public virtual void Aim(Transform target)
    {

    }
}
