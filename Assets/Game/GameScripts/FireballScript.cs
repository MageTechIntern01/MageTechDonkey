using UnityEngine;
using System.Collections;

public class FireballScript : MonoBehaviour {
	// Update is called once per frame
	public bool goUp = true;
	
	void Update () {
		if (goUp){
			transform.Translate(Vector2.right * Time.deltaTime, Space.World);
		} else {
			transform.Translate(-Vector2.right * Time.deltaTime, Space.World);
		}
	//	} else transform.Translate(Vector2.right * Time.deltaTime, Space.World);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		
		//float force = 150.0f;
		
		if (collision.collider.gameObject.name == "LeftWall") {
			goUp = true;
		}
		else if (collision.collider.gameObject.name == "RightWall") {
			goUp = false; 
		}
	}
	void OnTriggerEnter2D(Collider2D collision)
	{

		//float force = 150.0f;

		if (collision.gameObject.tag == "LeftSide")
		{
			goUp = true;
		}
		else if (collision.gameObject.tag == "RightSide")
		{
			goUp = false;
		}
	}
}
