using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject camPos;
    public GameObject salida;
    public Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.Cam.transform.position = camPos.transform.position;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
        salida.SetActive(true);
    }
}
