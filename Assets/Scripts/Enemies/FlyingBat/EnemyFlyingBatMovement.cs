using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementLogic))]
public class EnemyFlyingBatMovement : EnemyMovement
{
    [SerializeField] private PlayerFinder _playerFinder;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        base.Update();
        if (isMoving)
            FlyingBatMove();
        else
        {
            rb.velocity = new Vector3(0,0,0);
        }
    }
    
    public void FlyingBatMove()
    {
        var heading = _playerFinder.GetPlayerPosition() - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        _movementLogic.Move(direction.z, direction.x);
    }
}
