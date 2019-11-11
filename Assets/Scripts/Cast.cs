using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class Cast : MonoBehaviour
{
    public Camera arCamera;
    public GameObject window;
    public GameObject[] scenes;
    
    private int opened;

    private void Start()
    {
        opened = 0;
        arCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject)) // true if we hit something
                {
                    if (hitObject.transform.tag == "window")
                    {
                        if (opened == 0)
                        {
                            //this is the rotation script. Change it into your functional code
                            window.transform.Rotate(0, 90, 0);
                            opened = 1;
                        } else
                        {
                            window.transform.Rotate(0, -90, 0);
                            opened = 0;
                        }
                    }
                    
                }
            }

            // this is for activating the fog when the condition is right, seems we don't need it for now
            foreach (GameObject scene in scenes)
            {
                if (scene.transform.tag == "fog" && scene.GetComponent < MeshRenderer >().enabled == true)
                {

                }
            }
        }


    }
}
