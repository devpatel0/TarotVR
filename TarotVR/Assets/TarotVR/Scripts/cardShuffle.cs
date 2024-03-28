using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
public class CardShuffle : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation
    public Vector3 rotationPoint = new Vector3(0, 0, 0); // The point around which cards will rotate
    public float rotationRadius = 5f; 
    private float angle; 

    // Update is called once per frame
    void Update()
    {
        RotateCardsInCircle();
    }

    void RotateCardsInCircle()
    {
        // Calculate the new angle based on the rotation speed and time
        angle += rotationSpeed * Time.deltaTime;

        // Ensure the angle wraps around 360 degrees
        angle %= 360;

        // Calculate the new position using the circle formula
        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * rotationRadius + rotationPoint.x;
        float z = Mathf.Sin(angle * Mathf.Deg2Rad) * rotationRadius + rotationPoint.z;

        // Update the position of the card
        transform.position = new Vector3(x, transform.position.y, z);

        // Optionally, make the card face the direction of movement, comment this out if not needed
        Vector3 directionOfTravel = (new Vector3(x, transform.position.y, z) - transform.position).normalized;
        if (directionOfTravel != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(directionOfTravel, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        
    }
}