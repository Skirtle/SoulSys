using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTime : MonoBehaviour {
    
    public float coefficient;
    public float G;
    public bool useRealGValue;

    private GameObject[] allBodies;



    // Start is called before the first frame update
    void Start() {
        allBodies = GameObject.FindGameObjectsWithTag("Body");
        foreach (GameObject body in allBodies) {
            print(body.GetComponent<Body>().identifier);
        }
        if (useRealGValue) {
            G = 0.000000000067f;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {

        float t = Time.deltaTime;
        Vector3 force = new Vector3(0, 0, 0);

        foreach (GameObject currentBody in allBodies) {
            if (currentBody.GetComponent<Body>().isStatic) {
                currentBody.transform.position = currentBody.GetComponent<Body>().startingPosition;
                //continue;
            }
            float m1 = currentBody.GetComponent<Body>().mass;

            foreach (GameObject toCompareBody in allBodies) {
                float m2 = toCompareBody.GetComponent<Body>().mass;
                if (currentBody == toCompareBody) continue;
                
                float magnitudeGravity = (G * m1 * m2);
                float rSqr = Mathf.Pow(Vector3.Distance(currentBody.transform.position, toCompareBody.transform.position), 2.0f);
                print(rSqr);

                magnitudeGravity = magnitudeGravity / rSqr;
                float accelMag = magnitudeGravity / toCompareBody.GetComponent<Body>().mass;

                force += (toCompareBody.transform.position - currentBody.transform.position) * accelMag;
            }
            //print(force);
            currentBody.GetComponent<Body>().currentVelocity += force;
            currentBody.transform.Translate(currentBody.GetComponent<Body>().currentVelocity + force * t * coefficient);
        }


    }
}
