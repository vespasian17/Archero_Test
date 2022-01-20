using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingBatBehavior : EnemyBehavior
{
    [SerializeField] private int stopTime;
    [SerializeField] private float addChargeSpeed = 1;
    
    private EnemyFlyingBatMovement flyingBatMovement;
    private MovementLogic speedControl;
    private float defaultSpeed;

    void Start()
    {
        base.Start();
        speedControl = GetComponent<MovementLogic>();
        defaultSpeed = speedControl.GetSpeed();
        flyingBatMovement = GetComponent<EnemyFlyingBatMovement>();
    }
    void Update()
    {
        base.Update();
        Attack();
    }

    private void Attack()
    {
        if(IsAttackReady() && flyingBatMovement.IsMoving())
        {
            speedControl.SetSpeed(defaultSpeed);
            flyingBatMovement.StopMovement(stopTime);
            ChargeAttack();
        }
    }
    
    private void ChargeAttack()
    {
        speedControl.AddSpeed(addChargeSpeed);
    }
        
}
