using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public void LockIn()
    {
        GameManager.Instance.LockPassTrajectory();
    }

    public void KickBall()
    {
        GameManager.Instance.KickBall();
    }
}
