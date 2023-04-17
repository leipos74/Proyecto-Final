using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public GameObject Player;
    public Camera Cam;
    public GameObject Mecha;
    public GameObject Gun;
    public bool isMouseOnLeft;
    public Vector3 mousePos;

    [Header("Vidas")]
    public int lifePlayer;
    public int lifeEnemy;
    public int damageEnemy;
    public int damagePlayer;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        lifePlayer = 100;
        lifeEnemy = 50;
        damageEnemy = 10;
        damagePlayer = 10;  
    }
    void Update()
    {


        float mousePosX = Input.mousePosition.x / Screen.width;
        isMouseOnLeft = mousePosX < 0.5f;

        mousePos = GameManager.Instance.Cam.ScreenToWorldPoint(Input.mousePosition);

    }

}
