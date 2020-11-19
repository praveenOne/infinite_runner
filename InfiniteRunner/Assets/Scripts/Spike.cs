using UnityEngine;

public class Spike : Obstacle
{
    private int m_Offest;
    float m_LeftX = -2.4f;
    float m_RightX = 2.4f;
    float m_StartY = -3f;

    public override void InIt(Vector3 pos)
    {
        m_Offest = 10;
        transform.position = new Vector3(Random.Range(m_LeftX, m_RightX), m_StartY,
            pos.z);
    }

    void Update()
    {
        if (Ball.DistanceTraveled + m_Offest > transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, -2.6f, transform.position.z);
        }
    }
}
