using UnityEngine;
using System.Collections;

public class RotateQuad : MonoBehaviour
{
	void Update()
	{
		transform.rotation *= Quaternion.AngleAxis(80 * Time.deltaTime, Vector3.forward);
	}
}