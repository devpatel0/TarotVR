using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollTexture : MonoBehaviour
{
    public float scrollSpeedX;
    public float scrollSpeedY;
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset = new Vector2(scrollSpeedX * Time.realtimeSinceStartup, 
                                                              scrollSpeedY * Time.realtimeSinceStartup);
    }
}
