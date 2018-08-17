using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continuouslyBob : MonoBehaviour {



	public float originalY;
	public float bobbingPosition;
	public float bobAmplitude = .4f;
	public float bobSpeed = 2.5f;

	void Start () {
	}
	
	void Update () {

		//Save y position prior to bobbing
		originalY = transform.position.y;
	
		//Create a bobbing value to move the Y of the ocean up and down
		bobbingPosition = originalY+bobAmplitude*Mathf.Sin(bobSpeed*Time.time);
		//Transform the ocean's y position using the bobbing value
		transform.position = new Vector3(transform.position.x, bobbingPosition, transform.position.z);


	}
}
