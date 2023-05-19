using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartButtonTextController : MonoBehaviour
{
    private bool fadeOut, fadeIn;
    [SerializeField] private float fadeSpeed = 1.0f;
    [SerializeField] private float fadedOpacity = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var text = GetComponent<TextMeshProUGUI>();
        if (fadeOut) {
            if (text.color.a > fadedOpacity) {
                var curAlpha = text.color.a - (fadeSpeed * Time.deltaTime);
                text.color = (new Color(text.color.r, text.color.g, text.color.b, curAlpha));
            } else {
                fadeOut = false;
            }
        } else if (fadeIn) {
            if (text.color.a < 1.0f) {
                var curAlpha = text.color.a + (fadeSpeed * Time.deltaTime);
                text.color = (new Color(text.color.r, text.color.g, text.color.b, curAlpha));
            } else {
                fadeIn = false;
            }
        }
    }

    void SetFadeIn() {
        fadeOut = false;
        fadeIn = true;
    }

    void SetFadeOut() {
        fadeOut = true;
        fadeIn = false;
    }

    void onDraggedStatusChange(bool state) {
        if (state) {
            SetFadeOut();
        } else {
            SetFadeIn();
        }
    }
}
