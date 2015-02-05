using UnityEngine;
using System.Collections;

public class CharacterMemories : MonoBehaviour 
{
	public bool hasObject;
	public bool goingHeaven;
	public bool isClose;

	private int maxClick = 0;

	private GameManager gameManager;

	void Start () 
	{
		hasObject = false;
		goingHeaven = false;
		isClose = false;

		gameManager = GameObject.FindWithTag ("GameManager").GetComponent<GameManager> ();
	}

	void Update()
	{
		if (hasObject) {
			goingHeaven = true;
		}

		if (maxClick < 1 && isClose == true && Input.GetKeyDown (KeyCode.E)) {
			Debug.Log ("E Pressed");
			gameManager.isDead = true;
			gameManager.levelNum += 1;
			gameManager.memories += 1;
			hasObject = false;
			maxClick += 1;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject == GameObject.FindWithTag("NPC")) {
			Debug.Log ("Hello");
			isClose = true;
		}
	}
}
