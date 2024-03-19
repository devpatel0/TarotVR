using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjectFloat : MonoBehaviour
{
    public float speed = 0.5f;
    public float wavelength = 1f;
    private float initialYPos;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Initial yPos for cards: " + transform.position.y);
        initialYPos = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        calculateFloat();
    }

    void calculateFloat() {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * speed) * wavelength + initialYPos, transform.position.z);
    }
}
