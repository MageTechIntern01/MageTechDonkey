using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorHandle : MonoBehaviour
{
	public PaulineScript Pauline;
	public GameObject explosionPrefab;
	public GameObject contextScore;

	void Start()
	{
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if (otherCollider.gameObject.tag == "Player")
		{
			Pauline.RemovefromList(gameObject);
			Destroy(gameObject);
			GameObject explosionObject = Instantiate(this.explosionPrefab) as GameObject;
			explosionObject.transform.position = this.transform.position;

			GameObject tempTextBox = Instantiate(this.contextScore) as GameObject;
			tempTextBox.transform.position = this.transform.position;

			TextMesh theText = tempTextBox.transform.GetComponent<TextMesh>();
			theText.text = "100";

			PlayerData.Instance.Score += 100;
			
		}
	}

	void FixedUpdate()
	{

	}

}
