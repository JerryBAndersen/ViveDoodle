using UnityEngine;
using System.Collections;

public class Ruler : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetButtonDown("Fire1")) {
            print("Ruler distance: " + Vector3.Distance(transform.position, GameObject.Find("RulerEnd").transform.position));
        }
	}
}
