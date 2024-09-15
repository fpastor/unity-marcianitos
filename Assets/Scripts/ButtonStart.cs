using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
