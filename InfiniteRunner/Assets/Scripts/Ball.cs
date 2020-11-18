using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static float DistanceTraveled;

    private float m_left = -2.4f;
    private float m_Right = 2.4f;

    void Start()
    {
        
    }

    
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal") * 0.2f, 0, 0.5f);
        transform.position += move * 75 * Time.deltaTime;
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
}
