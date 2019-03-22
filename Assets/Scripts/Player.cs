using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalStrenght = 5000.0f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");

        Vector2 force = new Vector2();
        force.x = hAxis * horizontalStrenght;
        force.y = 0.0f;

        rb.AddForce(force);
    }
}
