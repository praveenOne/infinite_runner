using UnityEngine;
using UnityEngine.SceneManagement;

namespace praveen.one
{
	public enum GameScenes
	{
		menu = 0,
		game = 1,
	}

	public class GameManager : MonoBehaviour
	{
		[HideInInspector] public static float NextPos;

		public delegate void GameEvent();
		public static event GameEvent GameOver;

		[HideInInspector] public static bool m_IsGameOver;

		private void Start()
		{
			m_IsGameOver = false;
		}

		public static void TriggerGameOver()
		{
			if (GameOver != null)
			{
				GameOver();
				m_IsGameOver = true;
				NextPos = 0;
			}
		}

		public static float GetNextPos()
		{
			NextPos += Random.Range(8, 20);
			return NextPos;
		}

		private void Update()
		{
			if (!m_IsGameOver)
				return;


			if (Input.GetKeyDown(KeyCode.Space))
			{
				m_IsGameOver = false;
				SceneManager.LoadScene((int)GameScenes.menu);
			}
		}
	}
}
