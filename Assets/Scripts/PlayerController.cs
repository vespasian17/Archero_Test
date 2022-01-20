using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    
    [Header("Player stats")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private EnemiesFinder enemiesFinder;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rigidbody.velocity = new Vector3(joystick.Horizontal * moveSpeed, _rigidbody.velocity.y,
            joystick.Vertical * moveSpeed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity, transform.up);
        }

        if (_rigidbody.velocity.x == 0 && _rigidbody.velocity.z == 0 && enemiesFinder.GetEnemiesList().Count != 0)
        {
            var playerRotation = SetRotationTo(enemiesFinder.GetClosestEnemyPosition(), transform);
            transform.rotation = playerRotation;
        }
    }

    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }
    
    Quaternion SetRotationTo(Transform target, Transform playerTransform)
    {
        if (target == null) return Quaternion.identity;
        var lookPos = target.transform.position - playerTransform.position;
        var rotation = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = rotation.eulerAngles.y;
        rotation = Quaternion.Euler(0, eulerY, 0);

        return rotation;
    }
}
