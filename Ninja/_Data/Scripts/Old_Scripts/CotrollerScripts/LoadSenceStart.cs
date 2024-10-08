using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSenceStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator LoadSceneStart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("i"));
    }
}
