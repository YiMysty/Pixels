using UnityEngine;
using System.Collections;
namespace UnitySampleAssets._2D
{
public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask whatToHit;

	public Transform BulletTrailPrefab;

	float timeToFire = 0;
	Transform firePoint;
	
	bool faceRight  =PlatformerCharacter2D.faceRight;

	// Use this for initialization
	void Awake () {
		firePoint = this.transform;
		if (firePoint == null) {
			Debug.LogError ("No firepoint? WHAT?!");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (fireRate == 0) {
			if (Input.GetKeyDown (KeyCode.Z)) {
				Shoot();
			}
		}
		else {
			if (Input.GetKeyDown(KeyCode.Z) && Time.time > timeToFire) {
				timeToFire = Time.time + 1/fireRate;
				Shoot();
			}
		}
	
	}

	void Shoot() {
		// Debug.Log ("Fire!");
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
			RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
		if(PlatformerCharacter2D.mode==TypeMode.GUNSPONGE){
			Effect ();
		}

//		Debug.DrawLine (firePointPosition, (mousePosition-firePointPosition)*100, Color.cyan);
//		if (hit.collider != null) {
//			Debug.DrawLine (firePointPosition, hit.point, Color.red);
//			Debug.Log ("We hit " + hit.collider.name + "and did " + Damage + " damage.");
//		}
	}
	
	void flipRPG(){
		Vector3 theScale = BulletTrailPrefab.localScale;
		theScale.x *= -1;
		BulletTrailPrefab.localScale = theScale;
	}
	
	void Effect(){
		if (faceRight && BulletTrailPrefab.localScale.x<0){
			flipRPG();
		}
		if (!faceRight && BulletTrailPrefab.localScale.x>0){
			flipRPG();
		}
		Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);
	}
}
}