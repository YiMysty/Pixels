public static class GameManager{
	public delegate void GameEvent();
	public static event GameEvent GameStart,GameOVer;
	public static void TriggerGameStart(){
		if (GameStart != null) {
			GameStart();
		}
	}

	public static void TriggerGameOver(){
		if (GameOVer != null) {
			GameOVer ();
		}
	}
}
