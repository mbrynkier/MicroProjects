using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int scoreToGive = 1;
    public int clicksToPop = 5;
    public float scaleIncreasePerClick = 0.1f;
    public float forceMagnitude = 1000f;
    private bool hasCollided = false;
    public ScoreManager scoreManager;
    private Rigidbody rb;
    public Vector3 velocity;

    private void Start() {
        rb = GetComponent<Rigidbody>();

        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);

        Vector3 randomDirection = new Vector3(randomX, 0f, randomZ);

        rb.AddForce(randomDirection * forceMagnitude,ForceMode.Impulse);
        
    }
    void OnMouseDown() 
    {
        clicksToPop -= 1;

        transform.localScale += Vector3.one * scaleIncreasePerClick;

        if (clicksToPop == 0)
        {
            scoreManager.IncreaseScore(scoreToGive);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 reflection = Vector3.Reflect(rb.velocity,collision.contacts[0].normal);
            rb.velocity = reflection.normalized * forceMagnitude;
            
        }else if (collision.gameObject.CompareTag("Ball"))
        {            
            Rigidbody rb2 = collision.gameObject.GetComponent<Rigidbody>();

            // Calculate reflection directions for both balls
            Vector3 direction = (rb2.position - rb.position).normalized;
            Vector3 reflection1 = Vector3.Reflect(rb.velocity, direction);            

            // Apply the reflection directions with the bounce force
            rb.velocity = reflection1.normalized * forceMagnitude;                        
        }
    }
  
}
