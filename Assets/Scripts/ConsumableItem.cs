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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerStats stats = other.GetComponent<PlayerStats>();
            
            if(stats != null)
            {
                switch (this.effectType)
                {
                    case ItemEffect.RestoreHealth:
                        stats.ApplyEffect(this.effectAmount);
                        break;
                    case ItemEffect.TakeDamage:
                        stats.ApplyEffect(-this.effectAmount);
                        break;
                    case ItemEffect.ExtraLife:
                        stats.AddLife((int)this.effectAmount);
                        break;
                }

                Destroy(this.gameObject);
            }
        }
    }
}