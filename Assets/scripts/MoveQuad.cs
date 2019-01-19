using UnityEngine;
using System.Collections;

public class MoveQuad : MonoBehaviour
{
	Vector3 initialPos;

	void Start()
	{
		initialPos = transform.position;
	}

	void Update()
	{
		float time = Time.time % 1.0f;
		transform.position = initialPos + Vector3.right * Mathf.PingPong(time, 0.5f);
	}
}
