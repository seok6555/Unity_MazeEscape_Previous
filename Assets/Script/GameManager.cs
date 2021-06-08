using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance; //자기 자신을 인스턴스화 함.
    public float soundValue;
    public float mouseValue;
    public float bgmValue;
    public AudioSource theAudio;

    #region singleton
    void Awake() //객체 생성시 최초 실행.
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
