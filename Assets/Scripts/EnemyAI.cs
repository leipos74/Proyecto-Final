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
    public int maxhealthEnemy = 100;
    int currentHealth;
    private float lastCollisionTime = 0f;
    public float collisionCooldown = 1f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mecha = GameObject.FindGameObjectWithTag("mecha").transform;
        currentHealth = maxhealthEnemy;
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

        currentHealth -= GameManager.Instance.damagePlayer;

        anim.SetTrigger("Damaged");
        StartCoroutine(speedWait());
        moveSpeed = 0;

        if (currentHealth <= 0)
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
        GetComponent<Collider2D>().enabled = false;

        this.enabled = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time - lastCollisionTime > collisionCooldown)
        {
            Debug.Log("You hitted player");
            GameManager.Instance.lifePlayer -= GameManager.Instance.damageEnemy;
            lastCollisionTime = Time.time;
        }
    }
}








