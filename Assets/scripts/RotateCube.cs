using UnityEngine;
using System.Collections;

public class RotateCube : MonoBehaviour
{
	Quaternion initialRotation;

	private void Awake()
	{
		initialRotation = transform.rotation;
	}

	void Update()
	{
		float time = Time.time % 1.0f;
		float angle = time * 90;

		transform.rotation = initialRotation * Quaternion.AngleAxis(angle, Vector3.up) * Quaternion.AngleAxis(angle, Vector3.right) * Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
