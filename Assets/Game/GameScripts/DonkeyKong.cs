using UnityEngine;
using System.Collections;

public class DonkeyKong : MonoBehaviour {
	Animator anim;
	Transform barrelSpawnPos;
	public GameObject pauline;
	private bool barrel = true; 
	private bool animPlay = true;
	public float timetoThrow;

	//level 2 set
	bool level2Move = false;
	bool Right = false;

	public enum KongLevel{
		Level1, Level2, Level3, Level4
	}
	public KongLevel LevelAction;
	
	void Start () {
		
		anim = gameObject.GetComponent<Animator>();
		barrelSpawnPos = gameObject.transform.Find("BarrelSpitter");
		switch (LevelAction)
		{
			case KongLevel.Level1:
				StartCoroutine(SpawnBarrel(1.0f));
				break;
			case KongLevel.Level2:
				level2Move = true;
				//	anim.SetTrigger("ThrowBarrel");
				//	StartCoroutine(SpawnBarrel(timetoThrow));
				break;
			case KongLevel.Level3:
				StartCoroutine(SpawnBarrel(1.0f));
				//	anim.SetTrigger("ThrowBarrel");
				//	StartCoroutine(SpawnBarrel(timetoThrow));
				break;
			case KongLevel.Level4:
				//	anim.SetTrigger("ThrowBarrel");
				//	StartCoroutine(SpawnBarrel(timetoThrow));
				break;
		}
	}

	void Update (){
        if (!pauline.GetComponent<PaulineScript>().EndingScene)
        {
			if (pauline.GetComponent<PaulineScript>().DKhaul && animPlay)
			{
				anim.SetBool("End", true);
				anim.ResetTrigger("ThrowBarrel");
				barrel = false;
				animPlay = false;
			}
			else
			{
				if (level2Move && animPlay)
				{
					if (Right)
					{
						transform.Translate(Vector2.right * Time.deltaTime, Space.World);
					}
					else
					{
						transform.Translate(-Vector2.right * Time.deltaTime, Space.World);
					}

				}

			}
        }
        else
        {
			anim.SetBool("Ending", true);
			anim.applyRootMotion = true;
            if (!GetComponent<Rigidbody2D>())
            {
				gameObject.AddComponent<Rigidbody2D>();
			}
			
        }
	
		
	}
	
	IEnumerator SpawnBarrel(float delay) {
		yield return new WaitForSeconds(delay);
		if (barrel){
            switch (LevelAction)
            {
				case KongLevel.Level1:
					anim.SetTrigger("ThrowBarrel");
					StartCoroutine(SpawnBarrel(timetoThrow));
					break;
				case KongLevel.Level2:
					level2Move = true;
				//	anim.SetTrigger("ThrowBarrel");
				//	StartCoroutine(SpawnBarrel(timetoThrow));
					break;
				case KongLevel.Level3:
						anim.SetTrigger("ThrowBarrel");
						StartCoroutine(SpawnBarrel(timetoThrow));
					break;
				case KongLevel.Level4:
				//	anim.SetTrigger("ThrowBarrel");
				//	StartCoroutine(SpawnBarrel(timetoThrow));
					break;
			}
		
		
		}
	}
	
	public void ReleaseBarrel() {
		
		GameObject barrel = Instantiate(Resources.Load ("BarrelPrefab")) as GameObject;
		barrel.transform.parent = transform;
		barrel.transform.localPosition = barrelSpawnPos.localPosition;
		barrel.name = "Barrel";
	}
	
	public void Stop() {
		anim.StopPlayback();
		Destroy (this);
	}
	void OnCollisionEnter2D(Collision2D collision)
	{

		//float force = 150.0f;

		if (collision.gameObject.tag == "LeftSide")
		{
			Right = true;
		}
		else if (collision.gameObject.tag == "RightSide")
		{
			Right = false;
		}
	}
}
