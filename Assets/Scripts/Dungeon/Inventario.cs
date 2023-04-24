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
    bool meelePicked = false;
    bool rangePicked = false;


    // Start is called before the first frame update
    void Start()
    {
        rangeWeapon.enabled = false;
        meeleWeapon.SetActive(false);
        weaponController.enabled = false;

        meeleWeaponButton.SetActive(false);
        rangeWeaponButton.SetActive(false);

        

    }

    // Update is called once per frame
    void Update()
    {            
        if (PickRangeWeapon.Instance.RangePicked && !rangePicked)
        {
            rangeWeaponButton.SetActive(true);
            RangeWeapon();
            PickRangeWeapon.Instance.RangePicked = true;
            rangePicked = true;
        }
        if (PickItem.Instance.MeelePicked && !meelePicked)
        {
            meeleWeaponButton.SetActive(true);
            MeeleWeapon();
            PickItem.Instance.MeelePicked = true;
            meelePicked = true;
        }
        if (Input.GetKey(KeyCode.Alpha1) && rangePicked == true)
        {
            RangeWeapon();
            Debug.Log("le das al 1");
        }
        else if (Input.GetKey(KeyCode.Alpha2) && meelePicked == true)
        {
            MeeleWeapon();
            Debug.Log("le das al 2");
        }
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
