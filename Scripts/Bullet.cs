using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int bulletDamage = 50;
	public const int bulletBlood = 20;
	public float bulletSpeed = 2000;
	public Vector2 direction;

	//public Texture2D hitTexture;
	//public Color hitColor;

	void Start () {
		if(this.gameObject.name != "Bullet"){
			direction = this.transform.right;
			this.rigidbody2D.AddForce(direction * bulletSpeed);
			Destroy (this.gameObject, 3.0f);
		}
	}
	
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collider){
		//hitTexture = collider.renderer.material.mainTexture as Texture2D;
		//hitColor = hitTexture.GetPixel (0, 0);
		if(!collider.isTrigger){
			if(collider.GetComponent<Human>()){
				collider.GetComponent<Human>().TakeDamage(bulletDamage, this.transform.position, bulletBlood);
			}
			Destroy (this.gameObject);
		}
	}
}
