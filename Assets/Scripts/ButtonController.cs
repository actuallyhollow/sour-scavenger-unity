using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour, IPointerEnterHandler
{
    private Button button;

    void Awake()
    {
        this.button = this.GetComponent<Button>();
        
        if(this.button != null)
        {
            this.button.onClick.AddListener(this.PlayClickSound);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(AudioController.Instance != null)
        {
            AudioController.Instance.PlayAudio(AudioController.Instance.hoverAudio);
        }
    }

    private void PlayClickSound()
    {
        if(AudioController.Instance != null)
        {
            AudioController.Instance.PlayAudio(AudioController.Instance.clickAudio);
        }
    }
}