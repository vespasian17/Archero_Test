using System;
using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{
    [SerializeField] private int projectileDamage = 1;
    [SerializeField] private int projectileSpeed = 1;

    private Vector3 targetPoint;
    private Vector3 offset;
    private EnemiesFinder enemiesFinder;
    private PlayerController playerController;
    private Rigidbody rbProj;

    void Update()
    {
        rbProj = GetComponent<Rigidbody>();
        if (enemiesFinder == null) return;
        if (playerController == null) return;
        ProjectileThrow();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")  || other.CompareTag("Obstacle"))
        {
            other.gameObject.GetComponent<Health>()?.TakeDamage(projectileDamage);
            Destroy(this.gameObject);
        }
    }

    private void ProjectileThrow()
    {
        transform.Translate(transform.forward * Time.deltaTime * projectileSpeed, Space.World);
    }
    
    public void Setup(EnemiesFinder enemiesFinder, PlayerController playerController)
    {
        this.enemiesFinder = enemiesFinder;
        this.playerController = playerController;
        transform.rotation = SetRotationTo(enemiesFinder.GetClosestEnemyPosition(), transform);
    }

    public int GetProjecileDamage()
    {
        return projectileDamage;
    }

    public void SetProjecileDamage(int projDamage)
    {
        projectileDamage = projDamage;
    }

    public int GetProjecileSpeed()
    {
        return projectileSpeed;
    }

    public void SetProjecileSpeed(int projSpeed)
    {
        projectileSpeed = projSpeed;
    }
    
    Quaternion SetRotationTo(Transform target, Transform enemyTransform)
    {
        var lookPos = target.transform.position - enemyTransform.position;
        var rotation = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = rotation.eulerAngles.y;
        rotation = Quaternion.Euler(0, eulerY, 0);

        return rotation;
    }
}
