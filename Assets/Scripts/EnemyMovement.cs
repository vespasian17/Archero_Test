using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    protected MovementLogic _movementLogic;

    protected float _horizontalDirection;
    protected float _verticalDirection;

    protected bool isMoving = true;

    private void Awake()
    {
        _movementLogic = GetComponent<MovementLogic>();
    }

    protected virtual void Update()
    {

    }


    public void StopMovement(int stopTime)
    {
        isMoving = false;
        var coroutine = TimerForStopping(stopTime);
        StartCoroutine(coroutine);
    }

    private IEnumerator TimerForStopping(int stopTime)
    {
        yield return new WaitForSeconds(stopTime);
        isMoving = true;
    }

    public bool IsMoving()
    {
        return isMoving;
    }
}
