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
        Vector3 forwardVector = Vector3.forward;

        if (direction.x < 0.0f)
        {
            upVector = -upVector;
            forwardVector = -forwardVector;
        }

        transform.rotation = Quaternion.LookRotation(forwardVector, upVector);

        Vector3 eulerAngles = transform.localRotation.eulerAngles;

        if (eulerAngles.z > 180.0f) eulerAngles.z = eulerAngles.z - 360.0f;

        eulerAngles.z = Mathf.Clamp(eulerAngles.z, -45.0f, 45.0f);

        transform.localRotation = Quaternion.Euler(eulerAngles);
    }
}
