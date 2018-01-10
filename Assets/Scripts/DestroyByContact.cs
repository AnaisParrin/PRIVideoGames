﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue; // on définit coté Unity combien vaut la destruction d'un ennemi

    private GameController gameController;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        if(explosion!=null)
        {
            Instantiate(explosion, transform.position, transform.rotation);

        }

        if(other.CompareTag("Player") && !this.CompareTag("ChangeMap"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            //gameController.GameOver();
        }
        if (other.CompareTag("Player") && this.CompareTag("ChangeMap") && explosion==null)
        {
            Destroy(gameObject);
        }
        //gameController.AddScore(scoreValue);
        
    }
}
