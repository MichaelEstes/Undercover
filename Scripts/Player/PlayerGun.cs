using UnityEngine;
using System.Collections;

public class PlayerGun : MonoBehaviour {

	//public Transform gunStart;
	private GameObject bullet;
	public GameObject bulletClone;

	void Start () {
		bullet = GameObject.FindGameObjectWithTag ("Projectile");
	}
	
	void Update () {
	
	}

	public void Shoot(){
		bulletClone = Instantiate (bullet, this.transform.position, this.transform.rotation) as GameObject;
	}
}
