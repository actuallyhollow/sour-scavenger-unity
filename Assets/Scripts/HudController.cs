using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudController : MonoBehaviour
{
    [Header("HUD Components")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI timerText;

    private float timeElapsed = 0.0F;
    private bool isTimerRunning = false;

    void Update()
    {
        if(this.isTimerRunning == true)
        {
            this.timeElapsed += Time.deltaTime;
            if(this.timerText != null)
            {
                this.timerText.text = FormatTime(this.timeElapsed);
            }
        }
    }

    public void StartTimer()
    {
        this.timeElapsed = 0.0F;
        this.isTimerRunning = true;
    }

    public void StopTimer()
    {
        this.isTimerRunning = false;
    }

    public float GetTimeElapsed()
    {
        return this.timeElapsed;
    }

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        if (this.healthSlider != null)
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

    public string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60.0F);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60.0F);
        return $"{minutes:00}:{seconds:00}";
    }
}