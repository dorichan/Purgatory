using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public float speed = 10.0f;

	private Transform player;

	void Awake()
	{
		player = GameObject.FindWithTag("Player").transform;
	}

	void Update()
	{
		FollowPlayer();
	}

	void FollowPlayer()
	{
		float xMovement = Input.GetAxis ("Horizontal");
//		float yMovement = Input.GetAxis ("Vertical");

		Vector3 direction = player.transform.position - transform.position;
		direction.z = -10.0f;

		// Need a Lerp so that the camera doesn't stop so suddenly
		if(xMovement > 0) {
			transform.position += direction.normalized * speed * Time.deltaTime;
		}
		if(xMovement < 0) {
			transform.position += direction.normalized * speed * Time.deltaTime;
		}
	}
}