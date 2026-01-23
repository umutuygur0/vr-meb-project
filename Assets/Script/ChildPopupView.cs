using UnityEngine;
using UnityEngine.UI;

public class ChildPopupView : MonoBehaviour
{
    public Image iconImage;   // PNG

    private void Awake()
    {
        SetVisible(false);
    }

    public void Set(Sprite sprite)
    {
        if (iconImage != null && sprite != null)
            iconImage.sprite = sprite;
    }

    public void SetVisible(bool visible)
    {
        gameObject.SetActive(visible);
    }
}
