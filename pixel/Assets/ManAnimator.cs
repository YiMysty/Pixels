using UnityEngine;
using System.Collections;
using UnityEngine.Sprites;

public class ManAnimator : MonoBehaviour {
	public Sprite[] sprites;
	public float framePerminutes;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
	}
	private KeyCode keycode;
	bool pressed = false;
	void resetKey(){
		pressed = false;
		keycode = KeyCode.Alpha0;
	}
	void pressKey(KeyCode keycode){
		this.keycode = keycode;
		pressed = true;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			pressKey (KeyCode.LeftArrow);
		} else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			resetKey ();
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			pressKey (KeyCode.RightArrow);
		} else if (Input.GetKeyUp(KeyCode.RightArrow)) {
			resetKey();		
		}else if(Input.GetKeyDown(KeyCode.UpArrow)){
			pressKey(KeyCode.UpArrow);
		}else if(Input.GetKeyUp(KeyCode.UpArrow)){
			resetKey();
		}else if(Input.GetKeyDown(KeyCode.DownArrow)){
			pressKey(KeyCode.DownArrow);
		}else if(Input.get){
			resetKey();
		}
	}
}
