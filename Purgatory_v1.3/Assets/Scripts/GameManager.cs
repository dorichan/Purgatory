using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	private CharacterMemories characterMemories;
	public CharacterDeath characterDeath;
	public GameObject player;
	public bool isDead;
	public int memories;
	public int deaths;

	public int levelNum;
	public int maxLevels = 6;
	public string levelVersion;

	void Start()
	{
		deaths = 1;		// Deaths start at one 
		memories = 0;

		DontDestroyOnLoad (GameObject.FindWithTag ("GameManager"));
		levelNum = 1;
	}

	void Update()
	{
		if(isDead) {
			if(characterMemories.goingHeaven) {
				levelVersion = "heaven";
			}
			else if(characterDeath.goingHell) {
				levelVersion = "hell";
			}
			StartCoroutine("LoadNewLevel");
		}

		player = GameObject.Find ("Player");
		characterDeath = player.GetComponent<CharacterDeath> ();
		characterMemories = player.GetComponent<CharacterMemories> ();
	}

	IEnumerator LoadNewLevel()
	{
		yield return new WaitForSeconds(3);

		LoadLevel ();

	}

	void LoadLevel()
	{
		Application.LoadLevel ("level_" + levelNum + "_" + levelVersion);
		if(isDead == true && levelVersion != null) {
			isDead = false;
			characterDeath.goingHell = false;
			characterMemories.goingHeaven = false;
			levelVersion = "";
		}
		StopCoroutine ("LoadNewLevel");
	}
}