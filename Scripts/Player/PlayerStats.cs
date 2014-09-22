using UnityEngine;
using System.Collections;

public class PlayerStats : Human {

	public int magazines = 3;
	public int startAmmo = 9;
	public int ammo = 9;
	public int notoriety = 0;
	public float timer = 0;
	public float reloadTime = 2;
	public float shootTime = 0.3f;
	public bool waiting = false;
	public bool reloading = false;
	public PlayerGun gun;
	public TextMesh ammoTextMesh;
	public TextMesh magTextMesh;

	void Start () {
		ammoTextMesh.renderer.sortingLayerName = "UI";
		magTextMesh.renderer.sortingLayerName = "UI";
		SetText(ammoTextMesh, ammo);
		SetText(magTextMesh, magazines);

	}
	
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			if(ammo > 0 && !waiting){
				gun.Shoot();
				Shot();
				waiting = true;
			}
		}
		if(waiting && timer < shootTime){
			timer += 1 * Time.deltaTime;
		}else{
			waiting = false;
			timer = 0;
		}
	}
	
	void Shot(){
		if (notoriety == 0) {
			SetNotoriety(1);
		}
		ammo -= 1;
		SetText(ammoTextMesh, ammo);
		if (ammo == 0 && magazines > 0) {
			StartCoroutine (Reload());
		}
	}
	
    void SetText(TextMesh textMesh, int text){
		textMesh.text = text.ToString ();
	}

	public void SetNotoriety(int setNum){
		notoriety = setNum;
	}
	
//	public void TakeDamage(int dmg) {
//		health -= dmg;
//		if (health <= 0) {
//			alive = false;
//		}
//	}

	IEnumerator Reload(){
		reloading = true;
		yield return new WaitForSeconds (reloadTime);
		magazines -= 1;
		SetText(magTextMesh, magazines);
		ammo = startAmmo;
		SetText(ammoTextMesh, ammo);
		reloading = false;
	}

}
