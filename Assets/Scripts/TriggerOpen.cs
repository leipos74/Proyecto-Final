using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpen : MonoBehaviour
{

    public GameObject PuertaAbierta;
    public GameObject PuertaCerrada;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") { 
        PuertaAbierta.SetActive(true);
        PuertaCerrada.SetActive(false);
        Debug.Log("entrasete puerta");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PuertaAbierta.SetActive(false);
            PuertaCerrada.SetActive(true);
        }
    }
}
