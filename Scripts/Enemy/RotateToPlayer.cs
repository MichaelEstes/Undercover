using UnityEngine;
using System.Collections;

public class RotateToPlayer : MonoBehaviour {

	public float angle;
	public float rotationSpeed = 6.5f;
	public Vector2 targetPos;

	public void Rotate() {
		targetPos = GameObject.Find("Player").transform.position;
		targetPos.x = targetPos.x - this.transform.position.x;
		targetPos.y = targetPos.y - this.transform.position.y;
		angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler (new Vector3 (0, 0, angle)), rotationSpeed * Time.deltaTime);
	
	}
}
