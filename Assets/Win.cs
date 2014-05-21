using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){	
		if(other.gameObject.tag == "Player"){						

			PlayerPrefs.SetInt("UnlockLevel2",1);
			Application.LoadLevel("Level Select");
		}
	}
}
