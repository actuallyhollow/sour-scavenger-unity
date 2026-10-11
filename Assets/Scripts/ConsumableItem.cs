using UnityEngine;

public class ConsumableItem : MonoBehaviour
{
    public enum ItemEffect
    {
        RestoreHealth,
        TakeDamage,
        ExtraLife
    }

    [Header("Item Settings")]
    [SerializeField] private ItemEffect effectType = ItemEffect.RestoreHealth;
    [SerializeField] private float effectAmount = 20.0F;

    [Header("Despawn Settings")]
    [SerializeField] private float minDespawnTime = 5.0F;
    [SerializeField] private float maxDespawnTime = 15.0F;

    void Start()
    {
        float lifetime = Random.Range(this.minDespawnTime, this.maxDespawnTime);
        Object.Destroy(this.gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerStats stats = other.GetComponent<PlayerStats>();
            
            if(stats != null)
            {
                switch(this.effectType)
                {
                    case ItemEffect.RestoreHealth:
                        AudioController.Instance.PlayAudio(AudioController.Instance.eatAudio);
                        stats.ApplyEffect(this.effectAmount);
                        break;
                    case ItemEffect.TakeDamage:
                        AudioController.Instance.PlayAudio(AudioController.Instance.hurtAudio);
                        stats.ApplyEffect(-this.effectAmount);
                        break;
                    case ItemEffect.ExtraLife:
                        AudioController.Instance.PlayAudio(AudioController.Instance.powerupAudio);
                        stats.AddLife((int)this.effectAmount);
                        break;
                }

                Object.Destroy(this.gameObject);
            }
        }
    }
}