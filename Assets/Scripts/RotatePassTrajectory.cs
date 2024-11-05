using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePassTrajectory : MonoBehaviour
{
    public GameObject passTrajectoryMarker;

    // Update is called once per frame
    void Update()
    {
        passTrajectoryMarker.transform.Rotate(0, 180 * Time.deltaTime, 0);
    }
}
