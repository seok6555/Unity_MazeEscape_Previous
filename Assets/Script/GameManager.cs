using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    public AudioSource theAudio;

    public float soundValue;
    public float mouseValue;
    public float bgmValue;

    #region singleton
    void Awake() //��ü ������ ���� ����.
    {
        soundValue = 100f;
        mouseValue = 1f;
        bgmValue = 5f;

        theAudio = GetComponent<AudioSource>();
        theAudio.Play();

        Screen.SetResolution(1920, 1080, true);

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion singleton

    // Update is called once per frame
    void Update()
    {
        theAudio.volume = bgmValue * 0.01f;
    }
}
