using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject firstRoom;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = firstRoom.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
