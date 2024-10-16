using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateCounter : MonoBehaviour
{
    TextMeshProUGUI myText;
    private int counter = 0;

    void Start() {
        myText = gameObject.GetComponent<TextMeshProUGUI>();
        myText.text = "0";
    }

    public void resetCounter() {
        counter = 0;
        myText.text = counter.ToString();
    }

    public void incrementCounter(int value) {
        counter += value;
        myText.text = counter.ToString();
    }
}
