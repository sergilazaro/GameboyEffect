using UnityEngine;
using System.Collections;

public class RotateCube : MonoBehaviour
{
	void Update()
	{
		transform.rotation *= Quaternion.AngleAxis(100 * Time.deltaTime, Vector3.up) * Quaternion.AngleAxis(100 * Time.deltaTime, Vector3.up) * Quaternion.AngleAxis(80 * Time.deltaTime, Vector3.forward);
	}
}
