using UnityEngine;
using System.Collections;

public class PlatFormManager : MonoBehaviour {
	GameObject platForm ;
	GameObject platform_high_l1;
	GameObject platform_low_l1;
	GameObject smallCloudType1;
	GameObject smallCloudType2;

	ArrayList LowerPart = new ArrayList();
	ArrayList down      = new ArrayList();
	ArrayList right      = new ArrayList();
	ArrayList CloudType1    =  new ArrayList();
	ArrayList CloudType2    =  new ArrayList();
	float[] rightPos = new float[20];

	// Use this for initialization
	void Start () {
		platForm = GameObject.Find ("PlatformTest");
		for (int i=0; i<13; i++) {
			generatePlatform(new Vector2(platForm.transform.localPosition.x+(float)i*12f,0f),platForm);		
		}
		platform_high_l1 = GameObject.Find ("platform_high_l1");
		for (int i=0; i<20; i++) {
			generatePlatform(new Vector2(platform_high_l1.transform.localPosition.x+(float)i*7f+Random.Range(-2.0f, 2.0f),platform_high_l1.transform.localPosition.y+Random.Range(-1.5f, 1.5f)),platform_high_l1);		
		}
		platform_low_l1 = GameObject.Find ("platform_low_l1");
		for (int i=0; i<11; i++) {
			float xPos = platform_low_l1.transform.localPosition.x+(float)i*12f+Random.Range(-0.5f, 0.5f);
			float yPos = platform_low_l1.transform.localPosition.y+Random.Range(-0.5f, 0.5f);
			generatePlatform2(new Vector2(xPos, yPos), platform_low_l1);		
			rightPos[i] = xPos;
		}
		smallCloudType1 = GameObject.Find ("smallCloudType1");
		for (int i=0; i<10; i++) {
			float xPos = smallCloudType1.transform.localPosition.x+(float)i*12f+Random.Range(-2.5f, 2.5f);
			float yPos = smallCloudType1.transform.localPosition.y+Random.Range(-2.5f, 2.5f);
			//generatePlatform2(new Vector2(xPos, yPos), smallCloudType1);
			generateCloud(new Vector2(xPos, yPos), smallCloudType1,true);
			//rightPos[i] = xPos;
		}
		smallCloudType2 = GameObject.Find ("smallCloudType2");
		for (int i=0; i<10; i++) {
			float xPos = smallCloudType2.transform.localPosition.x+(float)i*12f+Random.Range(-2.5f, 2.5f);
			float yPos = smallCloudType2.transform.localPosition.y+Random.Range(-2.5f, 2.5f);
			generateCloud(new Vector2(xPos,yPos),smallCloudType2,true);
			//rightPos[i] = xPos;
		}
		platform_high_l1.SetActive (false);
		platform_low_l1.SetActive (false);
	}
	// Update is called once per frame
	void FixedUpdate () {
		for (int i=0; i<11; i++){
			if (i%2==0){
				move_vertical (i);
			}
			else{
				move_horizontal (i);
			}
		}
		moveCloud ();
	}
	void moveCloud(){
		for (int i=0; i<CloudType1.Count; i++) {
			((GameObject)CloudType1[i]).transform.Translate(new Vector2(Time.deltaTime,0f));
			GameObject o = ((GameObject)CloudType1[i]);
			if(o.transform.localPosition.x>150f){ //is the left part 50?
				CloudType1.Remove(o);
				Destroy(o);
				float xPos = smallCloudType1.transform.localPosition.x+(float)i*12f+Random.Range(-2.5f, 2.5f);
				float yPos = smallCloudType1.transform.localPosition.y+Random.Range(-2.5f, 2.5f);
				CloudType1.Add(Instantiate(smallCloudType1, new Vector2(xPos,yPos), new Quaternion ()));
			}
		}
		for (int i=0; i<CloudType2.Count; i++) {
			((GameObject)CloudType2[i]).transform.Translate(new Vector2(Time.deltaTime,0f));
			GameObject o = ((GameObject)CloudType2[i]);
			if(o.transform.localPosition.x>150f){
				CloudType2.Remove(o);
				Destroy(o);
				float xPos = smallCloudType2.transform.localPosition.x+(float)i*12f+Random.Range(-2.5f, 2.5f);
				float yPos = smallCloudType2.transform.localPosition.y+Random.Range(-2.5f, 2.5f);
				CloudType2.Add(Instantiate(smallCloudType2, new Vector2(xPos,yPos), new Quaternion ()));
			}
		}
	}
	void generateCloud(Vector2 pos,GameObject myobject,bool type){
		if (type) {
			CloudType1.Add (Instantiate(myobject, pos, new Quaternion ()));
		} else {
			CloudType2.Add(Instantiate(myobject,pos,new Quaternion()));	
		}
	}
	void generatePlatform(Vector2 pos,GameObject myobject){
		Instantiate (myobject, pos, new Quaternion (0f,0f,0f,0f));
	}
	void generatePlatform2(Vector2 pos,GameObject myobject){
		LowerPart.Add((GameObject)Instantiate (myobject, pos, new Quaternion (0f,0f,0f,0f)));// false mean go up.
		down.Add (false);
		right.Add (false);
	}

	public void move_vertical(int index){
		if ((bool)down [index]==false) {
			((GameObject)LowerPart [index]).transform.Translate (new Vector2 (0f, Time.deltaTime));
			if (((GameObject)LowerPart [index]).transform.localPosition.y > 10f)
				down [index] = true;
			} else {
			((GameObject)LowerPart [index]).transform.Translate (new Vector2 (0f, 0f-Time.deltaTime));
			if (((GameObject)LowerPart [index]).transform.localPosition.y <-5f)
				down [index] = false;
		}
	}
	public void move_horizontal(int index){
		if ((bool)right [index]==false) {
			((GameObject)LowerPart [index]).transform.Translate (new Vector2 (Time.deltaTime, 0f)); // move right
			if (((GameObject)LowerPart [index]).transform.localPosition.x > rightPos[index+1]-10f)
				right [index] = true;
		} else {
			((GameObject)LowerPart [index]).transform.Translate (new Vector2 (0f-Time.deltaTime, 0f)); // move left
			if (((GameObject)LowerPart [index]).transform.localPosition.x < rightPos[index-1]+10f)
				right [index] = false;
		}
	}


}
