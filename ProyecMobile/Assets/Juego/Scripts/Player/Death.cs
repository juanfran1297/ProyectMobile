using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public PowerUpsControllers powerUps;
    public Canvas CanvasMuerte;
    public Canvas CanvasPrincipal;
    public Canvas CanvasPowerUps;

    private void Start()
    {
        CanvasPrincipal.enabled = true;
        CanvasPowerUps.enabled = true;
        CanvasMuerte.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (powerUps.invencible && other.tag == "Death")
        {
            powerUps.invencible = false;
            return;
        }

        if (other.tag == "Death")
        {
            HasPerdido();
        }
    }

    private void HasPerdido()
    {
        CanvasPrincipal.enabled = false;
        CanvasPowerUps.enabled = false;
        CanvasMuerte.enabled = true;
        Time.timeScale = 0;
        //SceneManager.LoadScene("Final");
    }

    public void Continuas()
    {
        CanvasPrincipal.enabled = true;
        CanvasPowerUps.enabled = true;
        CanvasMuerte.enabled = false;
    }
}
