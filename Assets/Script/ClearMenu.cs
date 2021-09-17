using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ClearMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject clearUi;
    public EnumManager em;
    public TextMeshProUGUI text;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        clearUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (em.gameState != GameState.play)
        {
            ClearMenuOpen();
        }
    }

    void ClearMenuOpen()
    {
        clearUi.SetActive(true);
        if (em.gameState == GameState.clear)
        {
            text.text = "Congratulations!";
        }

        if (em.gameState == GameState.dead)
        {
            text.text = "Dead";
        }

        Time.timeScale = 0f;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MainScene");
        em.gameState = GameState.play;
        Time.timeScale = 1f;
    }

    public void ExitButton()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().theAudio.clip = clip;
        GameObject.Find("GameManager").GetComponent<GameManager>().theAudio.Play();
        SceneManager.LoadScene("StartScene");
    }
}
