//<Summary>
//This is a script for controlling the camera. It makes sure that the camera is always
//centered on a player.
//</Summary>

using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	GameObject player;
	float startValue = 2;
	float endValue = 4;

	float startTime = 0.2f;
	float duration = 1f;

	float ScaleTime = 0.1f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");						
	}
	
	// Update is called once per frame
	void Update () {


		float i = (Time.time - startTime) / duration;
		Camera.main.orthographicSize = Mathf.Lerp(startValue, endValue, i);

		if(!player){													
			player = GameObject.FindWithTag("Player");					
		}	else {															
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
		}

		Player playerScript = player.gameObject.GetComponent<Player>();

		if(playerScript.Goo <= 3)
		{
			if(endValue != 1)
				startTime = ScaleTime + Time.time;

			
			if(endValue == 2)
				startValue = 2f;
			
			endValue = 1f;

		} else if(playerScript.Goo <= 6 && playerScript.Goo >= 3){

			if(endValue != 2)
				startTime = ScaleTime + Time.time;

			if(endValue == 1)
				startValue = 1f;
			
			if(endValue == 3)
				startValue = 3f;
			
			endValue = 2f;

		} else if(playerScript.Goo <= 9 && playerScript.Goo >= 6){

			if(endValue != 3)
				startTime = ScaleTime + Time.time;
			
			if(endValue == 2)
				startValue = 2f;
			
			if(endValue == 4)
				startValue = 4f;
			
			endValue = 3f;

		} else if(playerScript.Goo <= 12 && playerScript.Goo >= 9){

			if(endValue != 4)
				startTime = ScaleTime + Time.time;

			if(endValue == 3)
				startValue = 3f;

			if(endValue == 5)
				startValue = 5f;

			endValue = 4f;
			
		} else if(playerScript.Goo <= 15 && playerScript.Goo >= 12){

			if(endValue != 5)
				startTime = ScaleTime + Time.time;
			
			if(endValue == 4)
				startValue = 4f;
			
			if(endValue == 6)
				startValue = 6f;
			
			endValue = 5f;
			
		} else if(playerScript.Goo <= 18 && playerScript.Goo >= 15){

			if(endValue != 6)
				startTime = ScaleTime + Time.time;
			
			if(endValue == 5)
				startValue = 3f;
			
			if(endValue == 7)
				startValue = 5f;
			
			endValue = 6f;
			
		}else if(playerScript.Goo <= 20 && playerScript.Goo >= 18){

			if(endValue != 7)
				startTime = ScaleTime + Time.time;
			
			if(endValue == 6)
				startValue = 3f;

			
			endValue = 7f;
			
		}

	}
}
