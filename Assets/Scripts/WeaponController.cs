using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    private AudioSource audioSource;
    public GameObject shot;
    public Transform shotPosition;
    public float fireRate;
    public float delay;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire",delay,fireRate);
	}
    void Fire()
    {
        Instantiate(shot, shotPosition.position, shotPosition.rotation);
        audioSource.Play();
    }
}
