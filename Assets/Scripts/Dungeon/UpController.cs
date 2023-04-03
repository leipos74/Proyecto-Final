using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpController : MonoBehaviour
{
    public string Scene;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pulsa e para entrar");
            if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.key == true)
            {
                Debug.Log("Ahora puedes entrar");
                SceneManager.LoadScene(Scene);
            }

        }
    }
}
