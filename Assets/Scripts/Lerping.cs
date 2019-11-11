using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerping : MonoBehaviour
{
    public float lerpSpeed = .1f;

    [SerializeField]
    bool rotating = false;

    [SerializeField]
    float rotationTime;

    private Quaternion targetRotation;

    [SerializeField]
    bool windowOpen = false;

    private void Start()
    {
        targetRotation = transform.rotation;
    }

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!windowOpen)
            {
                targetRotation *= Quaternion.AngleAxis(115, Vector3.up);
                rotating = true;
                rotationTime = 0f;
                windowOpen = true;
            }

            else
            {
                targetRotation *= Quaternion.AngleAxis(-115, Vector3.up);
                rotating = true;
                rotationTime = 0f;
                windowOpen = false;
            }
        }

        if (rotating)
        {
            rotationTime += Time.deltaTime * lerpSpeed;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationTime);
        }
    }
}
