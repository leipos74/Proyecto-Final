using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerSwap : MonoBehaviour
{
    public GameObject pressE;
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" )
        {
            SceneManager.LoadScene("Planta1");
            Debug.Log("entrasete puerta");
        }
    }


}
