using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate(new Vector2(0f,Time.deltaTime));
	}
}
