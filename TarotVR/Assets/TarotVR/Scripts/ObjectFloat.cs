using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjectFloat : MonoBehaviour
{
    public float speed = 0.5f;
    public float wavelength = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calculateFloat();
    }

    void calculateFloat() {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * speed) * wavelength, 0f);
    }
}
