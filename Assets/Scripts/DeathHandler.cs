using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverMenu;

    void Start()
    {
        gameOverMenu.enabled = false;
    }

    public void HandleDeath()
    {
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        gameOverMenu.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
}
