using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    Camera camera;

    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mpInWorldSpace = camera.ScreenToWorldPoint(mousePosition);
        Vector3 deltaP = mpInWorldSpace - transform.position;
        Vector3 direction = deltaP.normalized;

        Vector3 upVector = Quaternion.Euler(0.0f, 0.0f, 90.0f) * direction;

        float   tmp = transform.parent.right.x * direction.x;

        if (transform.parent.right.x < 0.0f) upVector = -upVector;

        if (tmp < 0.0f)
        {
            upVector = -upVector;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, upVector) * Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, upVector);
        }

        Vector3 eulerAngles = transform.localRotation.eulerAngles;

        if (eulerAngles.z > 180.0f) eulerAngles.z = eulerAngles.z - 360.0f;

        eulerAngles.z = Mathf.Clamp(eulerAngles.z, -45.0f, 45.0f);

        transform.rotation = Quaternion.Euler(eulerAngles);
    }
}
