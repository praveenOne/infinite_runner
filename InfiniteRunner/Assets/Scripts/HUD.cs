using UnityEngine;
using UnityEngine.UI;

namespace praveen.one
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] Text m_Score;
        [SerializeField] GameObject m_TitleText;
        [SerializeField] GameObject m_IntroText;


        private void Start()
        {
            GameManager.GameOver += GameOver;

            m_TitleText.SetActive(false);
            m_IntroText.SetActive(false);
            m_Score.gameObject.SetActive(true);

            m_Score.text = "0";

        }

        private void OnDisable()
        {
            GameManager.GameOver -= GameOver;
        }

        public void GameOver()
        {
            m_TitleText.SetActive(true);
            m_IntroText.SetActive(true);
            m_Score.gameObject.SetActive(true);
        }


        private void Update()
        {
            int score = (int)Ball.DistanceTraveled;
            m_Score.text = score.ToString();
        }
    }
}
