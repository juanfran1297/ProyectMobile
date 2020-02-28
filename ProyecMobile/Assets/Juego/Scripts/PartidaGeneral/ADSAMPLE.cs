using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class ADSAMPLE : MonoBehaviour {

	// Use this for initialization
	public Button botonVideo;
	public Text textoBotonVideo;
    public PowerUpsControllers powerUps;

	void Awake() { 
        //INICIALIZAMOS LOS ANUNCIOS:
		if (Advertisement.isSupported) {
				Advertisement.Initialize ("3488151");
                //Advertisement.Initialize ("3426871", true); Modo de prueba, utilizar el de arriba al momento de ir a produccion
        }
        else {
			Debug.Log("Plataforma no soportada");
		}
	}

	public void Update() {

		if(Advertisement.IsReady())
			textoBotonVideo.text = "Add to Shield";//si el anuncio se ha cargado mostrará este texto"
		else
			textoBotonVideo.text = "Esperar...";//si no se ha cargado o no hay internete.
		
	}

    public void ShowAd(string zone = "") //CUANDO QUIERA LLAMAR A UN ANUNCIO, LLAMARÉ A ESTA FUNCION;
	{

		if (string.Equals (zone, ""))
			zone = null;

		ShowOptions options = new ShowOptions ();
		options.resultCallback = AdCallbackhandler;

		if (Advertisement.IsReady (zone))
			Advertisement.Show (zone, options);

		Time.timeScale = 0f;


	}

	void AdCallbackhandler (ShowResult result)
	{
        switch (result)//TRAS VER EL ANUNCIO VEMOS LOS RESULTADOS ¿QUE HA HECHO EL JUGADOR?
		{
		case ShowResult.Finished: //anuncio ha terminado correctamente"
                                  //escribir aqui el premio
            powerUps.Invencible();
            Debug.Log ("Ad Entregado. PREMIAMOS AL JUGADOR...");
			Time.timeScale = 1f;
			break;
		case ShowResult.Skipped: //el jugador ha saltado el anuncio
			Debug.Log ("Ad Descartado. No damos nada...");
			Time.timeScale = 1f;
			break;
		case ShowResult.Failed:
			Debug.Log("Ad Fallo. No hay dinero😦 ");
			Time.timeScale = 1f;
			break;
		}
	}
}
