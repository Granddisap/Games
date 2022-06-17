using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Transform followingTarget;
    [SerializeField, Range(0f, 1f)] float parallaxStrength = 0.1f;
    [SerializeField] bool disableVerticalParallax;
    Vector3 targetPreviousPosition;

    [SerializeField] private float Zposition;
    [SerializeField] private float Yposition;//на сколько по Y опустить спрайт
    // Start is called before the first frame update
    void Awake()
    {
        transform.position = new Vector3(followingTarget.position.x, followingTarget.position.y - Yposition, Zposition);
        targetPreviousPosition = followingTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        var delta = followingTarget.position - targetPreviousPosition;

        if (disableVerticalParallax)
            delta.y = 0;

        targetPreviousPosition = followingTarget.position;

        transform.position += delta * parallaxStrength;
    }
}
