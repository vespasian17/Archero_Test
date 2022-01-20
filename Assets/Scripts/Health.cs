using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    
    [Header("Player Requirements")]
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject joyStickUI;
    [SerializeField] private TimeController timeController;

    private bool isAlive;
    void Start()
    {
        isAlive = true;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        CheckIsAlive();
    }
    
    public void CheckIsAlive()
    {
        if (currentHealth <= 0)
        {
            if (gameObject.CompareTag("Avatar"))
            {
                timeController.StopTime();
                deathPanel.SetActive(true);
                joyStickUI.SetActive(false);
            }
            isAlive = false;
        }
    }

    public bool IsAlive()
    {
        return isAlive;
    }
}
