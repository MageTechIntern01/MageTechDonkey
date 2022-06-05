using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class PaulineScript : MonoBehaviour {
	public GameObject player;
	Animator anim; 
	public AudioSource win;
	public AudioSource BackGround;
	public AudioClip Laugh;
	public bool DKhaul = false;
	public bool EndingScene = false;
	public List<GameObject> ObjectsToDisable;
	public List<GameObject> ObjectDestroyed;
	public SpriteRenderer Stage;
	public Sprite SceneStage;
	public bool LastLevel;
	public int LevelToLoad;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (LastLevel)
        {
			if(ObjectDestroyed.Count == 0 && !DKhaul)
            {
				BackGround.Stop();
				DKhaul = true;
				//player.GetComponent<MarioController>().endGame = true;
				player.GetComponent<MarioController>().SetStats(transform);
				EndingScene = true;
				Stage.sprite = SceneStage;
				anim.SetBool("End", true);
				for (int i = 0; i < ObjectsToDisable.Count; i++)
				{
					ObjectsToDisable[i].SetActive(false);
					
				}
				StartCoroutine(endLevel());
			}
        }
		}

	void OnTriggerEnter2D(Collider2D other){
		if  (player.GetComponent<MarioController>().endGame){
            if (!LastLevel)
            {
				anim.SetBool("End", true);
				win.Play();
				StartCoroutine(endsec());
            }
            else
            {
				EndingScene = true;
				BackGround.Stop();
				Stage.sprite = SceneStage;
				anim.SetBool("End", true);
				for (int i = 0; i < ObjectsToDisable.Count; i++)
                {
					ObjectsToDisable[i].SetActive(false);
					
				}
				StartCoroutine(endLevel());
			}
			
	}
	}

	public void RemovefromList(GameObject Game)
    {
		ObjectDestroyed.Remove(Game);

	}
	IEnumerator endLevel()
	{ 
		win.Play();
		yield return new WaitForSeconds(10);
		UnityEngine.SceneManagement.SceneManager.LoadScene(LevelToLoad);

	}
	IEnumerator endsec(){
			yield return new WaitForSeconds(2);
			DKhaul = true;
		BackGround.clip = Laugh;
		BackGround.loop = false;
		BackGround.Play();
		yield return new WaitForSeconds(1);
			this.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds(2);
		//Application.LoadLevel(0);
		UnityEngine.SceneManagement.SceneManager.LoadScene(LevelToLoad);

		}
}
