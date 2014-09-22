using UnityEngine;
using System.Collections;

public class Human : MonoBehaviour {

	public bool alive = true;
	public float health = 100;
	public Rigidbody2D bloodParticle;
	public Rigidbody2D bloodParticleClone;

	void Start () {

	}
	
	void Update () {
	
	}

	public void TakeDamage(int damage, Vector3 hitPos, int bloodCount) {
		//Bleed(hitPos);
		StartCoroutine (Bleed(bloodCount , hitPos));
		if(alive){
			health -= damage;
			if (health <= 0) {
				Die();
			}
		}
	}

	IEnumerator Bleed(int bloodCount, Vector3 hitPos){
		for(int i = 0; i < bloodCount; ++i){
			bloodParticleClone = (Rigidbody2D)Instantiate (bloodParticle, hitPos, Quaternion.Euler(0,0, Random.Range(0, 90)));
		}
		yield return null;
	}

	public virtual void Die(){}

}
