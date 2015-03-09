using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {
	
	GameObject anim;   //this is the explosion effect
	public int life;
	public float speed;
	public float x1;
	public float x2;
	private bool direction = false;
	private Transform playerGraphics;
	private int collideLife = 100;
	private long oldTime  = 0;
	void Start() 
	{
		GameManager.GameStart += GameStart;
		GameManager.GameOver  += GameOver;
		anim = this.transform.FindChild ("Explosion").gameObject;
		anim.gameObject.SetActive (false);
		playerGraphics = transform.FindChild ("Graphics");
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(gameObject!=null&&other!=null){
			if (other.gameObject.tag == "Player") {
				float SpongeY =other.transform.localPosition.y; 
				float enemeyY =this.transform.localPosition.y;
				if(enemeyY-SpongeY<3f){
					Destroy(gameObject);
				}
			} else  if(other.gameObject.name.IndexOf("BulletTrail")>=0){
				this.life-=1;
				if(this.life==0)
					gameObject.SetActive(false);
				else{
					anim.gameObject.SetActive (true);
					oldTime =long.Parse(GetTimeStamp(false));
				}
			}else{
				collideLife --;
			}
			direction = !direction;
			flip();
		}
		direction = !direction;
	}
	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.name.IndexOf ("BulletTrail") >= 0) {
			anim.gameObject.SetActive(false);
		}
	}
	void FixedUpdate (){
		if (!direction) {
			this.transform.Translate (new Vector2 (Time.deltaTime, 0f));
		}else{
			this.transform.Translate(new Vector2(0-Time.deltaTime,0f));
		}
		if (anim.activeSelf) {
			if(long.Parse(GetTimeStamp(false))-oldTime>500){
				anim.SetActive(false);
			}			
		}
	}
	
	void Patrolling (){

	}
	private void GameStart(){

	}
	private void GameOver(){

	}
	private void flip(){

		Vector3 theScale = playerGraphics.localScale;
		theScale.x *= -1;
		playerGraphics.localScale = theScale;
	}
	public static string GetTimeStamp(bool bflag = true)  
	{  
		TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);  
		string ret = string.Empty;  
		if (bflag)  
			ret = Convert.ToInt64(ts.TotalSeconds).ToString();  
		else  
			ret = Convert.ToInt64(ts.TotalMilliseconds).ToString();  
		return ret;  
	}
}
