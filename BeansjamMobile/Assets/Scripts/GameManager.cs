using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager gameManager;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
    }
}
