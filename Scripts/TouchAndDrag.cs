using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndDrag : MonoBehaviour {

	//GameObjects
	public GameObject ocean;
	public GameObject attractText;
	public GameObject explanationText;

	//Components
	private float originalY;
	public Transform upperLimit;
	public Transform lowerLimit;
	public SpringJoint2D spring;
	public CanvasGroup attractCanvasGroup;
	public CanvasGroup explanationTextCanvasGroup;

	//store a speed to slow movement of TouchZone in response to the user's touch
	public float speed = .1F;

	void Start () {
		//use Start() to store a static copy of the touchZone's Y
		//to be able to return the touchZone to its original place
		//after the touch event
		originalY = transform.position.y;
	}

	void Update () {
		attractCanvasGroup = attractText.GetComponent<CanvasGroup>();
		explanationTextCanvasGroup = explanationText.GetComponent<CanvasGroup>();

		//If there is more than one touch
		//And if the movement of the first touch has changed
		if (Input.touchCount > 0) {

			//And if the touch has started to move
			if (Input.GetTouch(0).phase == TouchPhase.Began) {
			

			//Otherwise, if the touch keeps moving
			} else if (Input.GetTouch(0).phase == TouchPhase.Moved) {	

				//Store value of the touch's change in position
				Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
				float maximumTouchDistance = Mathf.Min(touchDeltaPosition.y, 10);

				//And if the touch's y position is in the middle of the screen
				//Move the TouchZone game object down the screen
				//And alpha out / in the text boxes
				if (touchDeltaPosition.y < upperLimit.position.y && touchDeltaPosition.y > lowerLimit.position.y) {
					Debug.Log("Touch is in range");
					transform.Translate(0, maximumTouchDistance, 0);
					attractCanvasGroup.alpha -= .05f;
					explanationTextCanvasGroup.alpha += .1f;

				//Or if the touch's y is close to the bottom of the screen
				//Don't let it go down & off the screen
				} else if (touchDeltaPosition.y < lowerLimit.position.y) {
					Debug.Log("Touch is below range");
					transform.position = new Vector3(transform.position.x, lowerLimit.position.y, transform.position.z);
					attractCanvasGroup.alpha -= .1f;
					explanationTextCanvasGroup.alpha += .1f;

				//Or if the touch's y is towards the top
				//Don't let it go up & off the screen
				} else if (touchDeltaPosition.y > upperLimit.position.y) {
					Debug.Log("Touch is above range");
					transform.position = new Vector3(transform.position.x, upperLimit.position.y, transform.position.z);
				}

			//Or if the touch has stopped moving
			} else if (Input.GetTouch(0).phase == TouchPhase.Ended) {
			}

		//Or if the touch has let go
		} else {
				moveTouchZoneBack();
		}
	}

	void moveTouchZoneBack() {
		// Debug.Log("Trying to move touchZone");

		float currentDistance = originalY - transform.position.y;
		float newY = currentDistance * 0.1f;

		transform.Translate(0, newY, 0);
		attractCanvasGroup.alpha += .1f;
		explanationTextCanvasGroup.alpha -= .1f;
	}
}

