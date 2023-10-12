using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerM p;
    GameObject gameover;
    const float CREATE_INTERVAL = 1f;
    float mCreatTime = 0;
    float mTotalTIme = 0;

    float mNextCreateInterval = CREATE_INTERVAL;

    int mPhase = 1;

    public GameObject fireball;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI score;
    int scoret;
    bool isPaused;

    private void Start()
    {
        Time.timeScale = 1;
        //Application.targetFrameRate = 60;
        Debug.Log(Time.timeScale);
        gameover = GameObject.Find("Gameover");
        gameover.SetActive(false);
        p = GameObject.Find("Player").GetComponent<PlayerM>();
        lives = GameObject.Find("Life").GetComponent<TextMeshProUGUI>();
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        mTotalTIme += Time.deltaTime;
        mCreatTime += Time.deltaTime;
        
        if (mCreatTime > mNextCreateInterval)
        {
            mCreatTime = 0;
            mNextCreateInterval = CREATE_INTERVAL - (0.005f * mTotalTIme);
            //Debug.Log("mNextCreateInterval : " + mNextCreateInterval);
            if (mNextCreateInterval < 0.005f)
            {
                mNextCreateInterval = 0.005f;
            }

            for (int i = 0; i < mPhase; i++)
            {
                creatFireball(5.5f + i * 0.2f);
            }
        }

        if (mTotalTIme >= 10f)
        {
            mTotalTIme = 0;
            mPhase++;
        }
        if(p.getPlayerLives() == 0)
        {
            Time.timeScale = 0;
            isPaused = true;
            Debug.Log("게임 종료");
            gameover.SetActive(true);
        }
        if (isPaused == false)
        {
            scoret += 1;
        }
        lives.text = p.getPlayerLives().ToString();
        score.text = scoret.ToString();
    }

    private void creatFireball(float y)
    {
        float x = Random.Range(-8.5f, 21f);
        createObject(fireball, new Vector3(x, y, 0), Quaternion.Euler(0,0,-140));
    }

    private GameObject createObject(GameObject original, Vector3 position, Quaternion rotation)
    {
        return (GameObject)Instantiate(original, position, rotation);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        isPaused = false;
        SceneManager.LoadScene(0);
    }
}