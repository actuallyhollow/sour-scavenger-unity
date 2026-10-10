using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private HudController hudController;

    [Header("Lives Settings")]
    [SerializeField] private int maxLives = 3;

    [Header("Health Settings")]
    [SerializeField] private float maxHealth = 100.0F;
    [SerializeField] private float decayRate = 5.0F; 
    
    private int currentLives;
    private float currentHealth;

    void Start()
    {
        this.currentHealth = this.maxHealth;
        this.currentLives = this.maxLives;
    
        if(this.hudController != null)
        {
            this.hudController.UpdateHealth(this.currentHealth, this.maxHealth);
            this.hudController.UpdateLives(this.currentLives);
        }
    }

    void Update()
    {
        this.currentHealth -= this.decayRate * Time.deltaTime;

        if(this.hudController != null)
        {
            this.hudController.UpdateHealth(this.currentHealth, this.maxHealth);
        }

        if(this.currentHealth <= 0)
        {
            this.Die();
        }
    }

    public void ApplyEffect(float amount)
    {
        this.currentHealth += amount;
        this.currentHealth = Mathf.Clamp(this.currentHealth, 0.0F, this.maxHealth);

        if(this.hudController != null)
        {
            this.hudController.UpdateHealth(this.currentHealth, this.maxHealth);
        }
        
        Debug.Log($"Item consumed! Current Health is now: {this.currentHealth}");
    }

    public void AddLife(int amount = 1)
    {
        this.currentLives += amount;   

        if(this.hudController != null)
        {
            this.hudController.UpdateLives(this.currentLives);
        }
        
        Debug.Log($"Extra life gained! Current Lives: {this.currentLives}");
    }

    private void Die()
    {
        this.currentLives--;

        if(this.hudController != null)
        {
            this.hudController.UpdateLives(this.currentLives);
        }

        if(this.currentLives > 0)
        {
            Debug.Log($"Player died! Lives remaining: {this.currentLives}. Resetting health...");
            this.currentHealth = this.maxHealth;
        }
        else
        {
            Debug.Log($"Player died! Lives remaining: {this.currentLives}. Game Over!");
            this.enabled = false; 
        }
    }
}