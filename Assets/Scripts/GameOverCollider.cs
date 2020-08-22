using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCollider : MonoBehaviour
{
    [SerializeField] SceneLoader scene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detector for when ball leaves the game space
        // Trigger to end the level
        // (Future additions may include subtract ball count by 1 instead)

        scene.GameOver();

        /* Experimentation code to deal with the colliding object itself
           obtains the colliding object's velocity from the Rigidbody2D component
           reverses the velocity -- object returns to where it came from */

        // Rigidbody2D rd = collision.GetComponent<Rigidbody2D>();
        // rd.velocity = new Vector2(rd.velocity.x * -1, rd.velocity.y * -1);
    }
}
