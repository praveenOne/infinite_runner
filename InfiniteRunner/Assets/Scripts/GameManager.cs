using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static float NextPos;

	public delegate void GameEvent();
	public static event GameEvent GameStart, GameOver;

	private bool m_IsStarted;

    private void Start()
    {
		m_IsStarted = false;
    }

    public static void TriggerGameStart()
	{
		if (GameStart != null)
		{
			GameStart();
		}
	}

	public static void TriggerGameOver()
	{
		if (GameOver != null)
		{
			GameOver();
		}
	}

	public static float GetNextPos()
    {
        NextPos += Random.Range(8, 20);
        return NextPos;
    }

	private void Update()
	{
		if (m_IsStarted)
			return;


		if (Input.GetKeyDown(KeyCode.Space))
		{
			m_IsStarted = true;
			TriggerGameStart();
		}
	}
}
