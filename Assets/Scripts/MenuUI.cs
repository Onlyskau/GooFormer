using UnityEngine;
using System.Collections;

public class MenuUI : MonoBehaviour {



	// Scaling
	float difference = 1;

	// Use this for initialization
	void Start () {
	
	}


	void FixedUpdate () {
		
		difference = (Screen.width / 12.8f) / 100;
	}


	// Update is called once per frame
	void Update () {
	
	}


}
