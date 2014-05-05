using UnityEngine;
using System.Collections;

public class GooOrb : MonoBehaviour {

	float PickUpCD;
	public GameObject MrGoo;

	// Use this for initialization
	void Start () {
		PickUpCD = 0.2f + Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){	
		if(other.gameObject.tag == "Player"){						

			if(PickUpCD < Time.time)
			{
				Player playerScript = other.gameObject.GetComponent<Player>();									
				playerScript.Goo += 1;
				// lav function i player
				Destroy(gameObject);
			}
			
		}
	}
}
