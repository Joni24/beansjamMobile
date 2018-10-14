using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;
    private int currentScene = 0;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(++currentScene);
    }
}
