using UnityEngine;
using System.Collections;

public class EnemyUpdate : Human{

	public bool playerSeen;
	private const float moveSpeed = 4.0f;
	public float rayDistance;
	public Vector3 playerPosOld;
	public Transform player;
	public RotateToPlayer rotate;
	public VisionScript vision;
	public BoxCollider2D[] enemyColliders;
	public Renderer[] enemyRenderer;

	void Start () {
		player = GameObject.Find ("Player").transform;
		bloodParticle = GameObject.FindGameObjectWithTag("Blood").rigidbody2D;
		alive = true;
		enemyColliders = this.gameObject.GetComponentsInChildren<BoxCollider2D> ();
		enemyRenderer = this.gameObject.GetComponentsInChildren<Renderer> ();
	}
	
	void Update () {
		if(vision.playerSeen){
			rotate.Rotate();
			Move();
		}
	}

	void Move (){
		if (vision.rayDistance > 5.1f){
			transform.position = Vector2.MoveTowards (transform.position, player.position, moveSpeed * Time.deltaTime);
		}else if (vision.rayDistance < 4.9f){ //&& !groundCollision){
			transform.position = Vector2.MoveTowards (transform.position, player.position, -moveSpeed * Time.deltaTime);
		}
		playerPosOld = player.position;
	}

	public override void Die(){
		alive = false;
		rotate.enabled = false;
		vision.EndVision ();
		vision.enabled = false;
		foreach(BoxCollider2D collider in enemyColliders){
			collider.enabled = false;
		}
		foreach(Renderer renderer in enemyRenderer){
			renderer.sortingLayerName = "Default";
		}
		this.enabled = false;
	}
}
