using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("clickSound");
        if (musicObj.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void playSound() 
    {
        sound.Play();
    }

    public void stopSound()
    {
        sound.Stop();
    }
    }
