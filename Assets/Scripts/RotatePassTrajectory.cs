using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePassTrajectory : MonoBehaviour
{
    public GameObject passTrajectoryMarker;
    public PlayerData playerData;

    // Update is called once per frame
    void Update()
    {
        if (playerData.isPossessingBall)
        {
            if (!passTrajectoryMarker.activeInHierarchy)
            {
                passTrajectoryMarker.SetActive(true);
            }
            passTrajectoryMarker.transform.Rotate(0, 180 * Time.deltaTime, 0);
        }
    }
}
