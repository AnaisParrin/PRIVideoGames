using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opacity_Change : MonoBehaviour {

    private GameController GC;
    private int i; // existe parce que sinon le programme fait un fondu que sur une partie du background
	// Use this for initialization
	void Start () {
        
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            GC = gameControllerObject.GetComponent<GameController>();
        }
        if (GC == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        i = 0;
	}
	// Update is called once per frame
    void Update()
    {
		if(GC.getWave_end())//si on a fini la vague d'ennemis
        {
            StartCoroutine(FadeTo(0.0f, 15.0f));
            //afin de prends en compte les 2 parties du background qui bouge
            if(i<1)
            {
                i++;
            }
            else
            {
                GC.setWave_end(false);//on a fini le fondu
                i = 0;
            }
            
        }
        if(GC.getFondu())//lorsqu'on a recup la boule violette !
        {
            StartCoroutine(FadeTo(1.0f, 15.0f));
            if (i < 1)
            {
                i++;
            }
            else
            {
                GC.setFondu(false);//on a fini de remettre l'écran a la normale
                i = 0;
            }
            
        }
    }
    IEnumerator FadeTo(float aValue, float aTime)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(this.GetComponent<MeshRenderer>().material.color.a, aValue, t));
            this.GetComponent<MeshRenderer>().material.color = newColor;
            yield return null;
        }
    }
}
