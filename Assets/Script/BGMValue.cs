using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BGMValue : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI valueText;
    float bgmValue;

    // Start is called before the first frame update
    void Start()
    {
        valueText = this.GetComponent<TextMeshProUGUI>();
        bgmValue = GameObject.Find("GameManager").GetComponent<GameManager>().bgmValue;
        slider.value = GameObject.Find("GameManager").GetComponent<GameManager>().bgmValue * 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        bgmValue = Mathf.RoundToInt(slider.value * 100);
        valueText.text = bgmValue + "%";
        GameObject.Find("GameManager").GetComponent<GameManager>().bgmValue = bgmValue;
    }
}
