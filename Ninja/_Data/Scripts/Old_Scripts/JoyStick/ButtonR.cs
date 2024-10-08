using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonR : MonoBehaviour
{
    public Button btnRight;
    // Start is called before the first frame update
    void Start()
    {
        btnRight = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BetweenR()
    {
       StartCoroutine( ActiveR());
    }    
    public IEnumerator ActiveR()
    {
        btnRight.interactable= false;
        btnRight.image.enabled = false;
        btnRight.tag = "Untagged";
        yield return new WaitForSeconds(2);
        btnRight.interactable = true;
        btnRight.image.enabled = true;
        btnRight.tag = "btnRight";
    }

    public void BetweenR2()
    {
        StartCoroutine(ActiveR2());
    }
    public IEnumerator ActiveR2()
    {
        btnRight.interactable = false;
        btnRight.image.enabled = false;
        btnRight.tag = "Untagged";
        yield return new WaitForSeconds(4);
        btnRight.interactable = true;
        btnRight.image.enabled = true;
        btnRight.tag = "btnRight";
    }
    //vô hiệu hóa 5s 
    public void BetweenR5()
    {
        StartCoroutine(ActiveR5());
    }
    public IEnumerator ActiveR5()
    {
        btnRight.interactable = false;
        btnRight.image.enabled = false;
        btnRight.tag = "Untagged";
        yield return new WaitForSeconds(5);
        btnRight.interactable = true;
        btnRight.image.enabled = true;
        btnRight.tag = "btnRight";
    }

    //enabled nếu chưa hết 5 s
    public void OnEnableR5()
    {
        btnRight.interactable = true;
        btnRight.image.enabled = true;
        btnRight.tag = "btnRight";
    }

    //vô hiệu hóa 9s đầu lúc chạy giới thiệu lv1
    public void BeetweenStartRunLv1()
    {
        StartCoroutine(SetStartRunLv1());
    }
    public IEnumerator SetStartRunLv1()
    {
        btnRight.interactable = false;
        btnRight.image.enabled = false;
        btnRight.tag = "Untagged";
        yield return new WaitForSeconds(9f);
        btnRight.interactable = true;
        btnRight.image.enabled = true;
        btnRight.tag = "btnRight";
    }


}
