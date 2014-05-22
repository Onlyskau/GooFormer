using UnityEngine;
using System.Collections;

public class PlayExit : MonoBehaviour {
	
	
	public string levelToLoad;
	public bool QuitButton = false;
	
	// Use this for initialization
	void Start () {
	
	}
	

	
	void OnMouseUp(){
	
		if(QuitButton){
			Application.Quit();
		}
		else{
			Application.LoadLevel(levelToLoad);
			
		}
	}
}
