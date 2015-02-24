using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float patrolSpeed = 2f;                          // The nav mesh agent's speed when patrolling.
	
	//private EnemySight enemySight;                          // Reference to the EnemySight script.
	//private NavMeshAgent nav;                               // Reference to the nav mesh agent.
	private bool isStomp;
	private bool fall;
	private Transform player;                               // Reference to the player's transform.
	private float headSize;
	//private PlayerHealth playerHealth;                      // Reference to the PlayerHealth script.
	private float patrolTimer;                              // A timer for the patrolWaitTime.
	private float startPoint;
	private float patrolDistance;
	public float playerpos;


	void Start() 
	{
		isStomp = false;
		fall = true;
		player = GameObject.Find("Player").transform;
		headSize = GetComponent<BoxCollider2D>().size.x;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		// if collision on top -> dead
		// if collision on left or right -> cause player dead
		// if collision on bottom -> update standing platform
		if (this.transform.position.y > other.transform.position.y) {
			startPoint = other.transform.position.x;
			patrolDistance = 0.5f * other.gameObject.GetComponent<BoxCollider2D> ().size.x;
		} else if (other.gameObject.tag == "Player" &&
		           this.transform.position.x + headSize > other.transform.position.x &&
		           this.transform.position.x - headSize < other.transform.position.x &&
		           this.transform.position.y < (other.transform.position.y - 0.61)){
			gameObject.SetActive(false);
			//isStomp = true;
		}
	}

	void FixedUpdate ()
	{
		if (isStomp) {
			isStomp = false;
			fall = true;
			Vector3 scale = this.transform.localScale;
			scale.y /= 2;
			this.transform.localScale = scale;
			GetComponent<BoxCollider2D>().enabled = false;
		}
		else
			Patrolling();

		if (fall) {
			this.transform.Translate(0f, -0.5f * Time.deltaTime, 0f);
		}

		if (this.transform.position.y < -30)
			gameObject.SetActive (false);
	}
	
	void Patrolling ()
	{
		Transform boo = GetComponent<Transform>();
		
		if (boo.localPosition.x > startPoint - patrolDistance &&
		    boo.localPosition.x < startPoint + patrolDistance)
		{
			// move toward patrol position
			boo.Translate(patrolSpeed * Time.deltaTime, 0f, 0f);
		}
		else {
			patrolSpeed = -patrolSpeed;
			// NEED TO UPDATE MIRROR SPRITE
			boo.Translate(patrolSpeed * Time.deltaTime, 0f, 0f);
		}
	}
}
