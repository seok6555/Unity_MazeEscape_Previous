using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PauseMenu pauseMenu;
    public EnumManager em;
    private AudioSource theAudio;

    void Start()
    {
        theAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        FootStepSound();
    }

    void FootStepSound()
    {
        theAudio.volume = GameObject.Find("GameManager").GetComponent<GameManager>().soundValue * 0.01f;
        if (playerMovement.isMoving && playerMovement.isGrounded && !pauseMenu.isMenuOpen && em.gameState == GameState.play)
        {
            if (!theAudio.isPlaying)
            {
                theAudio.Play();
            }
        }
        else
        {
            theAudio.Stop();
        }
    }
}
