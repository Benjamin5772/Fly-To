using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furball : MonoBehaviour
{
    public float speed = 10.0f;
    public int bouncesRemaining = 3;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            // Íæ¼ÒÊÜÉË take damage
            Destroy(gameObject);
        }
        else if (bouncesRemaining > 0)
        {
            //·´µ¯Âß¼­
            bouncesRemaining--;
            Vector3 reflectDir = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            rb.velocity = reflectDir * speed;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
