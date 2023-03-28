using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    public static PickItem Instance;
    public bool MeelePicked;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        MeelePicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && this.tag == "Meele")
        {
            Debug.Log("ArmaMeele");
            MeelePicked = true;
            Destroy(this.gameObject);
        }
        
    }
}
