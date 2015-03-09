using UnityEngine;
using System.Collections;
namespace UnitySampleAssets._2D{
	public class MoveTrail : MonoBehaviour {

		public int moveSpeed = 1;
		bool faceRight  =PlatformerCharacter2D.faceRight;
		// Update is called once per frame
		void Update () {
			if (faceRight){
				transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
			}else{
				transform.Translate (Vector3.left * Time.deltaTime * moveSpeed);
			}
		}
		void OnCollisionEnter2D(Collision2D other){
				Destroy(gameObject);
		}
	}
}