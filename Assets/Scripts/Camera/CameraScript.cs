//<Summary>
//This is a script for controlling the camera. It makes sure that the camera is always
//centered on a player.
//</Summary>

using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	GameObject player;
	public float startValue = 4f;
	public float endValue = 4.4f;

	public float startTime = 0.2f;
	float duration = 1.5f;

	float ScaleTime; 		

	bool Zoom = true;


	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");						
	}
	
	// Update is called once per frame
	void Update () {


		if(!player){													
			player = GameObject.FindWithTag("Player");					
		}	else {															
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
		}




		if(Zoom)
		{
			float i = (Time.time - startTime) / duration;
			Camera.main.orthographicSize = Mathf.Lerp(endValue, startValue, i);
		} else {
			float i = (Time.time - startTime) / duration;
			Camera.main.orthographicSize = Mathf.Lerp(startValue, endValue, i);
		}
		
	}

	public void ZoomIn () {
		Zoom = true;
	}

	public void ZoomOut () {
		Zoom = false;
	}
}
