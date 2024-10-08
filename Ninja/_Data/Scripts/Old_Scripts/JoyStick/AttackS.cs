using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackS : MonoBehaviour
{
    Animator anim;
    public Button btnStart;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        btnStart = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BetweenSt()
    {
        StartCoroutine(ST());
    }
    public void BetweenHS()
    {
        StartCoroutine(HideS());
    }
    public IEnumerator HideS()
    {
        btnStart.interactable = false;
        btnStart.image.enabled = false;
        yield return new WaitForSeconds(5);
        btnStart.interactable = true;
        btnStart.image.enabled = true;
    }
    public IEnumerator ST()
    {
        anim.SetBool("SetS", true);
        btnStart.interactable = false;
        yield return new WaitForSeconds(0.25f);
        anim.SetBool("SetS", false);
        btnStart.interactable = true;
    }    
    public void BetweenS()
    {
        StartCoroutine(ActiveS());
    }  
    public IEnumerator ActiveS()
    {
        btnStart.interactable = false;
        btnStart.image.enabled = false;
        yield return new WaitForSeconds(2);
        btnStart.interactable = true;
        btnStart.image.enabled = true;
    }

    public void BetweenS2()
    {
        StartCoroutine(ActiveS2());
    }
    public IEnumerator ActiveS2()
    {
        btnStart.interactable = false;
        btnStart.image.enabled = false;
        yield return new WaitForSeconds(4);
        btnStart.interactable = true;
        btnStart.image.enabled = true;
    }

    //vô hiệu hóa 9s đầu lúc chạy giới thiệu lv1
    public void BeetweenStartRunLv1()
    {
        StartCoroutine(SetStartRunLv1());
    }
    public IEnumerator SetStartRunLv1()
    {
        btnStart.interactable = false;
        btnStart.image.enabled = false;
        yield return new WaitForSeconds(9f);
        btnStart.interactable = true;
        btnStart.image.enabled = true;
    }
}
