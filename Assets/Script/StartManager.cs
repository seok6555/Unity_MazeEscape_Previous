using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject mainUi;
    public GameObject optionUi;
    public GameObject helpUi;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        optionUi.SetActive(false);
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
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }

    public void OnOptionButton()
    {
        optionUi.SetActive(true);
        mainUi.SetActive(false);
    }

    public void OnHelpButton()
    {
        helpUi.SetActive(true);
        mainUi.SetActive(false);
    }

    public void OnBackButton()
    {
        optionUi.SetActive(false);
        helpUi.SetActive(false);
        mainUi.SetActive(true);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }
}
