using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float deceleration = 0.9f;
    public GameManager.GridSquare position;    
    
    private Vector2 velocity;
    private float kickForce = 60f;
    private int ownerInstanceId;

    public void Kick(Vector2 direction)
    {
        Debug.Log("Starting from: " + GetCurrentSquare());
        StopAllCoroutines();
        StartCoroutine(Move(direction));
    }

    private IEnumerator Move(Vector2 direction)
    {
        velocity = direction * kickForce;
        Debug.Log("Velocity is: " + velocity);
        Debug.Log("Direction is: " + direction);
        while (velocity.magnitude > 0.2f)
        {
            transform.position += new Vector3(velocity.x, 0, velocity.y) * Time.deltaTime;
            velocity *= deceleration;
            yield return new WaitForSeconds(0.02f);
        }
        velocity = Vector2.zero;
        Debug.Log("Ended up in: " + GetCurrentSquare());
    }

    private string GetCurrentSquare()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            if (hit.transform.CompareTag("Square"))
            {
                return hit.transform.gameObject.name;
            }
        }
        return "none";
    }
}
