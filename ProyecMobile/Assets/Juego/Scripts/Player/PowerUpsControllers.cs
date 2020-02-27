using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpsControllers : MonoBehaviour
{
    #region Variables Imagenes
    public Image shieldImage;
    public Image rotationImage;
    #endregion

    #region Variables PowerUps
    public bool tengoPowerUp = false;

    public bool invencible = false;
    public bool rotation = false;
    #endregion

    #region Variables timer
    [SerializeField] private float tiempo;
    private float tiempoPowerUp;
    public Text timer;
    #endregion

    #region Public Variables
    public CameraController cam;
    [SerializeField] private GameObject forceShield;
    #endregion

    #region Private Variables
    Points puntos;
    #endregion

    PlayerController playerController;

    #region Private Functions
    void Start()
    {
        tiempoPowerUp = 6.3f;
        tiempo = tiempoPowerUp;
        puntos = GetComponent<Points>();
        playerController = GetComponent<PlayerController>();
        timer = GameObject.Find("Canvas PowerUps/TimerPowerUp").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if (invencible == true)
        {
            forceShield.SetActive(true);
            shieldImage.enabled = true;
        }
        else
        {
            forceShield.SetActive(false);
            shieldImage.enabled = false;
        }

        if (rotation == true)
        {
            rotationImage.enabled = true;
            puntos.cantidadPuntos = 2;
            tengoPowerUp = true;
            //StartCoroutine(TimeWait());
            Timer();
            if (tiempo <= 0)
            {
                RotationScreen();
                tiempo = tiempoPowerUp;
                tengoPowerUp = false;
            }
        }
        else
        {
            tengoPowerUp = false;
            tiempo = tiempoPowerUp;
            rotationImage.enabled = false;
            puntos.cantidadPuntos = 1;
            timer.GetComponent<Text>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Invencible":
                Invencible();
                Destroy(other.gameObject);
                break;

            case "Rotation":
                RotationScreen();
                Destroy(other.gameObject);
                break;
        }
    }
    #endregion

    #region PowerUps Functions 
    public void Invencible()
    {
        invencible = true;
    }

    public void RotationScreen()
    {
        rotation = !rotation;

        cam.CambioFlip();
        StartCoroutine(FlipWait());
    }
    #endregion

    #region Timer Functions
    private void Timer()
    {
        //StartCoroutine(TimeWait());
        timer.GetComponent<Text>().enabled = true;
        tiempo -= Time.deltaTime;
        timer.text = "" + tiempo.ToString("f0");

        if (tiempo <= 0)
        {
            timer.GetComponent<Text>().enabled = false;
        }
    }
    #endregion

    #region IEnumerators
    IEnumerator FlipWait()
    {
        playerController.enabled = !playerController.enabled;
        yield return new WaitForSeconds(1.5f);
        playerController.enabled = !playerController.enabled;
    }

    IEnumerator TimeWait()
    {
        yield return new WaitForSeconds(1.5f);
        Timer();
    }
    #endregion
}
