using UnityEngine;
using System.Collections;

public class Pickable : MonoBehaviour {
    enum Density {
        Water = 998,
        Plastic = 1175,
        Wood = 700
    }

    float density = 1175;
    Rigidbody rigid;
    Collider coll;
    // the transform of the attractor
    public Picker target;

    void Start () {
        target = null;   

        // set up rigidbody and collider
        if (GetComponent<Rigidbody>()) {
            rigid = GetComponent<Rigidbody>();
        } else {
            rigid = gameObject.AddComponent<Rigidbody>();
        }        
        // add a trigger collider
        if (!GetComponent<Collider>().isTrigger) {
            coll = gameObject.AddComponent<BoxCollider>();
            coll.isTrigger = true;
        } else {
            coll = GetComponent<Collider>();
        }
        // set mass by bounds volume
        Vector3 size = GetComponent<Renderer>().bounds.size;
        rigid.mass = Mathf.Round(size.x * size.y * size.z * 100f)/100f;
    }

    void FixedUpdate() {
        if (target) {
            Vector3 diff = (transform.position - target.transform.position);
            rigid.velocity = Vector3.MoveTowards(rigid.velocity, diff * 3000f * Time.fixedDeltaTime, 10f);
        }
    }
        
}
