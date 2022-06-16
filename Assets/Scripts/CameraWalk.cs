using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWalk : MonoBehaviour
{
	public float walkspeed = 10f;
	public float squatspeed = 0.1f;
	public float posVal = 1f;
	public float lTrigger1;

	public GameObject cameraObject;

	void Update()
	{
		//ˆÚ“®
		if (Input.GetAxis("Vertical") > 0)
		{
			transform.position += transform.forward * walkspeed * Time.deltaTime;
		}
		if (Input.GetAxis("Vertical") < 0)
		{
			transform.position -= transform.forward * walkspeed * Time.deltaTime;
		}
		if (Input.GetAxis("Horizontal") > 0)
		{
			transform.position += transform.right * walkspeed * Time.deltaTime;
		}
		if (Input.GetAxis("Horizontal") < 0)
		{
			transform.position -= transform.right * walkspeed * Time.deltaTime;
		}

		//‚µ‚á‚ª‚Ý
		lTrigger1 = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);

		// transform‚ðŽæ“¾
		Transform myTransform = cameraObject.transform;
		Vector3 pos = myTransform.position;

		if (lTrigger1 >= 0f && lTrigger1 < 0.1f)
		{
			//Debug.Log("–³");
			posVal = posVal + squatspeed;
			pos.y = posVal;

			if (pos.y > 1f)
			{
				pos.y = 1f;
				posVal = 1f;
			}

			cameraObject.transform.localPosition = new Vector3(0f, pos.y, 0f);
		}

		if (lTrigger1 >= 0.11f && lTrigger1 < 0.8f)
		{
			//Debug.Log("’†");
			if (pos.y >= -4f)
			{
				posVal = posVal - squatspeed;
				pos.y = posVal;
			}
			if (pos.y <= -3.9f)
			{
				posVal = posVal + squatspeed;
				pos.y = posVal;
			}

			cameraObject.transform.localPosition = new Vector3(0f, pos.y, 0f);
		}

		if (lTrigger1 >= 0.81f)
		{
			//Debug.Log("‹­");
			posVal = posVal - squatspeed;
			pos.y = posVal;

			if (pos.y <= -8f)
			{
				pos.y = -8f;
				posVal = -8f;
			}

			cameraObject.transform.localPosition = new Vector3(0f, pos.y, 0f);
		}
	}
}