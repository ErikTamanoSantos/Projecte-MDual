using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonController : MonoBehaviour
{
    private bool fadeOut, fadeIn;
    [SerializeField] private float fadeSpeed = 1.0f;
    [SerializeField] private float fadedOpacity = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
		btn.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void Update()
    {
        var image = GetComponent<Image>();
        if (fadeOut) {
            if (image.color.a > fadedOpacity) {
                var curAlpha = image.color.a - (fadeSpeed * Time.deltaTime);
                image.color = (new Color(image.color.r, image.color.g, image.color.b, curAlpha));
            } else {
                fadeOut = false;
            }
        } else if (fadeIn) {
            if (image.color.a < 1.0f) {
                var curAlpha = image.color.a + (fadeSpeed * Time.deltaTime);
                image.color = (new Color(image.color.r, image.color.g, image.color.b, curAlpha));
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

    void onClick() {
        GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();
        GameManager.Instance.State = GameState.BattleStarted;
        GetComponent<Button>().gameObject.SetActive(false);
    }
}
