using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	GameObject Octenemy;
	GameObject snailenemy;
	// Use this for initialization
	void Start () {
		GameManager.GameStart += GameStart;
		GameManager.GameOver += GameOver;
		Octenemy = GameObject.Find ("enemyOct");
		//snailenemy = GameObject.Find ("enemy2");
		for (int i=0; i<20; i++) {
			generateEnemy(Octenemy,new Vector2(Octenemy.transform.localPosition.x+(float)i*8f,Octenemy.transform.localPosition.y+Random.Range(-20f,20f)),0,100);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
	void generateEnemy(GameObject o,Vector2 pos,int up,int down){ //left distance and right distance.
		GameObject oo = (GameObject)Instantiate (o, pos, new Quaternion());
		oo.GetComponent<Enemy> ().x1 = up;
		oo.GetComponent<Enemy> ().x2 = down;

	}
	void GameStart(){

	}
	void GameOver(){

	}
}
