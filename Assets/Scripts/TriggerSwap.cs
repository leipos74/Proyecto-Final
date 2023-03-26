using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSwap : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))  
        {
            Debug.Log("dale a la e");
            SceneManager.LoadScene("Abajo");
            Debug.Log("entrasete puerta");
        }
    }

    
}
