using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundValue : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI valueText;
    float soundValue;

    // Start is called before the first frame update
    void Start()
    {
        valueText = this.GetComponent<TextMeshProUGUI>();
        soundValue = GameObject.Find("GameManager").GetComponent<GameManager>().soundValue;
        slider.value = GameObject.Find("GameManager").GetComponent<GameManager>().soundValue * 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        soundValue = Mathf.RoundToInt(slider.value * 100);
        valueText.text = soundValue + "%";
        GameObject.Find("GameManager").GetComponent<GameManager>().soundValue = soundValue;
    }
}
