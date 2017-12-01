using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//une manière de mettre tout dans une "pochette" dans Unity
public class Boundary
{
    public float xMin, xMax, zMin, zMax;//les min et max a ne pas dépasser pour ne pas quitter l'écran du jeu
}
public class PlayerController : MonoBehaviour {

    public float speed;//vitesse du vaisseau
    public float tilt;
    public Boundary boundary;
    
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);//les mouvements de la flèche du haut et de celle du bas 
        GetComponent<Rigidbody>().velocity = movement * speed;//faire bouger le vaisseau en fonction de la vitesse donnée

        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            ); //pour ne pas quitter l'écran du jeu

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x *-tilt);
	}
}
