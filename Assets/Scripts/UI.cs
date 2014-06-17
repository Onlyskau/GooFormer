using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	// Looking for player
	Player playerScript;
	GameObject player;
	bool foundPlayer = false;


	// Scaling
	float difference = 1;
	

	// Image Test
	public Texture aImage;

	// Choose Level
	public string ThisLevel;

	// Pause
	bool Pause = false;


	// Use this for initialization
	void Start () {

		Screen.showCursor = false;
	
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

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(!Pause)
			{
				Pause = true;
				Time.timeScale = 0;
				Screen.showCursor = true;
			} else {
				Pause = false;
				Time.timeScale = 1;
				Screen.showCursor = false;
			}

		}

	}

	void OnGUI() {

		if(player || playerScript.PlayerDead == true)
		{

			GUI.Box(new Rect(20 * difference, 10 * difference, 80 * difference, 40 * difference), "Health");
			GUI.Box(new Rect(20 * difference, 30 * difference, 80 * difference, 40 * difference), playerScript.HealthTracker.ToString());

			GUI.Box(new Rect(20 * difference, 80 * difference, 80 * difference, 40 * difference), "Goo");
			GUI.Box(new Rect(20 * difference, 100 * difference, 80 * difference, 40 * difference), playerScript.Goo.ToString());

			if(playerScript.PlayerDead == true)
			{

				Screen.showCursor = true;

				GUI.Box(new Rect(600 * difference, 300 * difference, 80 * difference, 20 * difference), "You are dead :(");
				if(GUI.Button(new Rect(600 * difference, 400 * difference, 80 * difference, 20 * difference), "Try Again"))
				{
					Application.LoadLevel(ThisLevel);
				}
				if(GUI.Button(new Rect(600 * difference, 450 * difference, 80 * difference, 20 * difference), "Exit"))
				{
					Application.LoadLevel("Menu");
				}

				// Lille tester

				Rect Test = new Rect(1000 * difference, 0 * difference, 100 * difference, 100 * difference);
				GUI.DrawTexture(Test, aImage, ScaleMode.ScaleToFit, true, 0F);
				if(Input.GetMouseButton(0))
				{
					if (Test.Contains(Event.current.mousePosition)) Application.LoadLevel(ThisLevel);
				}


			}

			// Pause

			if(Pause && playerScript.PlayerDead == false)
			{
				GUI.Box(new Rect(600 * difference, 300 * difference, 80 * difference, 20 * difference), "Paused");
				if(GUI.Button(new Rect(600 * difference, 400 * difference, 80 * difference, 20 * difference), "Reset"))
				{
					Application.LoadLevel(ThisLevel);
				}
				if(GUI.Button(new Rect(600 * difference, 450 * difference, 80 * difference, 20 * difference), "Exit"))
				{
					Application.LoadLevel("Menu");
				}


			}

		}

	}


}
