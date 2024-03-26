using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float oscillationRange = 1f;
    public float oscillationSpeed = 2f;
    public bool flipYRotation = false; // Variable to control flipping y-axis rotation
    public float flipInterval = 5f; // Interval in seconds for flipping

    private Vector3 initialLocalPosition;
    private Quaternion initialRotation; // Store the initial rotation
    private float flipTimer = 0f; // Timer for controlling flipping

    void Start()
    {
        // Save the initial local position of the object relative to its parent
        initialLocalPosition = transform.localPosition;
        // Save the initial rotation
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        // Calculate the oscillation along the X-axis using sine function
        float oscillationOffset = Mathf.Sin(Time.time * oscillationSpeed) * oscillationRange;

        // Calculate the new local position relative to the parent
        Vector3 newLocalPosition = initialLocalPosition + new Vector3(oscillationOffset, 0f, 0f);

        // Set the new position of the object relative to its parent
        transform.localPosition = newLocalPosition;

        // Update flip timer
        flipTimer += Time.deltaTime;

        // If flip timer exceeds flip interval, flip y-axis rotation
        if (flipTimer >= flipInterval)
        {
            // Toggle flipYRotation
            flipYRotation = !flipYRotation;
            // Reset flip timer
            flipTimer = 0f;
        }

        // If flipYRotation is true, flip the y-axis rotation
        if (flipYRotation)
        {
            // Calculate the rotation offset along the Y-axis using sine function
            float rotationOffset = 180f;

            // Apply the rotation offset to the initial rotation
            Quaternion newRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y + rotationOffset, initialRotation.eulerAngles.z);

            // Set the new rotation of the object
            transform.localRotation = newRotation;
        }
        else
        {
            // If flipYRotation is false, reset the rotation to initialRotation
            transform.localRotation = initialRotation;
        }
    }
}
