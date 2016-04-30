using UnityEngine;
using System.Collections;

public class Picker : MonoBehaviour {

    Collider coll;
    Pickable pickable;

    void Start () {
        // set up collider etc
        if (!GetComponent<Collider>().isTrigger) {
            coll = gameObject.AddComponent<BoxCollider>();
            coll.isTrigger = true;
            ((BoxCollider)coll).size = GetComponent<Renderer>().bounds.size * 2f;
        } else {
            coll = GetComponent<Collider>();
        }
	}
	
	void FixedUpdate () {
        // if there is a pickable selected
        if (pickable) {
            // if its distance is too great or a button was pressed
            if (Vector3.Distance(transform.position, pickable.transform.position) > .2f || Input.GetButtonDown("Fire2")) {
                // set its target null
                pickable.target = null;
            }
        }
	}

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Pickable>() && !pickable) {            
            pickable = other.GetComponent<Pickable>();
            pickable.target = GetComponent<Picker>();

            //Rigidbody otherrigid = other.GetComponent<Rigidbody>();

            //Vector3 diff = (transform.position - other.transform.position);
            //float dist = Vector3.Distance(transform.position, other.transform.position);

            //// *.'* magic-based *.'*
            //otherrigid.velocity = Vector3.MoveTowards(otherrigid.velocity, diff *3000f *Time.fixedDeltaTime, 10f);
            //otherrigid.AddTorque(Vector3.Cross(otherrigid.transform.up,transform.up));
            //otherrigid.AddTorque(Vector3.Cross(otherrigid.transform.right, transform.right));

            // force-based
            //Vector3 force = diff;
            //otherrigid.AddForce(force);

            // move-based
            //otherrigid.useGravity = false;
            //otherrigid.MovePosition(transform.position);
            //otherrigid.MoveRotation(transform.rotation);


        }
    }
}
