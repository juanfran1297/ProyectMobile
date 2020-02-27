using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InicioPartida : MonoBehaviour
{
    public GameObject objetoTexto;
    public Text timer;
    private float tiempo = 3.0f;

    private void Awake()
    {
        objetoTexto.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if(tiempo <= 0)
        {
            objetoTexto.SetActive(false);
        }
        tiempo -= Time.deltaTime;
        timer.text = "" + tiempo.ToString("f0");
    }
}
