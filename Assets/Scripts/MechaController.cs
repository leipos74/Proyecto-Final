using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechaController : MonoBehaviour
{
    [Header("For Movement")]
    [SerializeField] public float speed;
    [SerializeField] Rigidbody2D playerRB;
    public Vector2 input;

    [Header("For Shooring")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject cohete;
    [SerializeField] float fireRate;
    [SerializeField] float fireRateRocket;
    private float nextFireTime;
    private Rigidbody2D rb;
    public bool isMoving;
    public static PlayerController instance;

    // Start is called before the first frame update
    public Animator anim;
    public SpriteRenderer sr;

    private Collider2D coll;


    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        if (isMoving == true)
        {
            anim.SetBool("Run", true);
        }
        if (isMoving == false)
        {
            anim.SetBool("Run", false);
        }
        isMoving = input.magnitude > 0;
        if (GameManager.Instance.isMouseOnLeft)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

    }

    private void FixedUpdate()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        rb.MovePosition(rb.position + input * speed * Time.fixedDeltaTime);

        if (input.x != 0 || input.y != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
       
        ShootingRocket();

    }

  
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "mecha")
        {
            Debug.Log("hola");
        }
    }
    void ShootingRocket()
    {
        if (Input.GetKey(KeyCode.F) && nextFireTime < Time.time)
        {
            Instantiate(cohete, transform.position, transform.rotation);
            nextFireTime = fireRateRocket + Time.time;
        }
    }
}