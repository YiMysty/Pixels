using UnityEngine;

namespace UnitySampleAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        //private void OnTriggerEnter2D(Collider2D other)
		private void OnCollisionEnter2D(Collision2D door)
        {
            //if (other.tag == "Player")
                //Application.LoadLevel(Application.loadedLevelName);
				Application.LoadLevel(1);
		}
    }
}