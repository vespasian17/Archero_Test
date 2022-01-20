using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private int coinsForDeath = 5;
    [SerializeField] private int contactDamage = 2;
    [SerializeField] protected float timeForAttack = 3;
    [SerializeField] protected PlayerFinder finderCollider;
    protected float tempTime;
    private bool attackState = true;
    protected Inventory playerInventory;
    protected Health health;
    protected Rigidbody rbEnemy;

    protected virtual void Start()
    {
        tempTime = timeForAttack;
        health = GetComponent<Health>();
        rbEnemy = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        if (!health.IsAlive() && finderCollider.GetPlayerInventory() != null)
        {
            playerInventory = finderCollider.GetPlayerInventory();
            playerInventory.AddCoins(coinsForDeath);
            Destroy(this.gameObject);
        }
    }

    public bool IsAttackReady()
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


    private void OnCollisionEnter(Collision playerCollider)
    {
        if (playerCollider.transform.CompareTag("Avatar"))
            playerCollider.gameObject.GetComponent<Health>()?.TakeDamage(contactDamage);
    }
}
