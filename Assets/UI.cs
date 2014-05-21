using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	// Looking for player
	Player playerScript;
	GameObject player;
	bool foundPlayer = false;


	// Scaling
	float difference = 1;

	// Death
	public GameObject DeadText;

	// Use this for initialization
	void Start () {
	
	}
	

	void FixedUpdate () {

		difference = (Screen.width / 12.8f) / 100;
	}



	void Update () {
	
		if(!player)														
			player = GameObject.FindWithTag("Player");					
		else if(player && !foundPlayer){
			foundPlayer = true;
			playerScript = player.GetComponent<Player>();
		}

		if(playerScript.HealthTracker == 0)
		{
			GameObject Dead = Instantiate(DeadText, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
		}
	}

	void OnGUI() {

		GUI.Box(new Rect(20 * difference, 20 * difference, 80 * difference, 40 * difference), playerScript.HealthTracker.ToString());

		GUI.Box(new Rect(20 * difference, 80 * difference, 80 * difference, 40 * difference), playerScript.Goo.ToString());

	}
}
