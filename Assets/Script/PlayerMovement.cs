using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public EnumManager em;
    public PauseMenu pauseMenu;

    public float speed = 8f;
    public float gravity = -19.62f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;

    public Transform groundCheck;
    public LayerMask groundMask;
    Vector3 velocity;

    public bool isGrounded;
    public bool isMoving;

    public GameObject flashLight;
    bool isFlash = true;

    public float stamina = 5.0f;
    private bool isRunnig = false;
    private bool active = true;
    public GameObject stamina_guage;
    public GameObject stamina_max;

    public float flash_guage = 10.0f;
    public GameObject flashLight_guage;
    float guage_up;

    private AudioSource theAudio;
    public AudioClip run;
    public AudioClip walk;

    void Start()
    {
        stamina = 5.0f;
        theAudio = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FlashLight();
        StaminaGauge();
        FlashGauge();
    }

    void Move()
    {
        if (!isMoving)
        {
            if (stamina < 5)
            {
                stamina += Time.deltaTime;
            }
            else stamina = 5.0f;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
        {
            isMoving = true;
            Run();

        }
        else
        {
            isMoving = false;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) active = true;

        if(active)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (stamina < 0.1)
                {
                    isRunnig = false;
                }
                else isRunnig = true;
            }
            else isRunnig = false;
        }
        

        if(isRunnig)
        {
            theAudio.clip = run;
            stamina -= Time.deltaTime;
            speed = 13.0f;
        } else
        {
            theAudio.clip = walk;
            if (stamina < 5)
            {
                stamina += Time.deltaTime * 0.8f;
            }
            else stamina = 5.0f;
            speed = 8.0f;
        }

        if(stamina < 0.1)
        {
            active = false;
            isRunnig = false;
        }
    }

    void StaminaGauge()
    {
        float scale = stamina * 0.4f;
        stamina_guage.transform.localScale = new Vector3(scale, 1, 1);
        if (stamina == 5.0f) stamina_max.SetActive(false);
        else stamina_max.SetActive(true);
    }

    void FlashLight()
    {
        if (Input.GetKeyDown(KeyCode.Q) && em.gameState == GameState.play && !pauseMenu.isMenuOpen)
        {
            if (!isFlash)
            {
                isFlash = true;
            }
            else
            {
                isFlash = false;
            }
        }

        if (!isFlash)
        {
            guage_up += Time.deltaTime;
            flashLight.SetActive(false);
            if (flash_guage < 10)
            {
                if(guage_up > 3.0f)
                    flash_guage += Time.deltaTime * 0.9f;
            }
            else flash_guage = 10f;
        } 
        else
        {
            if (flash_guage > 0)
            {
                flashLight.SetActive(true);
                flash_guage -= Time.deltaTime;
                guage_up = 0f;
            }
            else isFlash = false;
        }

    }

    void FlashGauge()
    {
        float scale = flash_guage * 0.05f;
        flashLight_guage.transform.localScale = new Vector3(scale, 1, 1);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("enter");
            em.gameState = GameState.clear;
        }
        if (other.CompareTag("Monster"))
        {
            Debug.Log("dead");
            em.gameState = GameState.dead;
        }
    }
}
