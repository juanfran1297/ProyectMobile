using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] private int points;
    [SerializeField] private Text textPoints;

    private PlayerController player;
    public CambioColor colorController;

    public Animator rotation;

    public AudioClip pointSound;

    public int cantidadPuntos;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        player = GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
        colorController.CambiarColor(Color.white);
        rotation = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Puntos")
        {
            points += cantidadPuntos;
            MasVelocidad();
            textPoints.text = points.ToString();
            PlayerPrefs.SetInt("Points", points);
        }
        if (points > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", points);
        }
    }

    private void MasVelocidad()
    {
        if (points % 5 == 0 && points != 0 && player.speed <= 15)
        {
            audioSource.PlayOneShot(pointSound);
            player.speed += 1;
        }
        switch(player.speed)
        {
            case 11:
                colorController.CambiarColor(Color.magenta);
                rotation.speed = rotation.speed + .2f;
                break;
            case 12:
                colorController.CambiarColor(Color.blue);
                rotation.speed = rotation.speed + .2f;
                break;
            case 13:
                colorController.CambiarColor(Color.green);
                rotation.speed = rotation.speed + .2f;
                break;
            case 14:
                colorController.CambiarColor(Color.yellow);
                rotation.speed = rotation.speed + .2f;
                break;
            case 15:
                colorController.CambiarColor(Color.red);
                rotation.speed = rotation.speed + .2f;
                break;
        }
    }
}
