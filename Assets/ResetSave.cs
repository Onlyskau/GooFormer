using UnityEngine;
using System.Collections;

public class ResetSave : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		
		PlayerPrefs.DeleteKey("UnlockLevel2");
		
	}
}
