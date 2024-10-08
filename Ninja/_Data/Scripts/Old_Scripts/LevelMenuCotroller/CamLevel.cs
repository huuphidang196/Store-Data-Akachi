using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLevel : MonoBehaviour
{
    private AudioSource audi;
    public AudioClip LevelClip;
    public int Volum;
    // Start is called before the first frame update
    void Awake()
    {
        Volum = PlayerPrefs.GetInt("SoundLv",1);
        PlayerPrefs.SetInt("SoundLv", Volum);
        audi = GetComponent<AudioSource>();
    }
    void Start()
    {
        audi.volume = PlayerPrefs.GetInt("SoundLv");
        audi.clip = LevelClip;
        audi.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audi.volume = PlayerPrefs.GetInt("SoundLv");
    }
}
