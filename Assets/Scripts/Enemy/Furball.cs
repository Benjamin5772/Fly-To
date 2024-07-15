using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furball : ReboundEnemy
{
    public int bouncesRemaining = 3;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        // 玩家弹反ref设置

    //    }

    //    //if (collision.gameObject.CompareTag("Player"))
    //    //{

    //    //    // Íæ¼ÒÊÜÉË take damage
    //    //    Destroy(gameObject);
    //    //}
    //    //else if (bouncesRemaining > 0)
    //    //{
    //    //    //·´µ¯Âß¼­
    //    //    bouncesRemaining--;
    //    //    Vector3 reflectDir = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
    //    //    rb.velocity = reflectDir * speed;
    //    //}
    //    //else
    //    //{
    //    //    Destroy(gameObject);
    //    //}
    //}

    public override void Rebound()
    {
        base.Rebound();

        //弹反，攻击boss
        //TODO
    }
}
