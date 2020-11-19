using UnityEngine;

namespace praveen.one
{
    public enum CubeObstacleType
    {
        left,
        right,
    }

    public class CubeObstacle : Obstacle
    {
        private CubeObstacleType m_Type;
        private int m_Offest;
        float m_LeftX = -2.7f;
        float m_RightX = 2.7f;

        public override void InIt(Vector3 pos)
        {
            m_Type = (CubeObstacleType)Random.Range(0, 2);
            m_Offest = 15;
            switch (m_Type)
            {
                case CubeObstacleType.left:
                    transform.position = new Vector3(m_LeftX, pos.y, pos.z);
                    break;
                case CubeObstacleType.right:
                    transform.position = new Vector3(m_RightX, pos.y, pos.z);
                    break;
            }

        }

        void Update()
        {
            if (Ball.DistanceTraveled + m_Offest > transform.position.z)
            {

                switch (m_Type)
                {
                    case CubeObstacleType.left:
                        transform.rotation = Quaternion.Euler(0, 0, -90);
                        break;
                    case CubeObstacleType.right:
                        transform.rotation = Quaternion.Euler(0, 0, 90);
                        break;
                }
            }
        }

        public override void Reset()
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
