using UnityEngine;

public class EnemyArcherBehavior : EnemyBehavior
{
    [SerializeField] private int projectileDamage;
    [SerializeField] private int projectileSpeed;
    [SerializeField] private int stopTime;
    [SerializeField] private EnemyArcherProjectiles enemyProjectile;

    [SerializeField] private GameObject projectileStartPoint;
    private EnemyArcherMovement archerMovement;

    void Start()
    {
        base.Start();
        archerMovement = GetComponent<EnemyArcherMovement>();
    }
    void Update()
    {
        base.Update();
        Attack();
    }

    private void Attack()
    {
        if(IsAttackReady())
        {
            archerMovement.StopMovement(stopTime);
            var currentProjectile = Instantiate(enemyProjectile, projectileStartPoint.transform.position, Quaternion.identity);
            currentProjectile.SetProjecileSpeed(projectileSpeed);
            currentProjectile.SetProjecileDamage(projectileDamage);
            currentProjectile.Setup(finderCollider);
        }
    }
}
