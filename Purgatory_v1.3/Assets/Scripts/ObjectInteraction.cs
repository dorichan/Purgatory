using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour 
{
	private CharacterMemories characterMemories;
	public bool isClose;

	void Start()
	{
		isClose = false;
		characterMemories = GameObject.FindWithTag ("Player").GetComponent<CharacterMemories> ();
	}

	void Update()
	{
		if (isClose && Input.GetKey(KeyCode.E)) {
			Destroy(this.gameObject);
			characterMemories.hasObject = true;

		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject == GameObject.FindWithTag("Player")) {
			isClose = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject == GameObject.FindWithTag("Player")) {
			isClose = false;
		}
	}
}