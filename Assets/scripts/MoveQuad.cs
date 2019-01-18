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
		transform.position = initialPos + Vector3.right * Mathf.PingPong(Time.time, 0.5f);
	}
}
