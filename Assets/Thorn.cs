using UnityEngine;
using System.Collections;

public class Thorn : MonoBehaviour {

	protected int damage;

	// Use this for initialization
	void Start () {
	
		damage = 5;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){	
		if(other.gameObject.tag == "Player"){						

			Player playerScript = other.gameObject.GetComponent<Player>();									
			playerScript.TakeDamage(damage);

		}
	}
}
