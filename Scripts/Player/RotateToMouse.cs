using UnityEngine;
using System.Collections;

public class RotateToMouse : MonoBehaviour {

	public int direction = 7;
	public float angle;
	public float rotationSpeed = 6.5f;
	public Vector2 mousePos;


	void Start () {
	}
	
	void Update () {
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePos.x = mousePos.x - this.transform.position.x;
		mousePos.y = mousePos.y - this.transform.position.y;
		angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler (new Vector3 (0, 0, angle)), rotationSpeed * Time.deltaTime);
		if(angle < -10 && angle > -170){
			Camera.main.GetComponent<CameraFollow>().SetDirection(-direction);
		}else if(angle > 10 && angle < 170){
			Camera.main.GetComponent<CameraFollow>().SetDirection(direction);
		}
	}
}
