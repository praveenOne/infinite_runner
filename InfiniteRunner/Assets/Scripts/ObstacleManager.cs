using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private Transform[] m_Prefab;
    [SerializeField] private int m_NumberOfObjects;
    [SerializeField] private float m_RecycleOffset;
    [SerializeField] private Vector3 m_StartPosition;

    private Vector3 m_NextPosition;
    private Queue<Transform> m_ObjectQueue;

    void Start()
    {
        m_ObjectQueue = new Queue<Transform>(m_NumberOfObjects);
        m_NextPosition = m_StartPosition;
        for (int i = 0; i < m_NumberOfObjects; i++)
        {
            Transform obstacle = Instantiate(m_Prefab[Random.Range(0,2)]);
            obstacle.transform.parent = transform;
            obstacle.GetComponent<Obstacle>().InIt(m_NextPosition);
            m_NextPosition.z = GameManager.GetNextPos();
            m_ObjectQueue.Enqueue(obstacle);
        }
    }

    
    void Update()
    {
        if (m_ObjectQueue.Peek().localPosition.z + m_RecycleOffset < Ball.DistanceTraveled)
        {
            Transform obstacle = m_ObjectQueue.Dequeue();
            obstacle.GetComponent<Obstacle>().InIt(m_NextPosition);
            m_NextPosition.z = GameManager.GetNextPos();
            obstacle.GetComponent<Obstacle>().Reset();
            m_ObjectQueue.Enqueue(obstacle);
        }
    }
}
