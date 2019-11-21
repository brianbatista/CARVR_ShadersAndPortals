using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TouchControl_1 : MonoBehaviour
{
    private Camera arCamera;

    private void Start()
    {
        arCamera = GetComponent<Camera>();
    }

    // Checks if this the touch is through Unity (Mouse) or through Mobile (#else).
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;
            touchPosition = new Vector2(mousePosition.x, mousePosition.y);
            return true;
        }
#else
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
#endif

        touchPosition = default;
        return false;
    }

    //
    void Update()
    {
        // The actual touch control.
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;
        
        Debug.Log("Touch Position: " + touchPosition);

        Ray ray = arCamera.ScreenPointToRay(touchPosition);

        RaycastHit hitObject;

        if (Physics.Raycast(ray, out hitObject)) // true if we hit something
        {
            Debug.Log("Raycasting Detected: " + hitObject.collider.name);
            man_AnimControl animControl = hitObject.transform.parent.GetComponent<man_AnimControl>();
            if (animControl!= null)
            {
                animControl.manMove();
            }
        }
    }
}
