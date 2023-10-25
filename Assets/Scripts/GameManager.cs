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
    GameObject pause;
    const float CREATE_INTERVAL = 1f;
    float mCreatTime = 0;
    float mTotalTime = 0;

    float mNextCreateInterval = CREATE_INTERVAL;

    int mPhase = 1;

    public GameObject fireball;
    public GameObject additionalObject  ;

    TextMeshProUGUI phasetext;
    TextMeshProUGUI lives;
    TextMeshProUGUI score;
    TextMeshProUGUI phase;
    int scoret = 0;
    bool isPaused = false;

    public TextMeshProUGUI bscoreT;
    int bscore = 0;
    string keyname = "best";

    private void Awake()
    {
        bscore = PlayerPrefs.GetInt(keyname, 0);
    }
    private void Start()
    {
        Time.timeScale = 1;
        //Application.targetFrameRate = 60;
        Debug.Log(Time.timeScale);
        gameover = GameObject.Find("Gameover");
        pause = GameObject.Find("Pause");
        gameover.SetActive(false);
        pause.SetActive(false);
        p = GameObject.Find("Player").GetComponent<PlayerM>();
        phasetext = GameObject.Find("PhaseUp").GetComponent<TextMeshProUGUI>();
        lives = GameObject.Find("Life").GetComponent<TextMeshProUGUI>();
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        phase = GameObject.Find("Phase").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isPaused == false)
            {
                Debug.Log("Paused");
                Time.timeScale = 0;
                isPaused = true;
                pause.SetActive(true);
            }
            else
            {
                Debug.Log("Resumed");
                Time.timeScale = 1;
                isPaused = false;
                pause.SetActive(false);
            }
        }
    }
    private void FixedUpdate()
    {
        //Debug.Log(isPaused);
        mTotalTime += Time.deltaTime;
        mCreatTime += Time.deltaTime;
        //Debug.Log(mTotalTime);
        if (mCreatTime > mNextCreateInterval)
        {
            mCreatTime = 0;
            mNextCreateInterval = CREATE_INTERVAL - (0.005f * mTotalTime);
            //Debug.Log("mNextCreateInterval : " + mNextCreateInterval);
            if (mNextCreateInterval < 0.005f)
            {
                mNextCreateInterval = 0.005f;
            }

            for (int i = 0; i < mPhase; i++)
            {
                creatFireball(8f + i * 1f);
            }
        }

        if (mTotalTime >= 5f)
        {
            mTotalTime = 0;
            mPhase++;
            phasetext.text = "Phase Up!!";
            if(mPhase%3 == 0)
                createItem();
        }
        if (mTotalTime >= 2f)
        {
            phasetext.text = "";
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
        if (scoret >= bscore)
        {
            bscore += 1;
            PlayerPrefs.SetInt(keyname, scoret);
        }
        phase.text = mPhase.ToString();
        lives.text = p.getPlayerLives().ToString();
        score.text = scoret.ToString();
        bscoreT.text = $"Best Score : {bscore}";
    }

    private void creatFireball(float y)
    {
        float x = Random.Range(-8.5f, 8.5f);
        createObject(fireball, new Vector3(x, y, 0), Quaternion.Euler(0,0,-90));
    }

    private GameObject createObject(GameObject original, Vector3 position, Quaternion rotation)
    {
        return (GameObject)Instantiate(original, position, rotation);
    }

    private void createItem()
    {
        float x = Random.Range(-8.0f, 8.0f);
        float y = 5.0f;

        createObject(additionalObject, new Vector3(x, y, 0), Quaternion.Euler(0, 0, -90));
    }

    public void Menu()
    {
        isPaused = false;
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        isPaused = false;
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pause.SetActive(false);
    }
}