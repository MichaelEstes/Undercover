using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public int yOffSet =  5;
	public float smoothTime = 0.1f;
	private Vector3 velocity = Vector3.zero;
	private Transform player;

	void Start(){
		player = GameObject.Find ("Player").transform;
	}

	void Update () {
		Vector3 playerPos = player.position;
		playerPos.z = -10;
		playerPos.y += yOffSet;
		transform.position = Vector3.SmoothDamp (transform.position, playerPos, ref velocity, smoothTime);
	}

	public void SetDirection(int direction){
		yOffSet = direction;
	}
}
