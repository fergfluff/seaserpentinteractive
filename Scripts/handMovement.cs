using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UICircle moves up repeatedly, starting at the same location
//As it moves up, it changes from its original gray to a transparent shade
//Perhaps it should be white?
//When the user touches the screen, the circle disappears
//When the user lets go, the circle appears after a couple seconds


public class handMovement : MonoBehaviour {

	//Game Objects
	public GameObject Hand;

	//Components
	public CanvasGroup HandCanvasGroup;
	

	//Values
	public float speed;
	public float distance = 50;
	public float alphaRate = 0.007f;
	private float originalY;

	// Use this for initialization
	void Start () {
		originalY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        HandCanvasGroup = Hand.GetComponent<CanvasGroup>();

        //&& Input.GetTouch(0).phase == TouchPhase.Moved

        //If there is more than one touch
        //And if the movement of the first touch has changed
        if (Input.touchCount > 0) {
			Debug.Log("User is touching screen");
			transform.position = new Vector3(transform.position.x, originalY, transform.position.z);
            //Make it disappear
            HandCanvasGroup.alpha = 0f;
		} else {
			Debug.Log("User is NOT touching screen");
			//If user is not touching screen
			//Make circle move repeatedly down, starting from the same location
			moveCircle(); 
		}
	}

	void moveCircle() {
        Debug.Log("Hand appears and starts to move again");
		//distance between the circle's original starting point and its current location
		float currentDistance = originalY - transform.position.y;

	
		//If the UICircle passes a certain distance from its starting point
		//Keep moving it down
		//Slow it down a lot when it starts and stops, and goes a little faster in the middle
		//And make it fade away

		//if currentDistance is greater than 10
		if (currentDistance < distance - 90) {
			transform.Translate(Vector3.down * Time.deltaTime*35);
            HandCanvasGroup.alpha -= alphaRate;
		//if currentDistance is less than 100
		} else if (currentDistance < distance) {
			transform.Translate(Vector3.down * Time.deltaTime*60);
            HandCanvasGroup.alpha -= alphaRate;
		//if currentDistance is less than 105
		} else if (currentDistance < distance + 5) {
			transform.Translate(Vector3.down * Time.deltaTime*40);
            HandCanvasGroup.alpha -= alphaRate;
		//if currentDistance is less than 115
		} else if (currentDistance < distance + 15) {
			transform.Translate(Vector3.down * Time.deltaTime*30);
            HandCanvasGroup.alpha -= alphaRate;
		//Put it back where it started
		} else {
            Debug.Log("Hand appears again");
			transform.position = new Vector3(transform.position.x, originalY, transform.position.z);
            HandCanvasGroup.alpha = 1f;
		}
	}
}



