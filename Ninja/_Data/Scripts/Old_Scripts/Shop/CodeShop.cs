using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeShop : MonoBehaviour
{
    public Button Btn0, Btn1, Btn2, Btn3, Btn4, Btn5, Btn6, Btn7, Btn8, Btn9;
    public Text txtA, txtB, txtC, txtD, txtE, txtF, txtG;
    public bool deleted, Ok;
    
    public int i = 0;
    public int A, B, C, D, E, F, G;
    public int code;
    public int currentGold, currentDM;
    public int Nop20kGold, Nop50kGold;
    
    public Text txtChucMung;

    // Start is called before the first frame update\

    public void Awake()
    {
        PlayerPrefs.GetInt("X", 0);
        PlayerPrefs.GetInt("A", 0);
        PlayerPrefs.GetInt("B", 0);
        PlayerPrefs.GetInt("C", 0);
        PlayerPrefs.GetInt("D", 0);
        PlayerPrefs.GetInt("E", 0);
        PlayerPrefs.GetInt("F", 0);
        PlayerPrefs.GetInt("G", 0);
    }
    void Start()
    {
        currentGold = PlayerPrefs.GetInt("goldT");
        currentDM = PlayerPrefs.GetInt("dimondT");
        Nop20kGold = 3 * currentGold + 2 * currentDM + 1962001 + currentGold - currentDM;
        Nop50kGold = 6 * currentGold + 19 * currentDM + 2412001 + currentGold - currentDM;

        txtChucMung.enabled = false;
        txtA.enabled = false;
        txtB.enabled = false;
        txtC.enabled = false;
        txtD.enabled = false;
        txtE.enabled = false;
        txtF.enabled = false;
        txtG.enabled = false;
        deleted = false;
        Ok = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentGold = PlayerPrefs.GetInt("goldT");
        currentDM = PlayerPrefs.GetInt("dimondT");
        Nop20kGold = 3 * currentGold + 2 * currentDM + 1962001 + currentGold - currentDM ;
        Nop50kGold = 6 * currentGold + 19 * currentDM + 2412001 + currentGold - currentDM;

        if (deleted == false)
        {
            if (i == 1)
            {
                txtA.text = "" + PlayerPrefs.GetInt("X").ToString();
                PlayerPrefs.SetInt("A", PlayerPrefs.GetInt("X"));
                A = PlayerPrefs.GetInt("A");
                Debug.Log(PlayerPrefs.GetInt("A"));
                txtA.enabled = true;
            }
            else if (i == 2)
            {
                txtB.text = "" + PlayerPrefs.GetInt("X").ToString();
                PlayerPrefs.SetInt("B", PlayerPrefs.GetInt("X"));
                B = PlayerPrefs.GetInt("B");
                txtB.enabled = true;
            }
            else if (i == 3)
            {
                txtC.text = "" + PlayerPrefs.GetInt("X").ToString();
                PlayerPrefs.SetInt("C", PlayerPrefs.GetInt("X"));
                C = PlayerPrefs.GetInt("C");
                txtC.enabled = true;
            }
            else if (i == 4)
            {
                txtD.text = "" + PlayerPrefs.GetInt("X").ToString();
                PlayerPrefs.SetInt("D", PlayerPrefs.GetInt("X"));
                D = PlayerPrefs.GetInt("D");
                txtD.enabled = true;
            }
            else if (i == 5)
            {
                txtE.text = "" + PlayerPrefs.GetInt("X").ToString();
                PlayerPrefs.SetInt("E", PlayerPrefs.GetInt("X"));
                E = PlayerPrefs.GetInt("E");
                txtE.enabled = true;
            }
            else if (i == 6)
            {
                txtF.text = "" + PlayerPrefs.GetInt("X").ToString();
                PlayerPrefs.SetInt("F", PlayerPrefs.GetInt("X"));
                F = PlayerPrefs.GetInt("F");
                txtF.enabled = true;
            }
            else if (i == 7)
            {
                txtG.text = "" + PlayerPrefs.GetInt("X").ToString();
                PlayerPrefs.SetInt("G", PlayerPrefs.GetInt("X"));
                G = PlayerPrefs.GetInt("G");
                txtG.enabled = true;
            }
        }    
        
        if(i == 8)
        {
            i = 0;
        }
        if (txtG.enabled == true && i == 0 && Ok == false)
        {
            Btn0.interactable = false;
            Btn1.interactable = false;
            Btn2.interactable = false;
            Btn3.interactable = false;
            Btn4.interactable = false;
            Btn5.interactable = false;
            Btn6.interactable = false;
            Btn7.interactable = false;
            Btn8.interactable = false;
            Btn9.interactable = false;
        }    
    }
    public void btn1()
    {
        i++;
        deleted = false;
        Ok = false;
        txtChucMung.enabled = false;
        PlayerPrefs.SetInt("X", 1);
    }
    public void btn2()
    {
        i++;
        deleted = false;
        Ok = false;
        txtChucMung.enabled = false;
        PlayerPrefs.SetInt("X", 2);
    }
    public void btn3()
    {
        i++;
        deleted = false;
        Ok = false;
        txtChucMung.enabled = false;
        PlayerPrefs.SetInt("X", 3);
    }
    public void btn4()
    {
        i++;
        deleted = false;
        Ok = false;
        txtChucMung.enabled = false;
        PlayerPrefs.SetInt("X", 4);
    }
    public void btn5()
    {
        i++;
        deleted = false;
        txtChucMung.enabled = false;
        PlayerPrefs.SetInt("X", 5);
    }
    public void btn6()
    {
        i++;
        deleted = false;
        Ok = false;
        txtChucMung.enabled = false;
        PlayerPrefs.SetInt("X", 6);
    }
    public void btn7()
    {
        i++;
        deleted = false;
        Ok = false;
        txtChucMung.enabled = false;
        PlayerPrefs.SetInt("X", 7);
    }
    public void btn8()
    {
        i++;
        deleted = false;
        Ok = false;
        txtChucMung.enabled = false;
        PlayerPrefs.SetInt("X", 8);
    }
    public void btn9()
    {
        i++;
        deleted = false;
        Ok = false;
        txtChucMung.enabled = false;
        PlayerPrefs.SetInt("X", 9);
    }
    public void btn0()
    {
        i++;
        deleted = false;
        Ok = false;
        txtChucMung.enabled = false;
        PlayerPrefs.SetInt("X", 0);
    }
    public void btnXoa()
    {
        deleted = true;
        Ok = false;
        if (i == 1)
        {
            txtA.enabled = false;
            i--;
        }
        else if (i == 2)
        {
            txtB.enabled = false;
            i--;
        }
        else if (i == 3)
        {
            txtC.enabled = false;
            i--;
        }
        else if (i == 4)
        {
            txtD.enabled = false;
            i--;
        }
        else if (i == 5)
        {
            txtE.enabled = false;
            i--;
        }
        else if (i == 6)
        {
            txtF.enabled = false;
            i--;
        }
        else if (i == 7)
        {
            txtG.enabled = false;
            i--;
        }
        // Khi vô hiệu hóa
        if(i == 0 && txtG.enabled == true)
        {
            txtG.enabled = false;
            i = 7;
            i--;
            Btn0.interactable = true;
            Btn1.interactable = true;
            Btn2.interactable = true;
            Btn3.interactable = true;
            Btn4.interactable = true;
            Btn5.interactable = true;
            Btn6.interactable = true;
            Btn7.interactable = true;
            Btn8.interactable = true;
            Btn9.interactable = true;  
        }
        txtChucMung.enabled = false;
    }
    public void Submit()
    {
        Ok = true;
        // Nhập code
        code = A * 1000000 + B * 100000 + C * 10000 + D * 1000 + E * 100 + F * 10 + G;
        if(i >= 7 || i == 0)
        {
            if (code == Nop20kGold)
            {
                PlayerPrefs.SetInt("goldT", PlayerPrefs.GetInt("goldT") + 20000);
                txtChucMung.text = "You are added 20000 Gold !" + ToString();
                txtChucMung.enabled = true;
            }
            else if (code == Nop50kGold)
            {
                PlayerPrefs.SetInt("goldT", PlayerPrefs.GetInt("goldT") + 50000);
                txtChucMung.text = "You are added 50000 Gold !" + ToString();
                txtChucMung.enabled = true;
            }
            else if (code != Nop20kGold && code != Nop50kGold)
            {
                txtChucMung.text = "Incorrect ! Please try again !" + ToString();
                txtChucMung.enabled = true;
            }
        }    
        
        else if(i < 7)
        {
            txtChucMung.text = "Incorrect ! Please try again !" + ToString();
            txtChucMung.enabled = true;
        }    
    }    
}
