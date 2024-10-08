using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OldGameController : MonoBehaviour
{
    public GameObject pnlPausePanel;
    public GameObject pnlEndGame;
    public GameObject pnlGameOver;
    public GameObject pnlSetting;
    public GameObject imgCompletedBoss;
    GameObject pLayer;

    int gameLife = 4;
    //int book = 0;
    public int gold;
    public int dimond;
    public int i = 0;
    public int Gb, DmC; //ko xóa mặc dù ko ảnh hưởng
    public bool setText;

    public Button btnRestart;
    public Button btnReseum;
    public Button btnMenu;
    public Button btnPause;
    public Button btnHoiSinh;
    public Button btnCGOver;
    public Button btnSetting;
    public Button btnOnMusic;
    public Button btnRestartBoss;

    public Slider slSoundBG;

    public Text txtGold;
    public Text txtDimond;
   // public Text txtBook;
    public Text txtMang;
    public Text txtPresentStart;

    public GameObject imgPresentJump;
    public GameObject imgPresentAtStar;
    public GameObject imgPresentKN1;
    public GameObject imgPresentHide;

    public Sprite btnON;
    public Sprite btnOff;
    public Sprite PresentJump;
    public Sprite PresentAtStar;
    public Sprite PresentKN1;
    public Sprite PresentHide;

    public AudioClip Click;
    private AudioSource audi;
    public void Start()
    {
        if (pnlPausePanel == null)
        {
            pnlPausePanel = GameObject.FindGameObjectWithTag("pnlPausePanel");
        }
        Time.timeScale = 1f;
        pnlPausePanel.SetActive(false);
        pnlEndGame.SetActive(false);
        pnlGameOver.SetActive(false);
        pnlSetting.SetActive(false);
   
        if (PlayerPrefs.GetInt("i") == 18)
        {
            imgCompletedBoss.SetActive(false);
        }
        if(PlayerPrefs.GetInt("i") != 18)
        {
            imgCompletedBoss = null;
        }    
        if (pLayer == null)
        {
            pLayer = GameObject.FindGameObjectWithTag("Player");
        }
        if (pnlEndGame == null)
        {
            pnlPausePanel = GameObject.FindGameObjectWithTag("pnlEndGame");
        }
        // Điểm số vàng và dimond
        gold = PlayerPrefs.GetInt("goldT", 0);
        PlayerPrefs.SetInt("goldT", gold);
        dimond = PlayerPrefs.GetInt("dimondT", 0);
        PlayerPrefs.SetInt("dimondT", dimond);
        txtGold.text = " " + PlayerPrefs.GetInt("goldT").ToString();
        txtDimond.text = " " + PlayerPrefs.GetInt("dimondT").ToString();
       // Dùng cho text bay lên
        Gb = PlayerPrefs.GetInt("Gb", 10);
        PlayerPrefs.SetInt("Gb", Gb);
        DmC = PlayerPrefs.GetInt("DmC", 1);
        PlayerPrefs.SetInt("DmC", DmC);

        if (PlayerPrefs.GetInt("i") == 2)
        {
            txtPresentStart.text = "In order to save the people from the epidemic, Akachi set off to the North to find the herb. Akachi's journey begins.…" .ToString();
            setText = false;
            StartCoroutine(ProcessLv1TextSart());
        }    
        if(PlayerPrefs.GetInt("i") !=2 )
        {
            txtPresentStart = null;
        }    
        audi = GetComponent<AudioSource>();
        audi.clip = Click;
    }
    public IEnumerator ProcessLv1TextSart()
    {
        yield return new WaitForSeconds(9f);
        txtPresentStart.enabled = false;
        setText = true;
    }    
    void Update()
    {
        if(i==2)
        {
            i = 0;
        }
        if (PlayerPrefs.GetFloat("musicBG") == 0)
        {
            btnOnMusic.GetComponent<Image>().sprite = btnOff;
        } 
        else if(PlayerPrefs.GetFloat("musicBG") == 1)
        {
            btnOnMusic.GetComponent<Image>().sprite = btnON;
        }
        if (PlayerPrefs.GetFloat("musicBG") == 0)
        {
            i = 1;
        }
        slSoundBG.value = PlayerPrefs.GetFloat("musicBG");

    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pnlPausePanel.SetActive(true);
        if (PlayerPrefs.GetInt("i") == 2)
        {
            txtPresentStart.enabled = false;
        }
        else if(PlayerPrefs.GetInt("i") != 2)
        {
            txtPresentStart = null;
        }
        pnlEndGame.SetActive(false);
        pnlGameOver.SetActive(false);
        pnlSetting.SetActive(false);
        audi.Play();
    }    
    public void ReseumGame()
    {

        Time.timeScale = 1f;
        if (PlayerPrefs.GetInt("i") == 2)
        {
            if(setText == false)
            {
                txtPresentStart.enabled = true;
            }    

        }
        else if (PlayerPrefs.GetInt("i") != 2)
        {
            txtPresentStart = null;
        }
        pnlPausePanel.SetActive(false);
        pnlSetting.SetActive(false);
        audi.Play();
    }    
    public void Restart()
    {
        Time.timeScale = 1f;
        audi.Play();
        StartCoroutine(RStartSound());
        Debug.Log("Restart activity");
    }

    public IEnumerator RStartSound()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(PlayerPrefs.GetInt("i"));
    }
    public void Settings()
    {   
        pnlSetting.SetActive(true);
        pnlPausePanel.SetActive(false);
        audi.Play();
    }
    public void ChangeVolume()
    { 
        PlayerPrefs.SetFloat("musicBG", slSoundBG.value);
    }
    public void OffMusic()
    {
        i++;
        if (i == 1)
        {
            btnOnMusic.GetComponent<Image>().sprite= btnOff ;
            PlayerPrefs.SetFloat("musicBG", 0);
            slSoundBG.value = PlayerPrefs.GetFloat("musicBG");

        }
        else if (i == 2)
        {
            btnOnMusic.GetComponent<Image>().sprite = btnON;
            PlayerPrefs.SetFloat("musicBG", 1);
            slSoundBG.value = PlayerPrefs.GetFloat("musicBG"); ;
        }
         
        audi.Play(); 
    }
    public void HoiSinh()
    {  
        if(PlayerPrefs.GetInt("i") != 18 )
        {
            if (PlayerPrefs.GetInt("goldT") >= 3000)
            {
                pLayer.GetComponent<Player>().Life = 4;
                Time.timeScale = 1f;
                pnlEndGame.SetActive(false);
                pnlPausePanel.SetActive(false);
                gameLife = 4;
                txtMang.text = "X " + gameLife.ToString();
                gold = gold - 3000;
                PlayerPrefs.SetInt("goldT", gold);
                txtGold.text = " " + PlayerPrefs.GetInt("goldT").ToString();
                audi.Play();
            }
        }    
        else if(PlayerPrefs.GetInt("i") == 18)
        {
            if (PlayerPrefs.GetInt("goldT") >= 30000)
            {
                pLayer.GetComponent<Player>().Life = 4;
                Time.timeScale = 1f;
                pnlEndGame.SetActive(false);
                pnlPausePanel.SetActive(false);
                gameLife = 4;
                txtMang.text = "X " + gameLife.ToString();
                gold = gold - 30000;
                PlayerPrefs.SetInt("goldT", gold);
                txtGold.text = " " + PlayerPrefs.GetInt("goldT").ToString();
                audi.Play();
            }
        }         
    }
    public void AddGoldQc()
    {
        gold = gold + 3000;
        PlayerPrefs.SetInt("goldT", gold);
    }
    public void NoMoney()
    {
        pnlGameOver.SetActive(true);
        pnlPausePanel.SetActive(false);
        pnlEndGame.SetActive(false);
    }
    public void GetPoint()
    {
        
        gameLife = gameLife - 1;
        txtMang.text = "X " + gameLife.ToString();
        if (gameLife == 0)
        {
            Time.timeScale = 0f;
            pnlEndGame.SetActive(true);
            pnlPausePanel.SetActive(false);
            pnlGameOver.SetActive(false);
        }
    }    
 // Item Drop Add
    public void AddWB()
    {
        
        gold = gold + PlayerPrefs.GetInt("Gb");
        PlayerPrefs.SetInt("goldT", gold);
        txtGold.text = " " + PlayerPrefs.GetInt("goldT").ToString();
    } 
 
    public void AddDMWBox()
    {
        dimond = dimond + PlayerPrefs.GetInt("DmC"); 
        PlayerPrefs.SetInt("dimondT", dimond);
        txtDimond.text = " " + PlayerPrefs.GetInt("dimondT").ToString();
    }
    //public void AddB()
    //{
    //    book = book + 1;
    //    PlayerPrefs.GetInt("bookT", 0);
    //    PlayerPrefs.SetInt("bookT", PlayerPrefs.GetInt("bookT")+book);
    //    txtBook.text = "x " + book.ToString();
    //}         
    public void Menu()
    {
        Time.timeScale = 1f;
        audi.Play();
        StartCoroutine(MenuSound());

    }
    public void BossLv15Completed()
    {
        imgCompletedBoss.SetActive(true);
    }    
    public IEnumerator MenuSound()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(1);
    }
    public void  ProcessStartGameJump()
    {
         StartCoroutine(SetTextAndImageJump());
    }    
    public IEnumerator SetTextAndImageJump()
    {
        txtPresentStart.text = "You can double Jump".ToString();
        imgPresentJump.SetActive(true);
        imgPresentJump.GetComponent<Image>().enabled = true;
        txtPresentStart.enabled = true;
        imgPresentJump.GetComponent<Image>().sprite = PresentJump;
        yield return new WaitForSeconds(5);
        txtPresentStart.text = "".ToString();
        txtPresentStart.enabled = false;
        imgPresentJump.SetActive(false);
    }    
    public void ProcessStartGameAtStar()
    {
        StartCoroutine(SetTextAndImageAtStar());
    }
    public IEnumerator SetTextAndImageAtStar()
    {
        txtPresentStart.enabled = true;
        txtPresentStart.text = "Use shurikens to attack enemies".ToString();
        imgPresentAtStar.SetActive(true);
        imgPresentAtStar.GetComponent<Image>().enabled = true;
        imgPresentAtStar.GetComponent<Image>().sprite = PresentAtStar;

        yield return new WaitForSeconds(7);
        txtPresentStart.text = "".ToString();
        imgPresentAtStar.SetActive(false);
        txtPresentStart.enabled = false;
    }
    public void ProcessStartGameKN1()
    {
        StartCoroutine(SetTextAndImageKN1());
    }   
    public IEnumerator SetTextAndImageKN1()
    {
        txtPresentStart.enabled = true;
        txtPresentStart.text = "Create energy and instantly kill them ".ToString();
        imgPresentKN1.GetComponent<Image>().enabled = true;
        imgPresentKN1.GetComponent<Image>().sprite = PresentKN1;

        yield return new WaitForSeconds(6);
        txtPresentStart.enabled = false;
        txtPresentStart.text = "".ToString();
        imgPresentKN1.SetActive(false);
    }
    public void ProcessStartGameHide()
    {
        StartCoroutine(SetTextAndImageHide());
    }
    public IEnumerator SetTextAndImageHide()
    {
        txtPresentStart.enabled = true;
        txtPresentStart.text = "Just one touch of the button, you can hide yourself and enemies can't kill you .You can double tap the button to return to the old state".ToString();
        imgPresentHide.GetComponent<Image>().enabled = true;
        imgPresentHide.GetComponent<Image>().sprite = PresentHide;

        yield return new WaitForSeconds(7);
        txtPresentStart.enabled = false;
        txtPresentStart.text = "".ToString();
        imgPresentHide.SetActive(false);
    }

    public void ProcessStartGameStoneHide()
    {
        StartCoroutine(SetTextAndImageStoneHide());
    }
    public IEnumerator SetTextAndImageStoneHide()
    {
        txtPresentStart.enabled = true;
        txtPresentStart.text = "Vaults are marked with a dagger on the door. Break into vaults to collect unexpected items".ToString();
        imgPresentKN1.GetComponent<Image>().enabled = true;
        imgPresentKN1.SetActive(true);
        imgPresentKN1.GetComponent<Image>().sprite = PresentKN1;
        imgPresentAtStar.GetComponent<Image>().enabled = true;
        imgPresentAtStar.SetActive(true);
        imgPresentAtStar.GetComponent<Image>().sprite = PresentAtStar;

        yield return new WaitForSeconds(6);
        txtPresentStart.enabled = false;
        txtPresentStart.text = "".ToString();
        imgPresentKN1.SetActive(false);
        imgPresentAtStar.SetActive(false);
    }

    public void ProcessStartAttackBox()
    {
        StartCoroutine(SetTextAttackBox());
    }
    public IEnumerator SetTextAttackBox()
    {
        txtPresentStart.enabled = true;
        txtPresentStart.text = "Attack Box".ToString();
      
        yield return new WaitForSeconds(5);
        txtPresentStart.enabled = false;
        txtPresentStart.text = "".ToString();
    }

}
