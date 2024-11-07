using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float kickForce = 10f;
    public float deceleration = 0.9f;
    private Vector2 velocity;

    public void Kick(Vector2 direction)
    {
        StopAllCoroutines();
        StartCoroutine(Move(direction));
    }

    private IEnumerator Move(Vector2 direction)
    {
        velocity = direction * kickForce;
        Debug.Log("Velocity is: " + velocity);
        Debug.Log("Direction is: " + direction);
        while (velocity.magnitude > 0.00001f)
        {
            transform.position += new Vector3(velocity.x, 0, velocity.y) * Time.deltaTime;
            Debug.Log("Adding position: " + new Vector3(direction.x, 0, direction.y) * Time.deltaTime);
            velocity *= deceleration;
            yield return null;
        }
        velocity = Vector2.zero;
    }
}
