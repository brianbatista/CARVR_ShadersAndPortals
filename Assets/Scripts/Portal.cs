using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{
    public Material[] materials;

    public float addZ = 0f;

    public GameObject cameraKid;
    

    // Start is called before the first frame update
    void Start()
    {
        foreach (var mat in materials)
            {
                mat.SetInt("stest",(int)CompareFunction.Equal);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.name!="Main Camera")
        {
            Debug.Log("Did not collide with camera.");
            return;
        }

        //outside
        if (transform.position.z>(cameraKid.transform.position.z))
        {
            foreach (var mat in materials)
            {
                Debug.Log("Room Z > Camera Z.");
                mat.SetInt("stest",(int)CompareFunction.Equal);
            }
        }

        //inside
        else
        {
            foreach (var mat in materials)
            {
                Debug.Log("Camera Z is inside room");
                mat.SetInt("stest",(int)CompareFunction.NotEqual);
            } 
        }
    }
}
