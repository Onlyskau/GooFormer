using UnityEngine;
using System.Collections;

public class Level2 : MonoBehaviour {
	
	public string levelToLoad;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseUp(){
		
		if(PlayerPrefs.GetInt("UnlockLevel2",0) == 1){
			Application.LoadLevel(levelToLoad);
		}
	}
}
