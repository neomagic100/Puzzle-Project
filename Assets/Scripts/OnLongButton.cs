using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class OnLongButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPointerDown;
    private float pointerDownTimer;

    public float requiredHoldTime = 1f;

    public UnityEvent onLongClick;

    [SerializeField]
    private Image fillImage;

    public void OnPointerDown(PointerEventData data)
    {
        isPointerDown = true;
        Debug.Log("Pointer Down");
    }

    public void OnPointerUp(PointerEventData data)
    {
        Reset();
        Debug.Log("Pointer Up");
    }

    void Update()
    {
        if (!isPointerDown)
            return;

        pointerDownTimer += Time.deltaTime;

        if (pointerDownTimer >= requiredHoldTime)
        {
            if (onLongClick != null)
                onLongClick.Invoke();

            Reset();
        }

        if (fillImage == null)
            return;
        fillImage.fillAmount = pointerDownTimer / requiredHoldTime;

    }

    void Reset()
    {
        isPointerDown = false;
        pointerDownTimer = 0;

        if (fillImage == null)
            return;
        fillImage.fillAmount = 0;
    }
}
