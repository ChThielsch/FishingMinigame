using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class SnapAnchorToCorners : EditorWindow
{
    [MenuItem("Tools/UI/Snap Anchors")]
    public static void SnapAnchors()
    {
        foreach (Object obj in Selection.objects)
        {
            if (obj != null)
            {
                GameObject monoBehaviour = obj as GameObject;
                if (monoBehaviour != null)
                {
                    RectTransform transform =
                        monoBehaviour.GetComponent<RectTransform>();
                    if (transform != null)
                    {
                        SingleSnap(transform);
                    }
                }
            }
        }
    }

    private static void SingleSnap(RectTransform _transform)
    {
        RectTransform parent = _transform.parent as RectTransform;
        
        if (parent == null)
        {
            return;
        }

        Vector2 vectorMin = new Vector2(_transform.anchorMin.x + _transform.offsetMin.x / parent.rect.width,
                                        _transform.anchorMin.y + _transform.offsetMin.y / parent.rect.height);
        Vector2 vectorMax = new Vector2(_transform.anchorMax.x + _transform.offsetMax.x / parent.rect.width,
                                        _transform.anchorMax.y + _transform.offsetMax.y / parent.rect.height);

        _transform.anchorMin = vectorMin;
        _transform.anchorMax = vectorMax;

        _transform.offsetMin = Vector2.zero;
        _transform.offsetMax = Vector2.zero;
    }
}
