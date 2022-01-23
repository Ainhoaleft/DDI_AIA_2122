using UnityEngine;
using System.Collections;

//Ainhoa Izquierdo Arenas

public class Rotator : MonoBehaviour {
	
	public Vector3 giro = new Vector3(15, 30, 45);
	
	// Before rendering each frame..
	void Update () 
	{
		transform.Rotate (giro * Time.deltaTime);

	}
}	