using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRioter : ZombieStalker
{

    protected override void Move()
    {
        LookPlayer();
        // Rotate Around permite "orbitar" al rededor de una posición.
        transform.RotateAround(PlayerTransform.position, Vector3.up, 5f * Time.deltaTime);
    }

}
