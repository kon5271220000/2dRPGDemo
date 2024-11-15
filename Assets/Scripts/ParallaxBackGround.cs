using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackGround : MonoBehaviour
{
    private GameObject cam;

    [SerializeField] private float parallaxEffect;

    private float xPosition;

    private void Start()
    {
        cam = GameObject.Find("Main Camera");

        xPosition = cam.transform.position.x;
    }

    private void Update()
    {
        float distanceToMove = cam.transform.position.x * parallaxEffect;
        transform.position =  new Vector2(xPosition + distanceToMove, transform.position.y);

    }
}
