using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float explosionRadius = 250.0f;
    public float explosionStrength = 5000.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Collider2D[] chickens = Physics2D.OverlapCircleAll(transform.position, explosionRadius, LayerMask.GetMask("Chicken"));

            foreach (var chicken in chickens)
            {
                Rigidbody2D rigidBody = chicken.GetComponent<Rigidbody2D>();
                if (rigidBody != null)
                {
                    rigidBody.AddForce(explosionStrength * (chicken.transform.position - transform.position).normalized);
                }
            }

            Destroy(player.gameObject);

            Destroy(gameObject);
        }
    }
}
