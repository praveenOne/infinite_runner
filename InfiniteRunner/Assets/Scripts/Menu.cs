using UnityEngine;
using UnityEngine.SceneManagement;

namespace praveen.one
{
    public class Menu : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene((int)GameScenes.game);
            }
        }
    }
}
