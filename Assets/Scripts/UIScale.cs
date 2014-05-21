using UnityEngine;
using System.Collections;

public class UIScale : MonoBehaviour {


	// Position
	public float x;
	public float y;

	// Scaling
	float difference = 1;

	// Use this for initialization
	void Start () {
	
	}


	void FixedUpdate () {
		
		difference = (Screen.width / 12.8f) / 100;
		transform.position = new Vector3(x * difference,y * difference,0);
	}


	// Update is called once per frame
	void Update () {
	
	}


}
