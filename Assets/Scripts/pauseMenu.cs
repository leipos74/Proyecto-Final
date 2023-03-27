using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static pauseMenu instance;
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public CamExtend CamPlayer;
    public Follow CamMecha;
    public Weapon WeaponController;
    public bool isPaused;



    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        if (CamPlayer != null)
        {
            CamPlayer.enabled = true;
        }
        if (CamMecha != null)
        {
            CamMecha.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Time.timeScale = 1.0f;
                isPaused = false;
                PauseMenu.SetActive(false);
                OptionsMenu.SetActive(false);
                WeaponController.enabled = true;

            }
            else
            {
                Time.timeScale = 0.0f;
                isPaused = true;
                PauseMenu.SetActive(true);
                if (CamPlayer != null)
                {
                    CamPlayer.enabled = false;

                }

                if (CamMecha != null)
                {
                    CamMecha.enabled = false;
                }
                WeaponController.enabled = false;
            }

        }


    }
    public void OnButtonPressOptionsJugar()
    {
        OptionsMenu.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 0.0f;
    }


    public void Resume()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        PauseMenu.SetActive(false);

        if (SwapCharacter.Instance.playerActive)
        {
            CamPlayer.enabled = true;
            CamMecha.enabled = false;
            WeaponController.enabled = true;
        }
        else if (!SwapCharacter.Instance.playerActive)
        {
            if (CamPlayer != null)
            {
                CamPlayer.enabled = false;
            }
            if (CamMecha != null)
            {
                CamMecha.enabled = true;
            }
            WeaponController.enabled = false;
            Debug.Log("player inactivo");
        }
        else
        {
            WeaponController.enabled = true;
        }
    }

}
