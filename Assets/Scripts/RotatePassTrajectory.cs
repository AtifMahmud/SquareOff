using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePassTrajectory : MonoBehaviour
{
    public GameObject passTrajectoryMarker;
    public bool isPossessing;

    // Update is called once per frame
    void Update()
    {
        if (isPossessing)
        {
            if (!passTrajectoryMarker.activeInHierarchy)
            {
                passTrajectoryMarker.SetActive(true);
            }

            if (!GameManager.Instance.passTrajectorySet)
            {
                passTrajectoryMarker.transform.Rotate(0, 180 * Time.deltaTime, 0);
                GameManager.Instance.kickDirection = new Vector2(passTrajectoryMarker.transform.forward.x, passTrajectoryMarker.transform.forward.z);
            }
        }
    }
}
