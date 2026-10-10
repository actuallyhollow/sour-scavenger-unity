using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI timerText;

    private float timeElapsed = 0.0F;

    void Update()
    {
        this.timeElapsed += Time.deltaTime;
        
        int minutes = Mathf.FloorToInt(this.timeElapsed / 60.0F);
        int seconds = Mathf.FloorToInt(this.timeElapsed % 60.0F);
        
        if(this.timerText != null)
        {
            this.timerText.text = $"Time: {minutes:00}:{seconds:00}";
        }
    }

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        if(this.healthSlider != null)
        {
            this.healthSlider.value = currentHealth / maxHealth;
        }
    }

    public void UpdateLives(int currentLives)
    {
        if (this.livesText != null)
        {
            this.livesText.text = $"Lives: {currentLives}";
        }
    }
}