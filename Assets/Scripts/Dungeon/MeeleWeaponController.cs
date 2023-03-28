using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleWeaponController : MonoBehaviour
{
    

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


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
