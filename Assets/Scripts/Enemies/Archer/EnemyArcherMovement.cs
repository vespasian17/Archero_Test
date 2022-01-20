using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MovementLogic))]
public class EnemyArcherMovement : EnemyMovement
{
    private void Start()
    {
        StartCoroutine("TimerForMoveDirection");
    }

    private void Update()
    {
        base.Update();
        
        if (isMoving)
            _movementLogic.Move(_horizontalDirection, _verticalDirection);
    }

    public void SetRandomMoveDirection()
    {
        var rand = Random.value;

        if (rand > 0.5) RandomHorizontalMove();
        else RandomVerticalMove();
    }
    
    private void RandomHorizontalMove()
    {
        _verticalDirection = 0;
        _horizontalDirection = Random.Range(-1, 1);
        if (_horizontalDirection < 0) _horizontalDirection = -1;
        else _horizontalDirection = 1;
    }
    
    private void RandomVerticalMove()
    {
        _horizontalDirection = 0;
        _verticalDirection = Random.Range(-1, 1);
        if (_verticalDirection < 0) _verticalDirection = -1;
        else _verticalDirection = 1;
    }
    
    private IEnumerator TimerForMoveDirection()
    {
        while (true)
        {
            SetRandomMoveDirection();
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
    }
}
