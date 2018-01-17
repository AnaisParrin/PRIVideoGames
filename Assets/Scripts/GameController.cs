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
    private bool ennemyOnPlay;
    private int indexFrame;
    private ReadTxt r;

    void Start()
    {
        restart = false;
        restartText.text = "";
        gameOver = false;
        gameOverText.text = "";
        wave_end = false;
        fondu = false;

        i = 0;
        shots = new List<GameObject>();
        ennemyOnPlay = false;
        r = new ReadTxt();

        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        GameObject shotty;

        indexFrame = 0;
        r.GetPosition(indexFrame);
        yield return new WaitForSeconds((float)startWait);

        while (!gameOver && i!=(r.getCoordX().Count))
        {
            Vector3 shotPosition = new Vector3((float)(-6 + (r.getCoordX()[0] * (12.0 / 20.0))), -7, (float)(1 + (r.getCoordZ()[0] * (12.0 / 20.0))));

            shotty = Instantiate(shot, shotPosition, Quaternion.identity);//on fait apparaitre notre astéroid
            shots.Add(shotty);
            i++;

            //yield return new WaitForSeconds((float)btwShotsWait);
        }
        ennemyOnPlay = true;
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
        if(ennemyOnPlay)
        {
            for (int ii = 0; ii < Mathf.Min(shots.Count, r.getCoordX().Count); ii++)
            {
                shots[ii].transform.position = new Vector3((float)(-6 + r.getCoordX()[ii] * (12.0 / 20.0)), -7, (float)(1 + r.getCoordZ()[ii] * (12.0 / 20.0)));
            }
            indexFrame++;
        }




        if (indexFrame <= (r.getNbFrame()-1))
        {
            r.GetPosition(indexFrame);
        }
        

        if(fondu)
        {
            i = 0;
            shots = new List<GameObject>();
            ennemyOnPlay = false;
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
}