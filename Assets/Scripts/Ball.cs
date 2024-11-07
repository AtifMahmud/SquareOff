using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float kickForce = 60f;
    public float deceleration = 0.9f;
    public GameManager.GridSquare position;    
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
            velocity *= deceleration;
            yield return new WaitForSeconds(0.02f);
        }
        velocity = Vector2.zero;
    }
}
