using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audio_loop;
    [SerializeField] private string self_tag, other_tag1, other_tag2;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag(self_tag);
        if (musicObj.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void playMusic() 
    {
        if (audio_loop.isPlaying) return;
        GameObject.FindGameObjectWithTag(other_tag1).GetComponent<MusicPlayer>().stopMusic();
        GameObject.FindGameObjectWithTag(other_tag2).GetComponent<MusicPlayer>().stopMusic();
        audio_loop.Play();
    }

    public void stopMusic()
    {
        audio_loop.Stop();
    }
}
