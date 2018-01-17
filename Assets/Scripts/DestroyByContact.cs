using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController;

    public AudioClip playerOKSound;

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
            // METTRE CA POUR QUE CA SE SUPPRIME QUAND SORT DU TERRAIN ! 
            gameController.destroyOneShot();
            return;
        }

        if (explosion != null && !(this.CompareTag("Enemy") && other.CompareTag("ChangeMap")))
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if(other.CompareTag("Player") && !this.CompareTag("ChangeMap"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.GameOver();
        }
        if (other.CompareTag("Player") && this.CompareTag("ChangeMap") && explosion==null)
        {
            AudioSource.PlayClipAtPoint(playerOKSound, transform.position);
            Destroy(gameObject);
            gameController.WaveEnd();
        }

        
    }
}
