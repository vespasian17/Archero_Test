using System;
using UnityEngine;

public class EnemyArcherProjectiles : MonoBehaviour
{
    [SerializeField] private int projectileDamage = 1;
    [SerializeField] private int projectileSpeed = 1;
    [SerializeField] private int yOffset = 1;

    private Vector3 targetPoint;
    private Vector3 offset;
    private PlayerFinder playerFinder;

    void Update()
    {
        offset = new Vector3(0, yOffset, 0);
        if (playerFinder == null) return;
        ProjectileMoveToTarget(transform.position,playerFinder.GetPlayerPosition());
    }

    
    public void Setup(PlayerFinder playerFinder)
    {
        this.playerFinder = playerFinder;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Avatar")  || other.CompareTag("Obstacle"))
        {
            other.gameObject.GetComponent<Health>()?.TakeDamage(projectileDamage);

            Destroy(gameObject);
        }
    }

    public void ProjectileMoveToTarget(Vector3 startPoint, Vector3 target)
    {
        transform.position = Vector3.MoveTowards(startPoint, target + offset, GetProjecileSpeed() * Time.deltaTime);
    }

    public void ProjectileMoveToTarget(Vector3 startPoint, Vector3 target, int speed)
    {
        transform.position = Vector3.MoveTowards(startPoint, target, speed * Time.deltaTime);
    }
}
