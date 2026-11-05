using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MobileSafeAreaUpdater : MonoBehaviour
{
    [SerializeField]
    private RectTransform RTransform;
    private Rect CurrentSize;
    void Start()
    {
        var size = Screen.safeArea;
        if (RTransform != null && size != null)
        {
            SetSafeArea(size);
        }
    }
    void Update()
    {
        Rect newR = Screen.safeArea;
#if UNITY_EDITOR
        SetSafeArea(newR);
#endif
        if (newR != null && newR != CurrentSize)
        {
            SetSafeArea(newR);
        }
    }
    void SetSafeArea(Rect rect)
    {
        Vector2 anchorMin = rect.position;
        Vector2 anchorMax = rect.position + rect.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        RTransform.anchorMin = anchorMin;
        RTransform.anchorMax = anchorMax;
        CurrentSize = rect;
    }
}
