using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {

	public int speed =  20;
	public const int meleeDamage = 100;
	public const int meleeBlood = 40;
	public float step;
	public Transform target;
	private RaycastHit2D actionCheck;
	public LayerMask actionMask;
	public GameObject humanShield;

	void Start () {
		humanShield = null;
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			Action ();
		}
		if(humanShield){
			step = speed * Time.deltaTime;
			humanShield.transform.position = target.transform.position;
			humanShield.transform.rotation = target.transform.rotation;
			if(!humanShield.GetComponent<Human>().alive){
				humanShield = null;
			}
		}
	}

	void Action(){
		if(!humanShield){
			actionCheck = Physics2D.Raycast (this.transform.position, this.transform.right, 1.5f, actionMask);
			if(actionCheck){
				//Debug.Log(actionCheck.collider.tag);
				if(actionCheck.collider.GetComponent<Human>()){
					if(actionCheck.collider.GetComponent<Human>().alive){
						humanShield = actionCheck.collider.gameObject;
						//Debug.Log (humanShield.name);
					}
				}
			}
	    }else if(humanShield){
			humanShield.GetComponent<Human>().TakeDamage(meleeDamage, humanShield.transform.position, meleeBlood);
			humanShield = null;
		}
    }
}
