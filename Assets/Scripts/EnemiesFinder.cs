using System.Collections.Generic;
using UnityEngine;

public class EnemiesFinder : MonoBehaviour
{
    private List<GameObject> enemiesList = new List<GameObject>();
    private Transform closestEnemyPosition;
    private Transform playerTransform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesList.Add(other.gameObject);
        }

        if (other.CompareTag("Avatar"))
        {
            playerTransform = other.transform;
        }
    }

    public List<GameObject> GetEnemiesList()
    {
        return enemiesList;
    }

    private void RemoveEnemyFromList(GameObject enemy)
    {
        enemiesList.Remove(enemy);
    }
    
    private Transform FindClosestEnemyPosition()
    {
        double closestDistance = 0;
        float currentVector = 0;

        foreach (var enemy in GetEnemiesList().ToArray())
        {
            if (enemy == null)
            {
                RemoveEnemyFromList(enemy);
                closestDistance = 0f;
                continue;
            }
            
            if (enemy.GetComponent<Health>().IsAlive())
            {
                var heading = enemy.transform.position - playerTransform.position;
                heading.y = 0;
                currentVector = heading.magnitude;
                
                if (currentVector < closestDistance || closestDistance == 0f)
                {
                    closestEnemyPosition = enemy.transform;
                    closestDistance = currentVector;
                }
            }
        }
        return closestEnemyPosition;
    }

    public Transform GetClosestEnemyPosition()
    {
        return FindClosestEnemyPosition();
    }
}
