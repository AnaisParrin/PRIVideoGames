using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;//se barrer en ligne droite en fonction du speed
        //si speed est + alors vers le haut, si - alors vers le bas
	}
}
