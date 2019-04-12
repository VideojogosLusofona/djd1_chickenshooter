using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public float        timeToLive = 5.0f;
    public float        explosionRadius = 100.0f;
    public float        explosionStrength = 1000.0f;
    public GameObject   explosionPrefab;

    float       timeToLiveTimer;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //        Invoke("KillChicken", timeToLive);

        timeToLiveTimer = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeToLiveTimer = timeToLiveTimer + Time.deltaTime;
        if (timeToLiveTimer > timeToLive)
        {
            KillChicken();
        }

        transform.rotation = Quaternion.LookRotation(transform.forward, Quaternion.Euler(0, 0, 90) * rb.velocity.normalized);
    }

    void KillChicken()
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

        Instantiate(explosionPrefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
