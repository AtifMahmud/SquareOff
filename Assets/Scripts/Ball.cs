using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float kickForce = 100f;
    public float deceleration = 0.95f;
    private Vector2 velocity;

    public void Kick(Vector2 direction)
    {
        StopAllCoroutines();
        StartCoroutine(Move(direction));
    }

    private IEnumerator Move(Vector2 direction)
    {
        velocity = direction.normalized * kickForce;
        while (velocity.magnitude > 0.1f)
        {
            transform.position += (Vector3)velocity * Time.deltaTime;
            velocity *= deceleration;
            yield return null;
        }
        velocity = Vector2.zero;
    }
}
