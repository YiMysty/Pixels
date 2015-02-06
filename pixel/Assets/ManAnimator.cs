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
	int count = 0;
	int update = 0;
	void resetKey(){
		pressed = false;
		keycode = KeyCode.Alpha0;
		count = 0;
		update = 0;
	}
	void pressKey(KeyCode keycode){
		this.keycode = keycode;
		pressed = true;
		update = 0;
		count = 0;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			pressKey (KeyCode.LeftArrow);
		}else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
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
		}else if(Input.GetKeyUp(KeyCode.DownArrow)){
			resetKey();
		}
		if (pressed) {
			Vector3 vector = transform.localPosition;
			update++;
			if(update%5==4) //hard code here
				count++;
			int index = 0;
			switch(keycode){
				case KeyCode.UpArrow:
				index = 6;
				vector.y+=0.1f;
				break;
			case KeyCode.DownArrow:
				index = 0;
				vector.y-=0.1f;
				break;
			case KeyCode.LeftArrow:
				index = 3;
				vector.x-=0.1f;
				break;
			case KeyCode.RightArrow:
				index = 9;
				vector.x+=0.1f;
				break;
			default:
				break;
			}
			spriteRenderer.sprite = sprites[index+count%3];
			transform.position = vector;
		}
	}
}
