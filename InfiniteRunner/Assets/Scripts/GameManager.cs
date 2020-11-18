using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static float NextPos;


    public static float GetNextPos()
    {
        NextPos += Random.Range(8, 20);
        return NextPos;
    }
}
