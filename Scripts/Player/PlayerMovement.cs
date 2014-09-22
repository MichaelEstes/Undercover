using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public const float walkingSpeed = 5;
	public const float runningSpeed = 10;
	public Vector3 playerPosOld;
	public enum MovementState{ walking, running, sneaking, stopped};
	public MovementState movementState;


	void Start () {
		movementState = MovementState.stopped;
		playerPosOld = this.transform.position;
	}
	
	void Update () {

		if(playerPosOld == this.transform.position){
			SetMovementState(MovementState.stopped);
		}else{
			playerPosOld = this.transform.position;
			if(speed == runningSpeed){
				SetMovementState(MovementState.running);
			}else{
				SetMovementState(MovementState.walking);
			}
		}

		if(Input.GetButton ("Fire2")){
			speed = runningSpeed;
	    }else{
			speed = walkingSpeed;
		}


		if (Input.GetKey (KeyCode.A)) {
			MovePlayer(Vector3.left);
		}
		if (Input.GetKey (KeyCode.D)) {
			MovePlayer(Vector3.right);
		}
		if (Input.GetKey (KeyCode.W)) {
			MovePlayer(Vector3.up);
		}
		if (Input.GetKey (KeyCode.S)) {
			MovePlayer(Vector3.down);
		}

	}

	void SetMovementState(MovementState newState){
		movementState = newState;
	}

	void MovePlayer(Vector3 direction){
		transform.position += direction * speed * Time.deltaTime;
	}


}
