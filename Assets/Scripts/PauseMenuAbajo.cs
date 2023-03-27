using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuAbajo : MonoBehaviour
{
    public static PauseMenuAbajo Instance;
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public Weapon WeaponController;
    public bool Paused;
    

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Paused = false;
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);




    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();

            }
            else
            {
                Time.timeScale = 0.0f;
                Paused = true;
                PauseMenu.SetActive(true);

                WeaponController.enabled = false;
            }

        }


    }
    public void OnButtonPressOptionsJugar()
    {
        OptionsMenu.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }


    public void Resume()
    {
        Time.timeScale = 1;
        Paused = false;
        PauseMenu.SetActive(false);
        WeaponController.enabled = true;

    }
    public void Back()
    {
        OptionsMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }
}
