using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);//l'objet se détruit s'il sort du Boundary, donc s'il sort de la zone de jeu
        }
    }
}
