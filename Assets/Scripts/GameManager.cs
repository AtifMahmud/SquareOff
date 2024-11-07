using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool isPlayerSelected = false;

    [HideInInspector]
    public GameObject currentSelected;

    public enum GridSquare
    {
        A8, B8, C8, D8, E8, F8,
        A7, B7, C7, D7, E7, F7,
        A6, B6, C6, D6, E6, F6,
        A5, B5, C5, D5, E5, F5,
        A4, B4, C4, D4, E4, F4,
        A3, B3, C3, D3, E3, F3,
        A2, B2, C2, D2, E2, F2,
        A1, B1, C1, D1, E1, F1
    };
    public bool passTrajectorySet = false;

    public Ball ball;
    public Vector2 kickDirection;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("GameManager");
                _instance = obj.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void Update()
    {
        if (currentSelected != null)
        {

        }
        else
        {

        }
    }

    public void LockPassTrajectory()
    {
        passTrajectorySet = true;
    }

    public void KickBall()
    {
        ball.Kick(kickDirection);
    }
}
