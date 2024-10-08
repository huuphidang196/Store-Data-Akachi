using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLoading : MonoBehaviour
{

    public AudioSource audi;
    public AudioClip LoadingClip;
    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();
        audi.clip = LoadingClip;
        audi.Play();
        audi.volume = PlayerPrefs.GetInt("SoundLv");
    }

    // Update is called once per frame
    void Update()
    {
        audi.volume = PlayerPrefs.GetInt("SoundLv");
    }
}
