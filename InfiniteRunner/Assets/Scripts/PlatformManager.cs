using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private Transform m_Prefab;
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
            Transform platform = (Transform)Instantiate(m_Prefab);
            platform.transform.parent = transform;
            platform.localPosition = m_NextPosition;
            m_NextPosition.z += platform.localScale.z;
            m_ObjectQueue.Enqueue(platform);
        }
    }

    void Update()
    {
        if (m_ObjectQueue.Peek().localPosition.z + m_RecycleOffset < Ball.DistanceTraveled)
        {
            Transform platform = m_ObjectQueue.Dequeue();
            platform.localPosition = m_NextPosition;
            m_NextPosition.z += platform.localScale.z;
            m_ObjectQueue.Enqueue(platform);
        }
    }
}
