using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

    // y = -7
    // Zone de terrain : x = [4, -4], y = -7, z = [2, 12.2]

    public GameObject shot;
    private List<GameObject> shots; //tableau de shots pour voir si tous les shots ont bien disparu avant de mettre la boule violette pour changer de map
    public GameObject changeMap;

    public double startWait;
    public double btwShotsWait;

    public GUIText restartText; //display du restart
    public GUIText gameOverText; // display du Game Over
    public Material background;

    private bool gameOver;
    private bool restart;
    private bool wave_end; // savoir si on a fini une wave d'ennemis pour faire un fondu noir
    private bool fondu; //savoir si on fait un fondu noir/blanc ou blanc/noir

    public int nb_enemy;
    private int i;
    private int ennemyOnPlay;
    private int test;

    void Start()
    {
        restart = false;
        restartText.text = "";
        gameOver = false;
        gameOverText.text = "";
        wave_end = false;
        fondu = false;

        test=0;

        i = 0;
        shots = new List<GameObject>();
        ennemyOnPlay = 0;

        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {

        GameObject shotty;

        yield return new WaitForSeconds((float)startWait);
        while (!gameOver && i!=nb_enemy)
        {
            Vector3 shotPosition = new Vector3(Random.Range(4f, -4f), -7, Random.Range(2f, 12.2f));

            shotty = Instantiate(shot, shotPosition, Quaternion.identity);//on fait apparaitre notre astéroid
            shots.Add(shotty);
            ennemyOnPlay++;
            i++;

            yield return new WaitForSeconds((float)btwShotsWait);

        }
        
        if (gameOver)
        {
            restart = true;//on met le flag a true pour indiquer qu'on peut faire un restart
            restartText.text = "Press 'R' for Restart";
        }
        else
        {
            wave_end = true;//on va faire un fondu car on a fini une vague d'ennemis
            Instantiate(changeMap,new Vector3(Random.Range(3f, -3f), -7, Random.Range(4f, 10f)),Quaternion.identity);
            gameOverText.text = "Placer vous sur la lumiere :)";
        }
    }

    void FixedUpdate()
    {
        print(shots.Count);
        for (int ii = 0; ii < shots.Count; ii++)
        {
            if (shots[ii] != null)
            {
                shots[ii].transform.position = new Vector3(shots[ii].transform.position.x + 1, -7, shots[ii].transform.position.z + 1);

            }
        }

        print(fondu);

        if(fondu)
        {
            i = 0;
            shots = new List<GameObject>();
            ennemyOnPlay = 0;
            fondu = false;
            StartCoroutine(Shooting());
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;//on met le flag a true
    }
    public void WaveEnd()//lorsqu'on a touche la bouboule violette et qu'on est pret a affronter la 2è vague
    {
        gameOverText.text = "";
        fondu = true;
    }
    public bool getWave_end()
    {
        return wave_end;
    }
    public void setWave_end(bool b)
    {
        wave_end = b;
    }
    public bool getFondu()
    {
        return fondu;
    }
    public void setFondu(bool b)
    {
        fondu = b;
    }

    public int getEnnemyOnPlay()
    {
        return ennemyOnPlay;
    }
    public void setEnnemyOnPlay(int b)
    {
        ennemyOnPlay = b;
    }
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