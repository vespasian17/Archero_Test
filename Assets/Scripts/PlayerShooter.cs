using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private int projectileDamage;
    [SerializeField] private int projectileSpeed;
    [SerializeField] private PlayerProjectileController playerProjectile;
    [SerializeField] private float timeForAttack = 3;
    [SerializeField] private GameObject projectileStartPoint;
    [SerializeField] private EnemiesFinder finderCollider;
    
    private PlayerController playerController;
    private Rigidbody playerRigidbody;
    
    private float tempTime;
    private Vector3 nullVector = new Vector3(0,0,0);
    
    private bool attackState = true;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (playerRigidbody.velocity == nullVector)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (IsAttackReady() && finderCollider.GetEnemiesList().Count != 0)
        {
            var currentProjectile =
                Instantiate(playerProjectile, projectileStartPoint.transform.position, Quaternion.identity);
            currentProjectile.SetProjecileSpeed(projectileSpeed);
            currentProjectile.SetProjecileDamage(projectileDamage);
            currentProjectile.Setup(finderCollider, playerController);
        }
    }

    private bool IsAttackReady()
    {
        if (tempTime < Time.time)
        {
            attackState = true;
            tempTime = Time.time + timeForAttack;
        }
        else
        {
            attackState = false;
        }
        
        return attackState;
    }
}
