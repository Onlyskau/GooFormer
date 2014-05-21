using UnityEngine;
using System.Collections;

public class GooOrb : MonoBehaviour {

	float PickUpCD;

	// Use this for initialization
	void Start () {
		PickUpCD = 0.2f + Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){	
		if(other.gameObject.tag == "Player"){						
			Player playerScript = other.gameObject.GetComponent<Player>();

			if(PickUpCD < Time.time && playerScript.Goo <= 20)
			{								
				playerScript.Grow();
				Destroy(gameObject);
			}
			
		}

		if(other.gameObject.tag == "GroundTrigger"){						
			Destroy(gameObject);
				
		}

		if(other.gameObject.tag == "DangerousGround"){						
			Destroy(gameObject);
			
		}
	}
}
