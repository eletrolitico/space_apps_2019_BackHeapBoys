using UnityEngine;
using System.Collections;

public class RotacaoBolas: MonoBehaviout {

	public float speed = 10f;

	void Update () {
		transform.Rotate (0, speed * Time.deltaTime, 0);
	}

} 