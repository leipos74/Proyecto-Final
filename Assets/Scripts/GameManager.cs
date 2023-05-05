using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public GameObject Player;
    public Camera Cam;
    public GameObject Mecha;
    public GameObject Gun;
    public GameObject floorGun;
    public bool isMouseOnLeft;
    public Vector3 mousePos;

    [Header("Vidas")]
    public int lifePlayer;
    public int lifeEnemy;
    public int damageEnemy;
    public int damagePlayer;

    public bool GunPicked;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
           
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        FindCamera();
        SceneManager.activeSceneChanged += onSceneStart;
        lifePlayer = 100;
        lifeEnemy = 50;
        damageEnemy = 10;
        damagePlayer = 10;
        GunPicked = false;
        Gun.SetActive(false);
    }
    void Update()
    {
        if (PickRangeWeapon.Instance.RangePicked)
        {
            GunPicked = true;
            Gun.SetActive(true); 

        }

        float mousePosX = Input.mousePosition.x / Screen.width;
        isMouseOnLeft = mousePosX < 0.5f;

        mousePos = GameManager.Instance.Cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void onSceneStart(Scene current, Scene next)
    {
        FindCamera();
        Debug.Log("ENTRAAAA");
    }

    private void FindCamera()
    {
        Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

}
