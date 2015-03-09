using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	GameObject anim;   //this is the explosion effect
	public int life;
	void Start() 
	{
		GameManager.GameStart += GameStart;
		GameManager.GameOver  += GameOver;
		anim = this.transform.FindChild ("Explosion").gameObject;
		anim.gameObject.SetActive (false);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(gameObject!=null&&other!=null){
			if (other.gameObject.tag == "Player") {
				float PlayerY = other.transform.gameObject.collider2D.transform.localPosition.y-other.transform.gameObject.collider2D.bounds.size.y/2;
				float myPosY =  this.transform.gameObject.collider2D.transform.localPosition.y+this.transform.gameObject.collider2D.bounds.size.y/2;
				Debug.Log(PlayerY+","+myPosY);
				if(PlayerY-myPosY>0.5f){
					Destroy(gameObject);
				}
			} else  if(other.gameObject.name.IndexOf("BulletTrail")>=0){
				this.life-=1;
					anim.gameObject.SetActive (true);
				if(this.life==0)
					gameObject.SetActive(false);
			}
		}
	}
	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.name.IndexOf ("BulletTrail") >= 0) {
			anim.gameObject.SetActive(false);
			other.gameObject.SetActive(false);
		}
	}
	void FixedUpdate ()
	{

	}
	
	void Patrolling ()
	{

	}
	private void GameStart(){

	}
	private void GameOver(){

	}
}
