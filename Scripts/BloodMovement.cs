using UnityEngine;
using System.Collections;

public class BloodMovement : MonoBehaviour {

	public Vector2 randomDir;
	public Vector2 stop = new Vector2(0,0);
	public float bloodSpeed = 20.0f;
	public float bloodTime = 0.05f;
	public float timer;
	
	void Start () {
		//Restart timer for each particle, get random direction
		timer = 0;
		randomDir.x = Random.Range (-0.5f, 0.5f);
		randomDir.y = Random.Range (-0.5f, 0.5f);
	}
	
	void Update () {
		//Move blood in random direction until timer is up
		if(timer < bloodTime){
			rigidbody2D.velocity += randomDir * bloodSpeed;
			timer += 1 * Time.deltaTime;
		}else{
			rigidbody2D.velocity = stop;
		}
	}
}
