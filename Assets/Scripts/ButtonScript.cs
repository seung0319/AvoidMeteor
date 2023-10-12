using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    GameObject inst;
    GameObject main;

    private void Start()
    {
        inst = GameObject.Find("Instruction");
        main = GameObject.Find("Start Screen");
        inst.SetActive(false);
    }
    public void Instruction()
    {
        inst.SetActive(true);
        main.SetActive(false);
    }

    public void Close()
    {
        inst.SetActive(false);
        main.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
