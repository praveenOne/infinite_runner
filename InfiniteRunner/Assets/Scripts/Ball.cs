using UnityEngine;

namespace praveen.one
{

    public class Ball : MonoBehaviour
    {
        public static float DistanceTraveled;

        private float m_left = -2.4f;
        private float m_Right = 2.4f;
        private bool m_CanJump;
        private Rigidbody m_Rigidbody;
        private Renderer m_Renderer;

        [SerializeField] private float m_Speed;
        [SerializeField] Vector3 m_StartPos;
        [SerializeField] private Vector3 m_JumpVelocity;

        void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_Renderer = GetComponent<Renderer>();

            transform.position = m_StartPos;
            enabled = true;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && m_CanJump)
            {
                m_CanJump = false;
                m_Rigidbody.AddForce(m_JumpVelocity, ForceMode.VelocityChange);
            }

            var move = new Vector3(Input.GetAxis("Horizontal") * 0.2f, 0, 0.5f);
            transform.position += move * m_Speed * Time.deltaTime;
            DistanceTraveled = transform.localPosition.z;

            if (transform.position.x < m_left)
            {
                transform.position = new Vector3(m_left, transform.position.y, transform.position.z);
            }

            if (transform.position.x > m_Right)
            {
                transform.position = new Vector3(m_Right, transform.position.y, transform.position.z);
            }

        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "obstacle")
            {
                GameManager.TriggerGameOver();
                m_Rigidbody.isKinematic = true;
                m_Renderer.enabled = false;
                enabled = false;
            }
            else
            {
                m_CanJump = true;
            }
        }
    }
}
