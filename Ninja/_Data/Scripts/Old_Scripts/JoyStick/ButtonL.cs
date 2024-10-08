using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonL : MonoBehaviour
{
    public Button btnLeft;
    // Start is called before the first frame update
    void Start()
    {
        btnLeft = GetComponent<Button>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BetweenL()
    {
       StartCoroutine(ActiveL());
    }
    public IEnumerator ActiveL()
    {
        btnLeft.interactable = false;
        btnLeft.image.enabled = false;
        btnLeft.tag = "Untagged";
        yield return new WaitForSeconds(2f);
        btnLeft.interactable = true;
        btnLeft.image.enabled = true;
        btnLeft.tag = "btnLeft";
        Debug.Log("ConCho");
    }
   
    public void BetweenL2()
    {
        StartCoroutine(ActiveL2());
    }
    public IEnumerator ActiveL2()
    {
        btnLeft.interactable = false;
        btnLeft.image.enabled = false;
        btnLeft.tag = "Untagged";
        yield return new WaitForSeconds(4);
        btnLeft.interactable = true;
        btnLeft.image.enabled = true;
        btnLeft.tag = "btnLeft";

    }
    //vô hiệu hóa 5s hied
    public void BetweenL5()
    {
        StartCoroutine(ActiveL5());
    }
    public IEnumerator ActiveL5()
    {
        btnLeft.interactable = false;
        btnLeft.image.enabled = false;
        btnLeft.tag = "Untagged";
        yield return new WaitForSeconds(5f);
        btnLeft.interactable = true;
        btnLeft.image.enabled = true;
        btnLeft.tag = "btnLeft";
    }
    //enabled nếu chưa hết 5 s
    public void OnEnableL5()
    {
        btnLeft.interactable = true;
        btnLeft.image.enabled = true;
        btnLeft.tag = "btnLeft";
    }
    //vô hiệu hóa 9s đầu lúc chạy giới thiệu lv1
    public void BeetweenStartRunLv1()
    {
        StartCoroutine(SetStartRunLv1());
    }
    public IEnumerator SetStartRunLv1()
    {
        btnLeft.interactable = false;
        btnLeft.image.enabled = false;
        btnLeft.tag = "Untagged";
        yield return new WaitForSeconds(9f);
        btnLeft.interactable = true;
        btnLeft.image.enabled = true;
        btnLeft.tag = "btnLeft";
    }
}
