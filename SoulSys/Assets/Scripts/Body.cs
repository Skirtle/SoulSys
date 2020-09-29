using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public string identifier;
    public float mass;
    public Vector3 rotation;
    public bool isStatic;
    public Vector3 startingVelocity;
    [HideInInspector]
    public Vector3 currentVelocity, startingPosition;


    // Start is called before the first frame update
    void Start() {
        currentVelocity = startingVelocity;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(rotation);
    }
}
