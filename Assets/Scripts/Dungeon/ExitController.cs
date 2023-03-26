using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    public GameObject cam;
    public GameObject entrada;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.Cam.transform.position = cam.transform.position;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
        entrada.SetActive(true);
    }
}
