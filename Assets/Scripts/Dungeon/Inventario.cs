using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public GameObject meeleWeapon;
    public GameObject meeleWeaponButton;
    public SpriteRenderer rangeWeapon;
    public Weapon weaponController;
    public GameObject rangeWeaponButton;
    public GameObject botonVolver;
    public GameObject panel;
    public bool pausado;
    
    // Start is called before the first frame update
    void Start()
    {
        pausado = false;
        weaponController.enabled = true;
        meeleWeaponButton.SetActive(false);
        rangeWeaponButton.SetActive(false);
        botonVolver.SetActive(false);
        panel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!pausado)
            {             
                if (PickRangeWeapon.Instance.RangePicked)
                {
                    rangeWeaponButton.SetActive(true);
                    Debug.Log("ArmaRange");

                }
                if (PickItem.Instance.MeelePicked)
                {
                    meeleWeaponButton.SetActive(true);
                    Debug.Log("ArmaMeele");

                }
                Time.timeScale = 0.0f;
                panel.SetActive(true);
                botonVolver.SetActive(true);
                pausado = true;

            }
            else
            {
                Reset();
            }
        }
    }

    public void Reset()
    {
        pausado = false;
        meeleWeaponButton.SetActive(false);
        rangeWeaponButton.SetActive(false);
        botonVolver.SetActive(false);
        panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void MeeleWeapon()
    {
        meeleWeapon.SetActive(true);
        rangeWeapon.enabled = false;
        weaponController.enabled = false;
    }
    public void RangeWeapon()
    {
        meeleWeapon.SetActive(false);
        rangeWeapon.enabled = true;
        weaponController.enabled = true;
    }
}
