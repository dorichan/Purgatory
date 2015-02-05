using UnityEngine;
using System.Collections;

public class CharacterDeath : MonoBehaviour 
{
	public bool goingHell;

	private GameManager gameManager;

	void Start()
	{
		goingHell = false;

		gameManager = GameObject.FindWithTag ("GameManager").GetComponent<GameManager> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == GameObject.FindWithTag ("SuicideZone")) {
			gameManager.levelNum += 1;
			gameManager.deaths += 1;
			goingHell = true;
			gameManager.isDead = true;
		}
	}
}