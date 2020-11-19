using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] Text m_Score;
    [SerializeField] GameObject m_TitleText;
    [SerializeField] GameObject m_IntroText;


    private void Start()
    {
        GameManager.GameStart += GameStart;
        GameManager.GameOver += GameOver;

        m_TitleText.SetActive(true);
        m_IntroText.SetActive(true);
        m_Score.gameObject.SetActive(false);

    }

    public void GameStart()
    {
        m_TitleText.SetActive(false);
        m_IntroText.SetActive(false);
        m_Score.gameObject.SetActive(true);

        m_Score.text = "0";

    }

    public void GameOver()
    {
        m_TitleText.SetActive(true);
        m_IntroText.SetActive(true);
        m_Score.gameObject.SetActive(false);
    }


    private void Update()
    {
        int score = (int)Ball.DistanceTraveled;
        m_Score.text = score.ToString();
    }
}
