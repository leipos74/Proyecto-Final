using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickRangeWeapon : MonoBehaviour
{
    public static PickRangeWeapon Instance;
    public bool RangePicked;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        RangePicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && this.tag == "Range")
        {
            RangePicked = true;
            Debug.Log("ArmaRange");
            Destroy(this.gameObject);
        }
        
        
    }
}
