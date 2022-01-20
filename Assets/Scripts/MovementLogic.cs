using UnityEngine;

public class MovementLogic : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void Move(float directionZ, float directionX)
    {
        Movement(directionZ, directionX);
    }

    private void Movement(float directionZ, float directionX)
    {
        _rigidbody.velocity = new Vector3(directionX * speed, _rigidbody.velocity.y, directionZ * speed);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void AddSpeed(float addSpeed)
    {
        speed += addSpeed;
    }
    
    public void SubSpeed(float addSpeed)
    {
        speed -= addSpeed;
        if (speed < 0) speed = 0;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
