using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void GoToMenu(){
        SceneManager.LoadScene(0);
    }

    public void GoToGame(){
        SceneManager.LoadScene(1);
    }
}
