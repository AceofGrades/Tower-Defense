using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Tower
{
    public Transform barrel; // Reference to rotating pivot
    public override void Aim(Transform target)
    {
        // Rotate barrel to look at target
        barrel.LookAt(target);
    }

    public override void Fire(Transform target)
    {
        
    }
}
