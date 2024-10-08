using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveForce;
    private float jumpForce;
    public int i = 0;
    public int k = 0;
    float maxVelocity = 25f;
    public float Life = 4f;
    private float RayPositionOffSet;
    private float GroundBelowOffSet;
    private float GroundSideOffSet;
    private float RayLength;
    private float RayLengthGround;
    private float WallSlideSpeed;
    private float WallSlideSpeedOn;

    private Rigidbody2D myBody;
    private Animator anim;
    public bool moveLeft, moveRight;
    public bool CanMoveSky;
    public bool Star;
    public bool AttackCheck;
    private bool LockAutoRunStart;
    public bool OutdoorLv18;
    public bool LockAutoRunOutdoor;
    //dành riêng cho Boss
    public bool AllowDie;

    public GameObject St;
    public GameObject Giao;
    public GameObject gredDrop;
    public GameObject tru1, tru2, tru3, tru4, tru5;
    public GameObject sTone1, sTone2, sTone3, roadSky;
    public GameObject aTtack, aTtackS, hide, Jump;
    public GameObject gameController;
    public GameObject Left, Right;
    GameObject banDit1, banDit3, banDit2;
    public GameObject inStrument, inStrument1, inStrument2;
    public GameObject slTime;
    public GameObject vcThuongDrop;
    GameObject obj;
    public GameObject stoneMoveSky;
    public GameObject stoneHidden;
    public GameObject Boom;
    public GameObject tranferTurn2b;
    public GameObject smallStoneDrop;
    public GameObject VCPresentJump;
    public GameObject VCPresentAtStar;
    public GameObject VCPresentKN1;
    public GameObject VCPresentHide;
    public GameObject VCPresentStoneHide;
    public GameObject VCPresentBox;
    public GameObject MuitenStoneHide;
    public GameObject Door;
    public GameObject Bossct;
    public GameObject SetAllow;
    public GameObject Muiten5;
    public GameObject GoogleAds;
    public GameObject CamPortail;

    public AudioClip StartClip, HideClip, Jump1Clip, Jump2Clip, RunClip, DiedClip, Kn1Clip, SetClip, Portial;
    public AudioSource audi;

    public bool isDied;
    public bool Idle;
    public bool isGrounded;
    public bool isJump;
    public bool isHided;
    public bool OnWallRight;
    public bool OnWallLeft;
    public bool OnTopGround;
    public bool isGroundLeft;
    public bool isGroundCenter;
    public bool isGroundRight;
    public bool isController;
    public bool Portail;
    public bool VCSeePortail;
    public bool TN;

    private Vector3 truPosition1;
    private Vector3 truPosition2;
    private Vector3 truPosition3;
    private Vector3 truPosition4;
    public Vector3 truPosition5;
    public Vector3 currentLocation;
    public Vector3 oldLocation;
    private Vector3 ThuongDropPositon, ThuongDropPositonLv6, ThuongDropPositonLv9, ThuongDropPositonLv10, ThuongDropPositonLv12, ThuongDropPositonLv14, ThuongDropPositonLv15;
    Vector3 WallRayPositionLeft;
    Vector3 WallRayPositionRight;
    Vector3 WallRayPositionHead;
    Vector3 GroundBelowLeft;
    Vector3 GroundBelowCenter;
    Vector3 GroundBelowRight;

    RaycastHit2D[] WallHitsLeft;
    RaycastHit2D[] WallHitsRight;
    RaycastHit2D[] WallHead;
    RaycastHit2D[] GroundLeft;
    RaycastHit2D[] GroundCenter;
    RaycastHit2D[] GroundRight;

    // Start is called before the first frame update
    void Awake()
    {
        obj = gameObject;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
        audi.clip = null;
        audi.Play();
        if (gameObject.transform.position.x >= -8)
        {
            Idle = true;
        }
        isJump = false;
        Idle = true;
        Portail = false;
        VCSeePortail = false;
        if (PlayerPrefs.GetInt("i") == 13)
        {
            oldLocation = smallStoneDrop.GetComponent<StoneRoiUp>().gameObject.transform.position;
            for (int i = 1; i <= 14; i++)
            {
                Instantiate(smallStoneDrop, new Vector3(oldLocation.x + i, oldLocation.y, 0), new Quaternion(0, 0, 0, 0));
            }
        }

        LockAutoRunStart = false;
        if (PlayerPrefs.GetInt("SetStart") == 1)
        {
            Destroy(VCPresentJump);
            Destroy(VCPresentHide);
            Destroy(VCPresentAtStar);
            Destroy(VCPresentKN1);
            Destroy(VCPresentStoneHide);
            Destroy(VCPresentBox);
        }
        if (PlayerPrefs.GetInt("i") != 18)
        {
            Door = null;
        }
        OutdoorLv18 = false;
        TN = false;
    }
    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
        Idle = false;
    }
    public void StopMoving()
    {
        this.moveLeft = false;
        this.moveRight = false;
        Idle = true;
    }
    void Start()
    {
        if (banDit1 == null)
        {
            banDit1 = GameObject.FindGameObjectWithTag("Enemy1");
        }
        if (banDit2 == null)
        {
            banDit2 = GameObject.FindGameObjectWithTag("Enemy2");
        }
        if (banDit3 == null)
        {
            banDit3 = GameObject.FindGameObjectWithTag("Enemy3");
        }
        truPosition1 = tru1.transform.position; //new Vector3(74.5f, 5, 0);
        truPosition2 = tru2.transform.position; //new Vector3(117, 5, 0);
        truPosition3 = tru3.transform.position; //new Vector3(243, 4, 0);
        truPosition4 = tru4.transform.position;
        if (PlayerPrefs.GetInt("i") >= 10)
        {
            truPosition5 = tru5.transform.position;
        }
        ThuongDropPositon = new Vector3(79, 8, 0);
        ThuongDropPositonLv6 = new Vector3(237, 4, 0);
        ThuongDropPositonLv9 = new Vector3(508, 6, 0);
        ThuongDropPositonLv10 = new Vector3(110, 8, 0);
        ThuongDropPositonLv12 = new Vector3(141, 8.7f, 0);
        ThuongDropPositonLv14 = new Vector3(81, 7.5f, 0);
        ThuongDropPositonLv15 = new Vector3(400, 10f, 0);
        isDied = false;
        Star = false;
        AttackCheck = false;
        isHided = false;
        float x = 0;
        if (PlayerPrefs.GetInt("i") == 2)
        {
            x = 11f;
            // các button vô hiệu hóa trong 9s đầu
            Left.GetComponent<ButtonL>().BeetweenStartRunLv1();
            Right.GetComponent<ButtonR>().BeetweenStartRunLv1();
            Jump.GetComponent<Jump>().BeetweenStartRunLv1();
            aTtack.GetComponent<Attack>().BeetweenStartRunLv1();
            aTtackS.GetComponent<AttackS>().BeetweenStartRunLv1();
            hide.GetComponent<Hide>().BeetweenStartRunLv1();
        }
        else if (PlayerPrefs.GetInt("i") != 2 && PlayerPrefs.GetInt("i") != 18)
        {
            x = 7f;
            Right.GetComponent<ButtonR>().BetweenR();
            Left.GetComponent<ButtonL>().BetweenL();
            Jump.GetComponent<Jump>().BetweenJ();
            aTtack.GetComponent<Attack>().BetweenA();
            aTtackS.GetComponent<AttackS>().BetweenS();
            hide.GetComponent<Hide>().BetweenH2();
        }
        if (PlayerPrefs.GetInt("i") == 18)
        {
            x = 3;
            Right.GetComponent<ButtonR>().BetweenR();
            Left.GetComponent<ButtonL>().BetweenL();
            Jump.GetComponent<Jump>().BetweenJ();
            aTtack.GetComponent<Attack>().BetweenA();
            aTtackS.GetComponent<AttackS>().BetweenS();
            hide.GetComponent<Hide>().BetweenH2();
        }
        StartCoroutine(SetLockAutoRunStart(x));

        // Bắt thông số ngay từ đầu tránh việc phải public cho từng sence
        RayPositionOffSet = 0.15f;
        RayLength = 0.35f;
        WallSlideSpeed = 30;
        WallSlideSpeedOn = 30;
        moveForce = 450;
        jumpForce = 17;
        GroundBelowOffSet = 0.7f;
        GroundSideOffSet = 0.32f;
        RayLengthGround = 0.15f;
        //Dành riêng cho Boss
        AllowDie = false;
    }
    public IEnumerator SetLockAutoRunStart(float x)
    {
        yield return new WaitForSeconds(x);
        LockAutoRunStart = true;

    }
    public void Update()
    {
        currentLocation = obj.transform.position;
        //Điều hướng phi tiêu
        if (CanMoveSky == false)
        {
            if (transform.localScale.x == 1)
            {
                St.GetComponent<NJst>().Right = true;
            }
            if (transform.localScale.x == -1)
            {
                St.GetComponent<NJst>().Right = false;
            }
        }
        else if (CanMoveSky == true)                                  // Trường hợp này do OnWall ngược hướng vs Star, ko dc đổi lại 
        {
            if (transform.localScale.x == -1)
            {
                St.GetComponent<NJst>().Right = true;
            }
            if (transform.localScale.x == 1)
            {
                St.GetComponent<NJst>().Right = false;
            }
        }
        //Set lại giá trị i lúc Jump
        if (i == 2)
        {
            StartCoroutine(Seti());
        }
        if (k == 2)
        {
            StartCoroutine(Setk());
        }
        //Âm thanh lúc nhảy
        if (isGrounded == false && isHided == false)
        {
            if (i == 1)
            {
                audi.clip = Jump1Clip;
                audi.Play();
            }
            else if (i == 2)
            {
                audi.clip = Jump2Clip;
                audi.Play();
            }
        }

        // 
        if (gameObject.transform.position.x < -8f && LockAutoRunStart == false || VCSeePortail == true)
        {
            SetMoveLeft(false);
        }
        else if (gameObject.transform.position.x >= -8f && LockAutoRunStart == false)
        {
            if (isController == false)
            {
                StopMoving();
            }
        }
        if (PlayerPrefs.GetInt("i") == 18)
        {
            if (LockAutoRunStart == true)
            {
                StartCoroutine(SetLookOutDoorLv18());
                StartCoroutine(SetOutDoor());
            }
        }

        if (Idle == false && isGrounded == true && isJump == false && isHided == false && Portail == false && LockAutoRunStart == true)
        {
            audi.clip = RunClip;
            audi.Play();
        }

        OnWall();

        CheckCanMove();
        if (CanMoveSky == true)
        {
            WallSlideSpeedOn = 30;
        }
        else if (CanMoveSky == false)
        {
            WallSlideSpeedOn = 0;
        }
        if (isGrounded == true)
        {
            Jump.GetComponent<Jump>().Ablebtn();
        }

        if (CanMoveSky == true)
        {
            if (moveLeft && OnWallLeft == true || moveRight && OnWallRight == true)
            {
                myBody.velocity = new Vector3(0, 0, 0);
            }
            else
            {
                PlayerRunJoyStick();
            }
        }
        //else if (CanMoveSky == false)
        //{
        //    if (isHided == true)
        //    {
        //        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //    }
        //    else if (isHided == false)
        //    {
        //        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //        PlayerRunJoyStick();
        //    }

        //}
        if (i == 1)
        {
            isHided = true;
        }
        else if (i == 2)
        {
            isHided = false;
        }
        if (OnTopGround == true)
        {
            if (isJump == true)
            {
                myBody.velocity = new Vector3(0, -1, 0);
            }
        }

        if (CanMoveSky == true)
        {
            Jump.GetComponent<Jump>().Ablebtn();
        }
        if (isGrounded == true && k == 1 && isJump == false)
        {
            k = 0;
        }
    }
    public IEnumerator Seti()
    {
        yield return new WaitForSeconds(0.01f);
        i = 0;
    }
    public IEnumerator Setk()
    {
        yield return new WaitForSeconds(0.0001f);
        k = 0;
    }
    public IEnumerator SetOutDoor()
    {
        yield return new WaitForSeconds(0.01f);
        if (LockAutoRunOutdoor == true)
        {
            if (PlayerPrefs.GetInt("i") == 18)
            {
                if (OutdoorLv18 == true)
                {
                    if (gameObject.transform.position.x < 5.7f)
                    {
                        SetMoveLeft(false);
                    }
                }
                else if (OutdoorLv18 == false)
                {
                    if (isController == false)
                    {
                        StopMoving();
                    }
                }
            }
        }

    }
    public void CheckCanMove()
    {
        if (isGrounded == false)
        {
            if (OnWallLeft == true || OnWallRight == true)
            {
                if (TN == false)
                {
                    CanMoveSky = true;
                }
            }
            else if (OnWallLeft == false && OnWallRight == false)
            {
                CanMoveSky = false;
            }
            if (OnWallRight == true)
            {
                this.moveRight = false;
            }
            if (OnWallLeft == true)
            {
                this.moveLeft = false;
            }

        }
        else if (isGrounded == true)
        {
            CanMoveSky = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerRunJoyStick();

        if (isGrounded == true)
        {
            if (moveLeft == false && moveRight == false && isJump == false && OnWallLeft == false && OnWallRight == false)
            {
                obj.GetComponent<Rigidbody2D>().gravityScale = 10;
            }
            else if (moveLeft == true && isJump == false || moveRight == true && isJump == false)
            {
                obj.GetComponent<Rigidbody2D>().gravityScale = 3;
            }
        }
        if (isGrounded == true)
        {
            isJump = false;
        }
        else if (isGrounded == false)
        {
            isJump = true;
        }
        RaySetUp();

    }
    public void RaySetUp()
    {
        // Check Wallleft or Right
        WallRayPositionLeft = obj.transform.position + new Vector3(-RayPositionOffSet, 0.2f, 0);
        WallRayPositionRight = obj.transform.position + new Vector3(RayPositionOffSet, 0.2f, 0);
        // Check đầu khi nhảy mà dính tường
        WallRayPositionHead = obj.transform.position + new Vector3(0, 2.5f * RayPositionOffSet, 0);
        //Check isGrounded
        GroundBelowLeft = obj.transform.position + new Vector3(-GroundSideOffSet, -GroundBelowOffSet, 0);
        GroundBelowCenter = obj.transform.position + new Vector3(0, -GroundBelowOffSet, 0);
        GroundBelowRight = obj.transform.position + new Vector3(GroundSideOffSet, -GroundBelowOffSet, 0);

        WallHitsLeft = Physics2D.RaycastAll(WallRayPositionLeft, Vector2.left, RayLength);
        WallHitsRight = Physics2D.RaycastAll(WallRayPositionRight, -Vector2.left, RayLength);
        WallHead = Physics2D.RaycastAll(WallRayPositionHead, Vector2.up, RayLength);
        //RayCast CheckGround
        GroundLeft = Physics2D.RaycastAll(GroundBelowLeft, Vector2.down, RayLengthGround);    // Trường hợp này là lúc RayLength = 0.35f. Bếu điều chỉnh Ray Length thì điều chỉnh lại sao cho =
        GroundCenter = Physics2D.RaycastAll(GroundBelowCenter, Vector2.down, RayLengthGround);
        GroundRight = Physics2D.RaycastAll(GroundBelowRight, Vector2.down, RayLengthGround);

        OnWallLeft = RayCheck(WallHitsLeft);
        OnWallRight = RayCheck(WallHitsRight);
        OnTopGround = RayCheck(WallHead);

        // Việc chia ra thế này giúp khi 1 trong 3 cái vẫn chạm đất thì vẫn tính, đã thứ nghiệm nếu gộp chung nó false;
        isGroundLeft = RayCheckGround(GroundLeft);
        isGroundCenter = RayCheckGround(GroundCenter);
        isGroundRight = RayCheckGround(GroundRight);

        if (isGroundLeft == true || isGroundCenter == true || isGroundRight == true)
        {
            isGrounded = true;
        }
        else if (isGroundLeft == false && isGroundCenter == false && isGroundRight == false)
        {
            isGrounded = false;
        }
        DrawRays();
    }
    public bool RayCheck(RaycastHit2D[] RayHits)
    {
        foreach (RaycastHit2D hit in RayHits)
        {
            if (hit.collider != null)
            {
                if (hit.collider.tag != "Player")
                {
                    if (hit.collider.tag == "Ground" || hit.collider.tag == "GroundThanh")  // là cái thanh di chuyển lên xuống với đỗ xaoy khác nhau
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    public bool RayCheckGround(RaycastHit2D[] RayHits2)
    {
        foreach (RaycastHit2D hit2 in RayHits2)
        {
            if (hit2.collider.tag != null)
            {
                if (hit2.collider.tag != "Player")
                {
                    if (hit2.collider.tag == "Ground" || hit2.collider.tag == "GroundThanh" || hit2.collider.tag == "GroundStoneSky" || hit2.collider.tag == "StoneRoadMove" || hit2.collider.tag == "StoneSkyDrop")
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void DrawRays()
    {
        // Vẽ ra khi leo tường
        Debug.DrawRay(WallRayPositionLeft, Vector2.left * RayLength, Color.blue);
        Debug.DrawRay(WallRayPositionRight, -Vector2.left * RayLength, Color.blue);
        Debug.DrawRay(WallRayPositionHead, Vector2.up * RayLength, Color.yellow);
        //Vẽ ra khi ở dưới đất
        Debug.DrawRay(GroundBelowLeft, Vector2.down * RayLengthGround, Color.red);
        Debug.DrawRay(GroundBelowCenter, Vector2.down * RayLengthGround, Color.red);
        Debug.DrawRay(GroundBelowRight, Vector2.down * RayLengthGround, Color.red);
    }

    void PlayerRunJoyStick()
    {
        float ForceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        if (Idle == false && isDied == false && Jump == false && Portail == false)
        {
            audi.clip = RunClip;
            audi.Play();
            //audi.loop = true;
        }
        else if (Idle == true && isDied == false && Jump == false)
        {
            audi.loop = false;
        }

        if (Idle == false && isDied == false)
        {
            if (moveLeft)
            {
                if (vel < maxVelocity)
                {
                    if (isGrounded == true || isGrounded == false && CanMoveSky == false)
                    {
                        ForceX = -moveForce;
                    }
                    else if (isGrounded == false && CanMoveSky == true)
                    {
                        ForceX = -moveForce * 0.1f;

                    }
                    myBody.velocity = new Vector2(ForceX * Time.fixedDeltaTime, myBody.velocity.y);
                    Vector3 scale = transform.localScale;
                    scale.x = -1f;
                    transform.localScale = scale;
                    anim.SetBool("Run", true);
                    myBody.bodyType = RigidbodyType2D.Dynamic;
                }
            }
            else if (moveRight)
            {
                if (vel < maxVelocity)
                {
                    if (isGrounded == true || isGrounded == false && CanMoveSky == false)
                    {
                        ForceX = moveForce;
                    }
                    else if (isGrounded == false && CanMoveSky == true)
                    {
                        ForceX = moveForce * 0.1f;

                    }
                    myBody.velocity = new Vector2(ForceX * Time.fixedDeltaTime, myBody.velocity.y);
                    Vector3 scale = transform.localScale;
                    scale.x = 1f;
                    transform.localScale = scale;
                    anim.SetBool("Run", true);
                    myBody.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
        else if (Idle == true && Star == false && isDied == false && CanMoveSky == false)
        {
            anim.SetBool("Run", false);
            StopMoving();
        }
        //myBody.AddForce(new Vector2(ForceX, 0));
        myBody.velocity = new Vector2(myBody.velocity.x, myBody.velocity.y);
    }
    public void SetLocation()
    {
        if (Life > 0)
        {
            anim.SetTrigger("Set");
            audi.clip = SetClip;
            audi.Play();
            if (obj.transform.position.x > -10f && obj.transform.position.x <= tru1.transform.position.x)
            {
                obj.transform.position = new Vector3(-7f, 3, 0);
                Time.timeScale = 1f;
            }
            else if (obj.transform.position.x > tru1.transform.position.x && obj.transform.position.x <= tru2.transform.position.x)
            {
                obj.transform.position = truPosition1 + new Vector3(1, 0, 0);
                Time.timeScale = 1f;
            }
            else if (obj.transform.position.x > tru2.transform.position.x && obj.transform.position.x <= tru3.transform.position.x)
            {
                obj.transform.position = truPosition2 + new Vector3(1, 0, 0);
                Time.timeScale = 1f;

            }
            else if (obj.transform.position.x > tru3.transform.position.x && obj.transform.position.x <= tru4.transform.position.x)
            {
                obj.transform.position = truPosition3 + new Vector3(1, 0, 0);
                Time.timeScale = 1f;

            }
            else if (PlayerPrefs.GetInt("i") != 10 && PlayerPrefs.GetInt("i") != 13 && PlayerPrefs.GetInt("i") != 14)
            {
                if (obj.transform.position.x > tru4.transform.position.x)
                {
                    obj.transform.position = truPosition4;
                    Time.timeScale = 1f;
                }
            }
            else if (PlayerPrefs.GetInt("i") == 10 || PlayerPrefs.GetInt("i") == 13 || PlayerPrefs.GetInt("i") == 14)
            {
                if (obj.transform.position.x > tru4.transform.position.x && obj.transform.position.x < tru5.transform.position.x)
                {
                    obj.transform.position = truPosition4 + new Vector3(1, 0, 0);
                    Time.timeScale = 1f;
                }
                else if (obj.transform.position.x > tru5.transform.position.x)
                {
                    obj.transform.position = truPosition5 + new Vector3(1, 0, 0);
                    Time.timeScale = 1f;
                }
            }
            StartCoroutine(Died());
            Activebtn();
            GetComponent<Collider2D>().enabled = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
            StartCoroutine(NotRunSetLocation());
        }

    }
    public IEnumerator NotRunSetLocation()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("Run", false);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(Die2());
        }

        if (collision.gameObject.tag == "CNhon")
        {
            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "CNhonLv18")
        {
            StartCoroutine(Die2());
            AllowDie = true;
        }
        if (collision.gameObject.tag == "StoneBoss")
        {
            AllowDie = true;
            StartCoroutine(Die2());
        }

        if (collision.gameObject.tag == "Fire")
        {
            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "ChemSky")
        {
            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "Boom")
        {
            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "Enemy1")
        {

            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "Enemy2")
        {

            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "Enemy3")
        {

            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "StoneRoi1")
        {

            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "StoneRoi2")
        {
            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "StoneRoi3")
        {

            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "NuiLua")
        {

            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "BanXoay1")
        {

            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "dmWBox")
        {
            gameController.GetComponent<OldGameController>().AddDMWBox();
        }
        //if (collision.gameObject.tag == "GroundThanh")
        //{
        //    RayLength = 0.5f;
        //}
        if (collision.gameObject.tag == "GoldBox")
        {
            gameController.GetComponent<OldGameController>().AddWB();
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "Fire")
        {
            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "ChemSky")
        {
            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "Boom")
        {
            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "Enemy1")
        {

            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "Enemy2")
        {

            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "Enemy3")
        {

            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "StoneRoi1")
        {

            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "StoneRoi2")
        {
            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "StoneRoi3")
        {

            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "NuiLua")
        {

            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "BanXoay1")
        {

            StartCoroutine(Die2());
        }
        if (collision.gameObject.tag == "GoldBox")
        {
            gameController.GetComponent<OldGameController>().AddWB();
        }
        if (collision.gameObject.tag == "dmWBox")
        {
            gameController.GetComponent<OldGameController>().AddDMWBox();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Portail")
        {
            Portail = true;
            ProcessSoundPortail();
           // CamPortail.GetComponent<CameraFollow>().touchPortail = true;
            audi.clip = Portial;
            audi.Play();
            if (PlayerPrefs.GetInt("i") != 16)
            {
                if (PlayerPrefs.GetInt("UnLock") <= PlayerPrefs.GetInt("i"))
                {
                    PlayerPrefs.SetInt("UnLock", PlayerPrefs.GetInt("i") + 1);
                    Debug.Log("UnLock bang " + PlayerPrefs.GetFloat("UnLock"));
                }
            }
            else if (PlayerPrefs.GetInt("i") == 16)
            {
                if (PlayerPrefs.GetInt("UnLock") <= PlayerPrefs.GetInt("i"))
                {
                    PlayerPrefs.SetInt("UnLock", PlayerPrefs.GetInt("i") + 2);
                }

            }

        }
        if (collision.tag == "GroundVC")
        {
            sTone1.GetComponent<Stone1>().Anim();
        }
        if (collision.tag == "StoneRoi1")
        {
            sTone2.GetComponent<Stone2>().Anim2();
        }
        if (collision.tag == "StoneRoi2")
        {
            sTone3.GetComponent<Stone3>().Anim3();
        }
        if (collision.tag == "GroundVC2")
        {
            roadSky.GetComponent<RoadSky>().Drop();
        }
        if (collision.tag == "VCGiao")
        {
            Giao.GetComponent<Giao>().TurnOn();
        }
        if (collision.tag == "VCThuongDrop")
        {
            StartCoroutine(ThuongDropTime());
            vcThuongDrop.tag = "Untagged";
        }
        if (collision.tag == "Giao")
        {
            StartCoroutine(Die2());
        }
        //if (collision.tag == "Instrument")
        //{
        //    gameController.GetComponent<GameController>().AddB();
        //    inStrument.GetComponent<File>().Destroy();
        //}
        //if (collision.tag == "Instrument1")
        //{
        //    gameController.GetComponent<GameController>().AddB();
        //    inStrument1.GetComponent<File2>().Destroy1();
        //}
        //if (collision.tag == "Instrument2")
        //{
        //    gameController.GetComponent<GameController>().AddB();
        //    inStrument2.GetComponent<File3>().Destroy2();
        //}
        if (collision.tag == "GoldBox")
        {
            gameController.GetComponent<OldGameController>().AddWB();
        }
        if (collision.tag == "VCStoneMoveSky")
        {
            stoneMoveSky.GetComponent<StoneMoveSky>().SetLocation();
        }
        if (collision.tag == "VC Stone Hidden")
        {
            stoneHidden.GetComponent<StoneHidden>().TransferHidden();
            if (PlayerPrefs.GetInt("i") == 12 && currentLocation.x > 355)
            {
                tranferTurn2b.GetComponent<Collider2D>().isTrigger = true;
                tranferTurn2b.tag = "Turn2";
            }
            if (PlayerPrefs.GetInt("i") == 13 && currentLocation.x > 266)
            {
                tranferTurn2b.GetComponent<Collider2D>().isTrigger = true;
                tranferTurn2b.tag = "Turn2";
            }
            else if (PlayerPrefs.GetInt("i") == 14 && currentLocation.x > 125)
            {
                tranferTurn2b.GetComponent<Collider2D>().isTrigger = true;
                tranferTurn2b.tag = "Turn2";
            }
            else if (PlayerPrefs.GetInt("i") == 15 && currentLocation.x > 220)
            {
                tranferTurn2b.GetComponent<Collider2D>().isTrigger = true;
                tranferTurn2b.tag = "Turn2";
            }
        }
        if (collision.tag == "dmWBox")
        {
            gameController.GetComponent<OldGameController>().AddDMWBox();
        }
        if (collision.tag == "Enemy")
        {
            StartCoroutine(Die2());
        }
        if (collision.tag == "WeaponB")
        {
            StartCoroutine(Die2());
        }
        if (collision.tag == "VCPresentJump")
        {
            gameController.GetComponent<OldGameController>().ProcessStartGameJump();
            StartCoroutine(ProcessVCPresentJump());
        }
        if (collision.tag == "VCPresentAtStar")
        {
            gameController.GetComponent<OldGameController>().ProcessStartGameAtStar();
            StartCoroutine(ProcessVCPresentAtStar());
        }
        if (collision.tag == "VCPresentKN1")
        {
            gameController.GetComponent<OldGameController>().ProcessStartGameKN1();
            StartCoroutine(ProcessVCPresentKN1());
        }
        if (collision.tag == "VCPresentHide")
        {
            gameController.GetComponent<OldGameController>().ProcessStartGameHide();
            StartCoroutine(ProcessVCPresentHide());

        }
        if (collision.tag == "VCPresentStoneHide")
        {
            gameController.GetComponent<OldGameController>().ProcessStartGameStoneHide();
            StartCoroutine(ProcessVCPresentStoneHide());
            MuitenStoneHide.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (collision.tag == "VCPresentBox")
        {
            StartCoroutine(SetMuiTen5());
            gameController.GetComponent<OldGameController>().ProcessStartAttackBox();
        }
        if (collision.tag == "VCDestroyStart")
        {
            PlayerPrefs.SetInt("SetStart", 1);
            Debug.Log("SetStart" + PlayerPrefs.GetInt("SetStart"));
        }
        if (collision.tag == "StopPortail")
        {
            VCSeePortail = true;
            //Cho 4s ko xài được
            Left.GetComponent<ButtonL>().BetweenL2();
            Right.GetComponent<ButtonR>().BetweenR2();
            Jump.GetComponent<Jump>().BetweenJ2();
            aTtack.GetComponent<Attack>().BetweenA2();
            aTtackS.GetComponent<AttackS>().BetweenS2();
            hide.GetComponent<Hide>().BetweenH3();
        }
        if (collision.tag == "SetAllowMove")
        {
            Door.GetComponent<Door>().moveSpeed = 9;
            StartCoroutine(SetOutDoor());
            StartCoroutine(SetLookOutDoorLv18());
            OutdoorLv18 = true;
        }
        if (collision.tag == "SetAllow")
        {
            Door.GetComponent<Door>().moveSpeed = 9;
            SetAllow.SetActive(false);
            OutdoorLv18 = false;
        }
    }
    public IEnumerator SetMuiTen5()
    {
        Muiten5.SetActive(true);
        yield return new WaitForSeconds(5);
        Muiten5.SetActive(false);
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Portail")
        {
            Portail = true;
        }
        if (collision.tag == "GoldBox")
        {
            gameController.GetComponent<OldGameController>().AddWB();
        }
        if (collision.tag == "dmWBox")
        {
            gameController.GetComponent<OldGameController>().AddDMWBox();
        }
        if (collision.tag == "Enemy")
        {
            StartCoroutine(Die2());
        }
        if (collision.tag == "WeaponB")
        {
            StartCoroutine(Die2());
        }
        if (collision.tag == "SetAllowMove")
        {
            Door.GetComponent<Door>().moveSpeed = 9;
            StartCoroutine(SetOutDoor());
            StartCoroutine(SetLookOutDoorLv18());
            OutdoorLv18 = true;
        }
        if (collision.tag == "SetAllow")
        {
            Door.GetComponent<Door>().moveSpeed = 9;
            SetAllow.SetActive(false);
            OutdoorLv18 = false;
        }
    }
    public void ProcessSoundPortail()
    {
        //GoogleAds.GetComponent<GoogleAds>().RequestInterstitial();      
    }
    public void LoadSceneQcao()
    {
        //Dành cho quảng cáo. Cái này tác ra từ  ProcessSoundPortail() dưới yield return
        SceneManager.LoadScene(17);
    }
    public IEnumerator ProcessVCPresentJump()
    {
        yield return new WaitForSeconds(1f);
        VCPresentJump.SetActive(false);
    }
    public IEnumerator ProcessVCPresentAtStar()
    {
        yield return new WaitForSeconds(1f);
        VCPresentAtStar.SetActive(false);
    }
    public IEnumerator ProcessVCPresentKN1()
    {
        yield return new WaitForSeconds(1f);
        VCPresentKN1.SetActive(false);
    }
    public IEnumerator ProcessVCPresentHide()
    {
        yield return new WaitForSeconds(1f);
        VCPresentHide.SetActive(false);
    }
    public IEnumerator ProcessVCPresentStoneHide()
    {
        yield return new WaitForSeconds(5f);
        VCPresentStoneHide.SetActive(false);
        MuitenStoneHide.SetActive(false);
    }
    public void Attack()
    {

        if (CanMoveSky == false)
        {
            anim.SetTrigger("Attack");
        }
        else if (CanMoveSky == true)
        {
            anim.SetTrigger("AttackOnWall");
            AttackCheck = true;
        }
        aTtack.GetComponent<Attack>().Between();
        audi.clip = Kn1Clip;
        audi.Play();
        float x = 0;
        StartCoroutine(CheckAttack(x));
    }
    private IEnumerator CheckAttack(float x)
    {
        if (isGrounded == true)
        {
            x = 0.1f;
        }
        else if (isGrounded == false)
        {
            x = 1.34f;
        }
        yield return new WaitForSeconds(x);
        AttackCheck = false;

    }
    public void AttackST()
    {
        if (CanMoveSky == false)
        {
            if (Idle == true)
            {
                anim.SetTrigger("AttackS");
            }
            else if (Idle == false)
            {
                anim.SetTrigger("AttackSR");
            }
        }
        else if (CanMoveSky == true)
        {
            anim.SetTrigger("OnWallStar");
            StartCoroutine(SetStar());
        }
        aTtackS.GetComponent<AttackS>().BetweenSt();
        StartCoroutine(Sta());
        audi.clip = StartClip;
        audi.Play();
    }
    public IEnumerator SetStar()
    {
        Star = true;
        yield return new WaitForSeconds(0.05f);
        Star = false;
    }
    public void HideTong()
    {
        if (CanMoveSky == false)
        {
            Hide();
        }
        else if (CanMoveSky == true)
        {
            if (OnWallLeft == true)
            {
                obj.transform.position = new Vector3(obj.transform.position.x + 0.5f, obj.transform.position.y, 0);
            }
            else if (OnWallRight == true)
            {
                obj.transform.position = new Vector3(obj.transform.position.x - 0.5f, obj.transform.position.y, 0);
            }
            anim.SetTrigger("OutWall");
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(MoveBeforeHide());
        }
    }
    public IEnumerator MoveBeforeHide()
    {
        yield return new WaitForSeconds(0.1f);
        Hide();
    }
    public void Hide()
    {
        i++;
        audi.clip = HideClip;
        audi.Play();
        if (i == 1)
        {
            if (isGrounded == true)
            {
                anim.SetTrigger("Hide");
            }
            else if (isGrounded == false)
            {
                anim.SetTrigger("HideA");
            }
            isHided = true;
            slTime.GetComponent<SLTime>().isFirst = true;
            StartCoroutine(HideStone());
        }
        else if (i == 2)
        {
            isHided = false;
            anim.SetTrigger("HIdle");
            slTime.GetComponent<SLTime>().isFirst = false;
            aTtack.GetComponent<Attack>().btnAttack.interactable = true;
            aTtack.GetComponent<Attack>().btnAttack.image.enabled = true;
            aTtackS.GetComponent<AttackS>().btnStart.interactable = true;
            aTtackS.GetComponent<AttackS>().btnStart.image.enabled = true;
            Right.GetComponent<ButtonR>().OnEnableR5();
            Left.GetComponent<ButtonL>().OnEnableL5();
            Jump.GetComponent<Jump>().btnJump.interactable = true;
            Jump.GetComponent<Jump>().btnJump.image.enabled = true;
            obj.tag = "Player";
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Collider2D>().isTrigger = false;
            hide.GetComponent<Hide>().BetweenHH();
        }
    }
    public IEnumerator HideStone()
    {
        obj.tag = "Untagged";
        aTtack.GetComponent<Attack>().BetweenH();
        aTtackS.GetComponent<AttackS>().BetweenHS();
        Jump.GetComponent<Jump>().BetweenHJ();
        Right.GetComponent<ButtonR>().BetweenR5();
        Left.GetComponent<ButtonL>().BetweenL5();
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        StopMoving();
        GetComponent<Collider2D>().isTrigger = true;
        yield return new WaitForSeconds(5);
        isHided = false;
        if (CanMoveSky == false && isHided == false)
        {
            obj.tag = "Player";
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Collider2D>().isTrigger = false;
        }

    }
    public IEnumerator ThuongDropTime()
    {
        for (int j = 0; j <= 6; j++)
        {
            yield return new WaitForSeconds(0.3f);
            if (PlayerPrefs.GetInt("i") == 3 || PlayerPrefs.GetInt("i") == 4 || PlayerPrefs.GetInt("i") == 5)
            {
                Instantiate(gredDrop, ThuongDropPositon, Quaternion.identity);
            }
            if (PlayerPrefs.GetInt("i") == 7)
            {
                Instantiate(gredDrop, ThuongDropPositonLv6, Quaternion.identity);
            }
            else if (PlayerPrefs.GetInt("i") == 10)
            {
                Instantiate(gredDrop, ThuongDropPositonLv9, Quaternion.identity);
            }
            else if (PlayerPrefs.GetInt("i") == 11)
            {
                Instantiate(gredDrop, ThuongDropPositonLv10, Quaternion.identity);
            }
            else if (PlayerPrefs.GetInt("i") == 13)
            {
                Instantiate(gredDrop, ThuongDropPositonLv12, Quaternion.identity);
            }
            else if (PlayerPrefs.GetInt("i") == 15)
            {
                Instantiate(gredDrop, ThuongDropPositonLv14, Quaternion.identity);
            }
            else if (PlayerPrefs.GetInt("i") == 16)
            {
                Instantiate(gredDrop, ThuongDropPositonLv15, Quaternion.identity);
            }
        }
    }
    public IEnumerator Sta()
    {
        yield return new WaitForSeconds(0.1f);
        if (CanMoveSky == false)
        {
            Instantiate(St, transform.position + transform.localScale.x * new Vector3(1, 0, 0), Quaternion.identity);
        }
        else if (CanMoveSky == true)
        {
            Instantiate(St, transform.position + transform.localScale.x * new Vector3(-1, 0, 0), Quaternion.identity);
        }

    }
    public void clJump()
    {
        isJump = true;
        k++;
        if (isGrounded == true)
        {
            if (CanMoveSky == false)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
                obj.GetComponent<Rigidbody2D>().gravityScale = 3;
                k = 1;
                //myBody.AddForce(new Vector2(0, jumpForce));
            }
            else if (CanMoveSky == true)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
            //myBody.velocity = new Vector2(0, jumpForce);
            anim.SetTrigger("Jump");
            isGrounded = false;
            audi.clip = Jump1Clip;
            audi.Play();
        }
        else if (isGrounded == false)
        {
            //myBody.velocity = new Vector2(0, jumpForce);
            if (obj.transform.position.y >= 7.5f)
            {
                if (CanMoveSky == false)
                {
                    Jump.GetComponent<Jump>().DisableButton();
                }
                else if (CanMoveSky == true && OnTopGround == true)
                {
                    Jump.GetComponent<Jump>().OnTopGround();
                }
            }

            if (OnWallLeft == false && OnWallRight == false)
            {
                if (k == 1)
                {
                    myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
                    anim.SetTrigger("Jump");
                }
                else if (k == 2)
                {
                    anim.SetTrigger("Jump2");
                    myBody.velocity = new Vector2(myBody.velocity.x, 1.25f * jumpForce);
                    Jump.GetComponent<Jump>().DisableButton();
                }
            }
            else if (OnWallRight == true && moveLeft == false)
            {
                myBody.velocity = new Vector2(-0.2f * WallSlideSpeed, 0.6f * WallSlideSpeed);
                //myBody.velocity = new Vector2(-0.4f * WallSlideSpeed, 0.15f * WallSlideSpeed);
                anim.SetTrigger("Jump");
                StartCoroutine(CheckCanMoveOutWall());
            }
            else if (OnWallLeft == true && moveRight == false)
            {
                myBody.velocity = new Vector2(0.2f * WallSlideSpeed, 0.6f * WallSlideSpeed);
                //myBody.velocity = new Vector2(0.4f * WallSlideSpeed, 0.15f * WallSlideSpeed);
                anim.SetTrigger("Jump");
                StartCoroutine(CheckCanMoveOutWall());
            }
            audi.clip = Jump2Clip;
            audi.Play();
        }
    }
    public IEnumerator CheckCanMoveOutWall()
    {
        CanMoveSky = false;
        OnWallLeft = false;
        OnWallRight = false;
        TN = true;
        yield return new WaitForSeconds(0.25f);
        TN = false;
        //OnWallLeft = RayCheck(WallHitsLeft);
        //OnWallRight = RayCheck(WallHitsRight);
        if (obj.transform.localScale.x == 1)
        {
            myBody.velocity = new Vector2(0.2f * WallSlideSpeed, 0.35f * WallSlideSpeed);
            //myBody.velocity = new Vector2(0.2f * WallSlideSpeed, 0.6f * WallSlideSpeed);
        }
        else if (obj.transform.localScale.x == -1)
        {
            myBody.velocity = new Vector2(-0.2f * WallSlideSpeed, 0.35f * WallSlideSpeed);
            //myBody.velocity = new Vector2(-0.2f * WallSlideSpeed, 0.6f * WallSlideSpeed);
        }
    }
    public void OnWall()
    {
        if (CanMoveSky == true)
        {
            if (isDied == false && AttackCheck == false)
            {
                if (OnWallLeft)
                {
                    myBody.velocity = new Vector2(0, -2.2f * WallSlideSpeedOn * Time.deltaTime);
                    this.moveLeft = false;
                    Vector3 scale = transform.localScale;
                    scale.x = -1f;
                    transform.localScale = scale;
                }
                else if (OnWallRight)
                {
                    myBody.velocity = new Vector2(0, -2.2f * WallSlideSpeedOn * Time.deltaTime);
                    this.moveRight = false;
                    Vector3 scale = transform.localScale;
                    scale.x = 1f;
                    transform.localScale = scale;
                }
                obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                if (Star == false)
                {
                    anim.SetTrigger("OnWall");
                }
                else if (Star == true)
                {
                    anim.SetTrigger("OnWallStar");
                }
            }

        }
        else if (CanMoveSky == false)
        {
            if (isHided == false && isDied == false && AttackCheck == false)
            {
                if (isGrounded == true || moveLeft == true || moveRight == true || Idle == true)
                {
                    anim.SetTrigger("OutWall");
                    obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
            }

        }
    }
    public IEnumerator Die2()
    {
        if (PlayerPrefs.GetInt("i") != 18)
        {
            audi.clip = DiedClip;
            audi.Play();
            anim.SetTrigger("Died");
            Life = Life - 1;
            gameController.GetComponent<OldGameController>().GetPoint();
            Left.GetComponent<ButtonL>().BetweenL();
            Right.GetComponent<ButtonR>().BetweenR();
            Jump.GetComponent<Jump>().BetweenJ();
            aTtack.GetComponent<Attack>().BetweenA();
            aTtackS.GetComponent<AttackS>().BetweenS();
            hide.GetComponent<Hide>().BetweenH2();
            isDied = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            yield return new WaitForSeconds(2f);
            Die();
        }
        else if (PlayerPrefs.GetInt("i") == 18)
        {
            //Dành riêng cho Lv Boss
            if (AllowDie == true)
            {
                audi.clip = DiedClip;
                audi.Play();
                anim.SetTrigger("Died");
                Life = Life - 1;
                gameController.GetComponent<OldGameController>().GetPoint();
                Left.GetComponent<ButtonL>().BetweenL();
                Right.GetComponent<ButtonR>().BetweenR();
                Jump.GetComponent<Jump>().BetweenJ();
                aTtack.GetComponent<Attack>().BetweenA();
                aTtackS.GetComponent<AttackS>().BetweenS();
                hide.GetComponent<Hide>().BetweenH2();
                isDied = true;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                yield return new WaitForSeconds(2f);
                SetAllow.SetActive(true);
                Bossct.GetComponent<Boss>().gameObject.transform.position = Bossct.GetComponent<Boss>().OldPosition;
                Die();
            }
        }


    }
    public void Die()
    {
        SetLocation();
    }
    public void Activebtn()
    {
        Left.GetComponent<ButtonL>().BetweenL();
        Right.GetComponent<ButtonR>().BetweenR();
        Jump.GetComponent<Jump>().BetweenJ();
        aTtack.GetComponent<Attack>().BetweenA();
        aTtackS.GetComponent<AttackS>().BetweenS();
        hide.GetComponent<Hide>().BetweenH2();
    }
    public IEnumerator Died()
    {
        isDied = true;
        Debug.Log("Chết");
        yield return new WaitForSeconds(2);
        Debug.Log("Sống");
        isDied = false;
    }
    public IEnumerator SetLookOutDoorLv18()
    {
        LockAutoRunOutdoor = true;
        Left.GetComponent<ButtonL>().btnLeft.interactable = false;
        yield return new WaitForSeconds(2);
        LockAutoRunOutdoor = false;
        Left.GetComponent<ButtonL>().btnLeft.interactable = true;
    }
}











