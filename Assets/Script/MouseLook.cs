using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 200f;

    public Transform playerBody;
    public PauseMenu pauseMenu;
    public PlayerMovement playerMovement;
    public EnumManager em;

    float xRotation = 0f;
    bool isCamControl = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CursorVisible();
        CamConrtol();
    }

    void CamConrtol()
    {
        if (isCamControl)
        {
            float mouse = GameObject.Find("GameManager").GetComponent<GameManager>().mouseValue;
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation * mouse, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX * mouse);
        }
        
    }

    void CursorVisible()
    {
        if (pauseMenu.isMenuOpen || em.gameState == GameState.clear || em.gameState == GameState.dead)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isCamControl = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isCamControl = true;
        }
    }
}
