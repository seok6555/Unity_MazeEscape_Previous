using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseValue : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI valueText;
    float mouseValue;

    // Start is called before the first frame update
    void Start()
    {
        valueText = this.GetComponent<TextMeshProUGUI>();
        mouseValue = GameObject.Find("GameManager").GetComponent<GameManager>().mouseValue;
        slider.value = GameObject.Find("GameManager").GetComponent<GameManager>().mouseValue;
    }

    // Update is called once per frame
    void Update()
    {
        mouseValue = (float)System.Math.Round(slider.value,2);
        valueText.text = mouseValue + "";
        GameObject.Find("GameManager").GetComponent<GameManager>().mouseValue = mouseValue;
    }
}
