using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	Player playerScript;
	GameObject player;
	bool foundPlayer = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(!player)														
			player = GameObject.FindWithTag("Player");					
		else if(player && !foundPlayer){
			foundPlayer = true;
			playerScript = player.GetComponent<Player>();
		}
	}

	void OnGUI() {

		GUI.Box(new Rect(Screen.width/2, Screen.height/8, 80, 40), playerScript.HealthTracker.ToString());

		GUI.Box(new Rect(Screen.width/2, Screen.height/5, 80, 40), playerScript.Goo.ToString());

	}
}
