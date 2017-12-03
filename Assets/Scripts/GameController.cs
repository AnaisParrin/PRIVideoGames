using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
/*
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public double spawnWait;//temps d'attente entre chaque vague d'ennemis
    public double startWait;//temps d'attente avant nouvelle vague
    public double waveWait;//temps d'attente avant de démarrer la nouvelle vague

    public GUIText scoreText; // display du score
    public GUIText restartText; //display du restart
    public GUIText gameOverText; // display du Game Over
    public int score;

    private bool gameOver;
    private bool restart;
    
    void Start()
    {
        score = 0;//on initialise le score
        restart = false;
        restartText.text = "";
        gameOver = false;
        gameOverText.text = "";

        UpdateScore(); //on update le GUI text en fonction du score, on le met a 0 ici
        StartCoroutine(SpawnWaves());// on lance une coroutine => on va lancer une vague d'ennemie
        //puis comme c'est dans une boucle on va lancer plusieurs vagues
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    IEnumerator SpawnWaves()
    {
          
        yield return new WaitForSeconds((float)startWait);//on attend avant de démarrer
        while(true)
        {
            for(int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);//on fait apparaitre notre astéroid
                yield return new WaitForSeconds((float)spawnWait);//on attend un peu entre chaque astéroid
            }
            yield return new WaitForSeconds((float)waveWait);//on attend un peu entre chaque vague d'ennemis


            if(gameOver)
            {
                restart = true;//on met le flag a true pour indiquer qu'on peut faire un restart
                restartText.text = "Press 'R' for Restart";
                break;//ca va briser la coroutine
            }
        }
    }
    public void AddScore(int newScoreValue) //on ajoute la valeur rentrée pour mettre a jour le score
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()//mettre a jour le score dans le GUIText
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;//on met le flag a true
    }*/
}
