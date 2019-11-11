using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWindow_Both : MonoBehaviour
{
	public float lerpSpeed = .1f;

    [SerializeField]
	bool opened = false;

    [SerializeField]
    bool isRotating = false;

    float angle;

    
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !isRotating)
		{
            if (opened == false)
            {
                if (gameObject.CompareTag("WindowLeft"))
                {
                    angle = -90f;
                }

                if (gameObject.CompareTag("WindowRight"))
                {
                    angle = 90f;
                }

                else
                {
                    Debug.Log("Does not compute.");
                }

                StartCoroutine(RotateA(Vector3.forward, 1.0f));
                opened = true;
            }

            else
            {
                if (gameObject.CompareTag("WindowLeft"))
                {
                    angle = 90f;
                }

                if (gameObject.CompareTag("WindowRight"))
                {
                    angle = -90f;
                }

                else
                {
                    Debug.Log("Does not compute version 2.");
                }

                    StartCoroutine(RotateA(Vector3.forward, 1.0f));
                    opened = false;

            }
		}
	}

	IEnumerator RotateA(Vector3 axis, float duration)
	{
		float elapsed = 0.0f;
		float rotated = 0.0f;
        isRotating = true;
		while (elapsed < duration)
		{
			float step = angle / duration * Time.deltaTime;
			transform.RotateAround(transform.position, axis, step);
			elapsed += Time.deltaTime;
			rotated += step;
			yield return null;
		}
        isRotating = false;
		transform.RotateAround(transform.position, axis, angle - rotated);
	}
}