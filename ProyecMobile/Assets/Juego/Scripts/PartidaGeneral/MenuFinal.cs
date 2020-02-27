using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFinal : MonoBehaviour
{

    private void Start()
    {
        Application.targetFrameRate = 300;
    }
    public void Salir()
    {
        PlayerPrefs.DeleteKey("Points");
        Application.Quit();
    }

    public void PlayAgain()
    {
        PlayerPrefs.DeleteKey("Points");
        SceneManager.LoadScene("Juego");
    }
}
