using UnityEngine;

namespace UnitySampleAssets._2D
{
    public class Restarter : MonoBehaviour
    {
		public delegate void GameEvent();
		public static GameEvent saveCamera;
		private void Start(){

		}
		private void OnCollisionEnter2D(Collision2D door)
        {
				Application.LoadLevel(1);
		}
    }
}