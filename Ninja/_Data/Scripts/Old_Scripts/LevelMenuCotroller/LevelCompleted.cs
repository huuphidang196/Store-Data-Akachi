using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleted : MonoBehaviour
{
    public Sprite imgLoading;
    public Image Completed;
    public Button btnContinue;

    AudioSource audi;
    public AudioClip clickClip;

    void Start()
    {
        audi = GetComponent<AudioSource>();
    }
    public void StartConTinue()
    {
        audi.clip = clickClip;
        audi.Play();
        StartCoroutine(Continue());
    }    
    public IEnumerator Continue()
    {
        
        Completed.GetComponent<Image>().sprite = imgLoading;
        btnContinue.interactable = false;
        btnContinue.image.enabled = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }    


}
