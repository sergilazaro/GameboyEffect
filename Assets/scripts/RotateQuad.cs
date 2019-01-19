using UnityEngine;
using System.Collections;

public class RotateQuad : MonoBehaviour
{
	Quaternion initialRotation;

	private void Awake()
	{
		initialRotation = transform.rotation;
	}

	void Update()
	{
		float time = Time.time % 1.0f;
		float angle = 180 * time;

		transform.rotation = initialRotation * Quaternion.AngleAxis(angle, Vector3.forward);
	}
}