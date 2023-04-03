using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyAI : MonoBehaviour
{
    public static EnemyAI instance;

    public Animator anim;
    [SerializeField] float moveSpeed = 2000;
    [SerializeField] float moving;
    public Transform player;
    public Transform mecha;
    private float lastHitTime; // variable para almacenar el último tiempo en que el enemigo golpeó al jugador
    public float hitDelay = 1.0f; // variable para configurar el tiempo entre ataques del enemigo

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mecha = GameObject.FindGameObjectWithTag("mecha").transform;
        moving = moveSpeed;
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPlayerPosition = player.position - transform.position;
        Vector2 newMechaPosition = mecha.position - transform.position;

        if (SwapCharacter.Instance.playerActive == true)
        {
            transform.Translate(newPlayerPosition * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(newMechaPosition * moveSpeed * Time.deltaTime);

        }


    }
    public void TakeDamagePlayer()
    {

        GameManager.Instance.lifeEnemy -= GameManager.Instance.damagePlayer;

        anim.SetTrigger("Damaged");
        StartCoroutine(speedWait());
        moveSpeed = 0;

        if (GameManager.Instance.lifeEnemy <= 0)
        {

            Dead();

        }

    }
    private IEnumerator speedWait()
    {

        moveSpeed = 1000;
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds((float)0.3);
        GetComponent<BoxCollider2D>().enabled = true;
        moveSpeed = moving;

    }
    private void Dead()
    {
        anim.SetBool("isDead", true);

        Destroy(this.gameObject);

    }

   

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") || (other.gameObject.CompareTag("mecha")) && Time.time > lastHitTime + hitDelay)
        {
            Debug.Log("You hitted player stay");
            GameManager.Instance.lifePlayer -= GameManager.Instance.damageEnemy;
            lastHitTime = Time.time;
        }
    }

}









