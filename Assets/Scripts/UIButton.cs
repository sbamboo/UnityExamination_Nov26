
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image im;

    public void Awake()
    {
        im = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData e)
    {
        im.color = Color.blue;
    }

    public void OnPointerExit(PointerEventData e)
    {
        im.color = Color.white;
    }
}
