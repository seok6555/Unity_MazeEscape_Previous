using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject optionUi;
    public GameObject mainUi;
    public GameObject helpUi;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        optionUi = GameObject.Find("Option");
        optionUi.SetActive(false);
        mainUi = GameObject.Find("MainUi");
        helpUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().theAudio.clip = clip;
        GameObject.Find("GameManager").GetComponent<GameManager>().theAudio.Play();
        SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
    }

    public void OptionButton()
    {
        OpenOption();
    }

    public void HelpButton()
    {
        mainUi.SetActive(false);
        helpUi.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        CloseOption();
    }

    public void OpenOption()
    {
        optionUi.SetActive(true);
        mainUi.SetActive(false);
    }

    public void CloseOption()
    {
        optionUi.SetActive(false);
        helpUi.SetActive(false);
        mainUi.SetActive(true);
    }

}
