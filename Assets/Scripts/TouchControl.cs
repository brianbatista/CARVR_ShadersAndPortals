using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TouchControl : MonoBehaviour
{
    private Camera arCamera;

    private void Start()
    {
        arCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);            
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject)) // true if we hit something
                {
                    man_AnimControl animControl = hitObject.transform.GetComponent<man_AnimControl>();
                    if (animControl!= null)
                    {
                        animControl.manMove();
                    }
                }
            }
        }
    }
}
