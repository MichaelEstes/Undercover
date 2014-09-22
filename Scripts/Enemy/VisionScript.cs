using UnityEngine;
using System.Collections;

public class VisionScript : EnemyUpdate {

	public bool playerTrigger;
	public Vector3 rayDirection;
	public Transform rayTarget;
	public RaycastHit2D lineOfSight;
	public LayerMask maskCone;

	void Start(){
		playerTrigger = false;
		playerSeen = true;
	}

	void Update(){
		if(playerTrigger){
			rayDirection = rayTarget.position - this.transform.position;
		    lineOfSight = Physics2D.Raycast(this.transform.position, rayDirection, 20.0f, maskCone);
			if(lineOfSight.collider.tag == "Player"){
				playerSeen = true;
				rayDistance = Vector2.Distance (this.transform.position, lineOfSight.point);
			}else if(lineOfSight.collider.tag != null){
				playerSeen = false;
			}
		}else if(!playerTrigger){
			playerSeen = false;
		}
	}

	public void EndVision(){
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag == "Player"){
			rayTarget = collider.gameObject.transform;
			playerTrigger = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D collider){
		if(collider.gameObject.tag == "Player"){
			playerTrigger = false;
		}
	}
}
