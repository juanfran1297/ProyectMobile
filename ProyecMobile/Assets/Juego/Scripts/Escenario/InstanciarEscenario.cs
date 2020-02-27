using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InstanciarEscenario : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private GameObject nuevoSuelo;    
    [SerializeField] private GameObject obstaculo;

    private GameObject nuevoObstaculo;

    private GameObject nuevoPowerUp;
    #endregion

    #region Public Varibles
    public GameObject[] powerUp;
    public GameObject[] nuevaRampa;

    public GameObject player;
    public GameObject sueloMesh;
    public Transform posicionSpawnSuelo;
    public Transform posicionSpawnRampa;
    public float waitTime = 1.5f;

    public bool puedoinstanciar = true;
    public bool instanciarObstaculo = true;
    #endregion

    #region Start y Update
    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if ((player.transform.position.x - 25 > transform.position.x))
        {
                Destroy(gameObject);
        }
        if ((player.transform.position.x - 25 > transform.position.x))
        {
            if (nuevoObstaculo != null)
            {
                Destroy(nuevoObstaculo);
            }

            if (nuevoPowerUp != null)
            {
                Destroy(nuevoPowerUp);
            }
        }

        if(puedoinstanciar == true && transform.position.x < (player.transform.position.x + 25)){
            CrearEscenario();
            puedoinstanciar = false;
        }
    }
    #endregion

    #region Power Ups
    public void CrearPowerUp()
    {
        var randomPowerUp = Random.Range(0, powerUp.Length);

        float respawnRandom = Random.Range(nuevoSuelo.transform.localPosition.x - 1, nuevoSuelo.transform.localPosition.x + 9);
        nuevoPowerUp = Instantiate(powerUp[randomPowerUp], new Vector3(respawnRandom, nuevoSuelo.transform.localPosition.y + 3,
            nuevoSuelo.transform.position.z),
            Quaternion.identity);
        StartCoroutine(EsperarPowerUp());
    }

    IEnumerator EsperarPowerUp()
    {
        yield return new WaitForSeconds(6);
    }
    #endregion

    #region Obstaculos
    public void CrearObstaculo()
    {
        float respawnRandom = Random.Range(sueloMesh.transform.position.x - 2f, sueloMesh.transform.position.x + 4f);
        if(sueloMesh.layer == 10)
        {
            return;
        }
        else
        {
            nuevoObstaculo = Instantiate(obstaculo, new Vector3(respawnRandom, sueloMesh.transform.position.y + 1,
            sueloMesh.transform.position.z),
            Quaternion.identity);
            StartCoroutine(EsperarObstaculo());
        }
    }
    IEnumerator EsperarObstaculo()
    {
        float tiempoEspera = Random.Range(1, 3);
        yield return new WaitForSeconds(tiempoEspera);
    }
    #endregion

    #region Escenario
    public void CrearEscenario()
    {
        float accion = Random.Range(0, 100);
        if (accion < 25)
        {
            instanciarObstaculo = false;
            var randomRampa = Random.Range(0, nuevaRampa.Length);

            Instantiate(nuevaRampa[randomRampa], posicionSpawnRampa.position, nuevaRampa[randomRampa].transform.rotation);
        }
        else if (accion >= 25)
        {
            instanciarObstaculo = true;
            Instantiate(nuevoSuelo, posicionSpawnSuelo.position, Quaternion.identity);

            CrearObstaculo();
        }

        float randomPowerUp = Random.Range(0, 100);

        if (player.GetComponent<PowerUpsControllers>().tengoPowerUp)
        {
            return;
        }
        else if (randomPowerUp > 75)
        {
            CrearPowerUp();
        }
    }
    #endregion
}
