using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	private float rotateFactor = 0.1f;
	private bool mouseDown;
	public float scaleFactor = 0.005f;
	public float mouseZoomFactor = 0.05f;

	/// <summary>
	/// Reset variables on Enable.
	/// </summary>
	void OnEnable()
	{
		mouseDown = false;
	}

	void Update()
	{

		if (GameController.controller.WikipediaStatus ()) 
		{
			mouseDown = false;
			return;
		}

#if UNITY_WEBGL || UNITY_WEBGL_API


		// Mouse wheel scroll 
		if (Input.GetAxis ("Mouse ScrollWheel") != 0)
			OnMouseScroll (Input.GetAxis ("Mouse ScrollWheel"));

		// Touch started trigger
		if (Input.GetMouseButtonDown (0))
			mouseDown = true;

		// Touch ended trigger
		if (Input.GetMouseButtonUp (0))
			mouseDown = false;


		if(mouseDown)
		{
			float x = Input.GetAxis ("Mouse X") * rotateFactor ;
			float y = Input.GetAxis ("Mouse Y") * rotateFactor ;

			transform.RotateAround (Vector3.up, -x);
			transform.RotateAround (Vector3.right, y);
		}
		
		#else


		// Pinch to zoom
		// If there are two touches on the device...         
		if (Input.touchCount == 2)
		{
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			Zoom (deltaMagnitudeDiff);
		}
		else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			float x = Input.GetAxis ("Mouse X") * rotateFactor;
			float y = Input.GetAxis ("Mouse Y") * rotateFactor;

			transform.RotateAround (Vector3.up, -x);
			transform.RotateAround (Vector3.right, y);
		}
#endif
	}

#if UNITY_WEBGL || UNITY_WEBGL_API
	/// <summary>
	/// Move the canera close to the globe to get zoom effect.
	/// </summary>
	/// <param name="value">Value.</param>
	void OnMouseScroll(float magnitude)
	{
		if (GameController.controller.WikipediaStatus())
			return;
		else
			transform.GetComponent<EarthManager> ().DisabaleAnimation ();
		
			transform.localScale = new Vector3 (transform.localScale.x + magnitude*mouseZoomFactor, 
												transform.localScale.y + magnitude*mouseZoomFactor,
												transform.localScale.z + magnitude*mouseZoomFactor);
	}

#else
		
	/// <summary>
	/// Zoom the specified magnitude.
	/// </summary>
	/// <param name="magnitude">Magnitude.</param>
	void Zoom(float magnitude)
	{
	if (GameController.controller.WikipediaStatus())
			return;
		else
			transform.GetComponent<EarthManager> ().DisabaleAnimation ();

		transform.localScale = new Vector3 (transform.localScale.x - magnitude*scaleFactor, 
		transform.localScale.y - magnitude*scaleFactor,
		transform.localScale.z - magnitude*scaleFactor);
	}

#endif




}
