using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class RaycastToCube : MonoBehaviour
{
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    ARRaycastManager m_RaycastManager;

    //
    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    //
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
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;
        
        Debug.Log("Touch Position: " + touchPosition);

        RaycastHit hit;

        if (Physics.Raycast(touchPosition, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.Log("Raycasting Detected: " + hit.collider.tag);
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            if (hit.collider.tag == "Interactable")
            {
                hit.collider.GetComponent<CubeRotate>().enabled = !enabled;
            } 
        }
    }
}
