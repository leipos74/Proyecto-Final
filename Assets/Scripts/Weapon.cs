using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate;
    public float recoil;
    public bool isMouseOnLeft;
    public Vector3 mousePos;

    private float nextFireTime;
    public Rigidbody2D rb;


    private void Start()
    {
        this.gameObject.SetActive(false);
        if (GameManager.Instance.GunPicked)
        {
            this.gameObject.SetActive(true);
        }
    }


    private void Update()
    {

        Vector3 difference = GameManager.Instance.mousePos - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90)
        {



            if (GameManager.Instance.Player.transform.eulerAngles.y == 0)
            {


                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);


            }
            else if (GameManager.Instance.Player.transform.eulerAngles.y == 180)
            {


                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);


            }

        }

        

        if (Input.GetButton("Fire1") && nextFireTime < Time.time)
        {
            Shooting();
        }
    }

    void Shooting()
    {

        Debug.Log("Has disparado");
        Instantiate(bullet, transform.position, transform.rotation);
        rb.AddForce(-transform.eulerAngles * recoil); 
        nextFireTime = fireRate + Time.time;

    }
}