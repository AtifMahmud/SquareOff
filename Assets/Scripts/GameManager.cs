using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool isPlayerSelected = false;

    [HideInInspector]
    public GameObject currentSelected;

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
        Debug.Log("isPlayerSelected " + isPlayerSelected);
        if (currentSelected != null)
        {
            Debug.Log("Current selected player is: " + currentSelected.name);
        }
        else
        {
            Debug.Log("Current selected player is NULL");
        }
    }

    public void LockPassTrajectory()
    {
        passTrajectorySet = true;
    }

    public void KickBall()
    {
        Debug.Log("Direction " + kickDirection);
        ball.Kick(kickDirection);
    }
}
