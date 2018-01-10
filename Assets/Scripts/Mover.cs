using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    public float a, b;

	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(2.5f, 12f) - b, 0, (Random.Range(4f, -4f) - a)) * speed;
        //GetComponent<Rigidbody>().velocity = transform.forward * speed;//se barrer en ligne droite en fonction du speed
        //si speed est + alors vers le haut, si - alors vers le bas
	}
}
