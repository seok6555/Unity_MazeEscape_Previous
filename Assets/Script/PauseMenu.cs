using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isMenuOpen;
    public GameObject optionUi;
    public GameObject buttons;
    public GameObject helpUi;
    public EnumManager em;
    public AudioClip clip;

    [SerializeField]
    private GameObject go_BaseUi;

    // Start is called before the first frame update
    void Start()
    {
        isMenuOpen = false;
        helpUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) | Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isMenuOpen)
            {
                MenuOpen();
            }
            else
            {
                CloseMenu();
            }
        }
    }

    void MenuOpen()
    {
        if(em.gameState == GameState.play)
        {
            isMenuOpen = true;
            go_BaseUi.SetActive(true);
            buttons.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void CloseMenu()
    {
        isMenuOpen = false;
        go_BaseUi.SetActive(false);
        optionUi.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ResumeButton()
    {
        CloseMenu();
    }

    public void OptionButton()
    {
        OpenOption();
    }

    public void HelpUiButton()
    {
        helpUi.SetActive(true);
        buttons.SetActive(false);
    }

    public void ExitButton()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().theAudio.clip = clip;
        GameObject.Find("GameManager").GetComponent<GameManager>().theAudio.Play();
        SceneManager.LoadScene("StartScene");
    }

    public void OpenOption()
    {
        optionUi.SetActive(true);
        buttons.SetActive(false);
    }

    public void CloseOption()
    {
        optionUi.SetActive(false);
        buttons.SetActive(true);
        helpUi.SetActive(false);
    }
}
