using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public PowerUpsControllers powerUps;

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
        SceneManager.LoadScene("Final");
    }
}
