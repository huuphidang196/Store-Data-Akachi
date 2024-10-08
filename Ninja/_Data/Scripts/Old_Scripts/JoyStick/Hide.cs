using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
    public Button btnHide;
    public GameObject Player;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        btnHide = GetComponent<Button>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BetweenHH()
    {
        StartCoroutine(HideH());
    }
    public IEnumerator HideH()
    {
        btnHide.interactable = false;
        anim.SetBool("SetH", true);
        Player.GetComponent<Player>().isHided = true;
        yield return new WaitForSeconds(3);
        btnHide.interactable = true;
        anim.SetBool("SetH", false);
        Player.GetComponent<Player>().isHided = false;
    }
    public void BetweenH2()
    {
        StartCoroutine(ActiveH2());
    }
    public IEnumerator ActiveH2()
    {
        btnHide.interactable = false;
        btnHide.image.enabled = false;
        yield return new WaitForSeconds(2);
        btnHide.interactable = true;
        btnHide.image.enabled = true;
    }

    public void BetweenH3()
    {
        StartCoroutine(ActiveH3());
    }
    public IEnumerator ActiveH3()
    {
        btnHide.interactable = false;
        btnHide.image.enabled = false;
        yield return new WaitForSeconds(4);
        btnHide.interactable = true;
        btnHide.image.enabled = true;
    }
    //vô hiệu hóa 9s đầu lúc chạy giới thiệu lv1
    public void BeetweenStartRunLv1()
    {
        StartCoroutine(SetStartRunLv1());
    }
    public IEnumerator SetStartRunLv1()
    {
        btnHide.interactable = false;
        btnHide.image.enabled = false;
        yield return new WaitForSeconds(9f);
        btnHide.interactable = true;
        btnHide.image.enabled = true;
    }
}
