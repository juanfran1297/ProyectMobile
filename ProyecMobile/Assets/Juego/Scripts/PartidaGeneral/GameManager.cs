using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController pControl;
    public GameObject panel;
    public void Salir()
    {
        PlayerPrefs.DeleteKey("Points");
        Application.Quit();
    }

    public void Continuar()
    {
        panel.SetActive(false);
        pControl.pausa = false;
    }

    public void Pause()
    {
        panel.SetActive(true);
        pControl.pausa = true;
    }
}