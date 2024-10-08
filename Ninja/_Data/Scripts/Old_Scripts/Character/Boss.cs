using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHealthy = 1000;
    public int currentHealthy;
    public int damage = 10;

    public int k;  // tạo 1 stoneboss
    public int km;
    public int N = 0;
    public float moveSpeed;
    public float RayLength;
    public float RayLength1, RayLength2, RayLength34, RayLength5, RayLengthSky;
    public float RayPositionHit1, RayPositionHit2, RayPositionHit34, RayPositionHit5, RaypositionHitSky;   // dùng để dịch chuyển vị trí theo trục y
    public float RayPositionOffSet; //Dùng để dịch chuyển nối đất sang 2 bên
    public float RayPositionOffSetSky;

    public GameObject FootPosition;
    public GameObject BodyBoss;
    public GameObject stoneBoss;
    public GameObject gameController;
    Vector3 Myself;

    public bool isGrounded;
    public bool hit1, hit2, hit3, hit4, hit5, hitSky;
    public bool hitSky6, hitSky7, hitSky8, hitSky9;
    public bool Right, Idle;
    private bool GroundLeft, GroundCenter, GroundRight;

    private Vector3 Foot;
    public Vector3 OldPosition;
    Vector3 GroundLeftPosition;
    Vector3 GroundCenterPosition;
    Vector3 GroundRightPosition;
    Vector3 ActionHitsPosition1;
    Vector3 ActionHitsPosition2;
    Vector3 ActionHitsPosition3;
    Vector3 ActionHitsPosition4;
    Vector3 ActionHitsPosition5;
    // Các RayCast trên không 6,7 nằm ở góc phân tư thứ II, 8-9 nằm ở góc phân tư thứ nhất
    // Các tia 6 -7 lần lượt tạo góc 150,120. 8-9 lần lượt tạo góc 60,30
    Vector3 SkyActionPosition6;
    Vector3 SkyActionPosition7;
    Vector3 SkyActionPosition8;
    Vector3 SkyActionPosition9;

    Animator anim;
    Rigidbody2D mybody;

    RaycastHit2D[] GroundHitsLeft;
    RaycastHit2D[] GroundHitsCenter;
    RaycastHit2D[] GroundHitsRight;
    RaycastHit2D[] ActionHits1;
    RaycastHit2D[] ActionHits2;
    RaycastHit2D[] ActionHits3;
    RaycastHit2D[] ActionHits4;
    RaycastHit2D[] ActionHits5;
    //Sky
    RaycastHit2D[] SkyActionHits6;
    RaycastHit2D[] SkyActionHits7;
    RaycastHit2D[] SkyActionHits8;
    RaycastHit2D[] SkyActionHits9;

    AudioSource audi;
    public AudioClip bossShout, bossThrow, bossPunch, bossChuy;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Foot = FootPosition.transform.position;
        Myself = gameObject.transform.position;
        OldPosition = gameObject.transform.position;
        mybody.bodyType = RigidbodyType2D.Dynamic;
        Idle = true;
        k = 0;
        currentHealthy = maxHealthy;
        OldPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    public void Update()
    { 
        RaySetUp();
        RaySKy();
        RunBoss();
        AttackBoss();
        if(currentHealthy > 0)
        {
            if (isGrounded == true)
            {
                mybody.bodyType = RigidbodyType2D.Kinematic;
            }
            else if (isGrounded == false)
            {
                mybody.bodyType = RigidbodyType2D.Dynamic;
            }
        }    
       
        Foot = FootPosition.transform.position;  //ko xóa
        Myself = gameObject.transform.position;  // ko xóa
        N++;
        
          
    }
    
    public void RunBoss()
    {
          
        if(Idle == false )
        {
            if (Right == true)
            {
                gameObject.transform.Translate(moveSpeed * Time.deltaTime * 1, 0, 0);
                gameObject.transform.localScale = new Vector3(-2, 2, 0);
            }
            else if (Right == false)
            {
                gameObject.transform.Translate(moveSpeed * Time.deltaTime * -1, 0, 0);
                gameObject.transform.localScale = new Vector3(2, 2, 0);
            }
            anim.SetBool("Run", true);
        }    
        else if(Idle == true)
        {
            anim.SetBool("Run", false);
        }    
        
    }    
    public void AttackBoss()
    {
        if(hit1 == true)
        {
            anim.SetTrigger("Punch");
            audi.clip = bossPunch;
            audi.Play();
        } 
        else if(hit1 == false)
        {
            if (hit2 == true)
            {
                anim.SetTrigger("Chuy");
                audi.clip = bossChuy;
                audi.Play();
            }
            else if(hit2 == false && hitSky == false)
            {
                hit5 = RayCheck2(ActionHits5);
                if (hit5 == true)
                {
                    k++;
                    if (k == 1)
                    {
                        if(hitSky == false)
                        {
                            StartCoroutine(SetK());
                            anim.SetTrigger("Throw");
                        }           
                    }
                }   
                if (hit5 == false)
                {
                    if (Idle == false)
                    {
                        anim.SetBool("Run", true);
                    }
                }    
               
            }    
        }    
       
    }    
    public void RaySetUp()
    {
        //Vị trí Ray - đất
        GroundLeftPosition = new Vector3(Foot.x - RayPositionOffSet, Foot.y, 0);
        GroundCenterPosition = Foot;
        GroundRightPosition = new Vector3(Foot.x + RayPositionOffSet, Foot.y, 0);
        //Vị trí Ray- hit1
        ActionHitsPosition1 = new Vector3(Myself.x, Myself.y + RayPositionHit1, 0);
        ActionHitsPosition2 = new Vector3(Myself.x - RayLength1 * 0.5f * transform.localScale.x, Myself.y + RayPositionHit2, 0); // mặc dùng RayPosition2 = 0 nhưng vẫn để vẫn lỡ điều chỉnh
        ActionHitsPosition3 = new Vector3(Myself.x + 0.01f, Myself.y - RayPositionHit34, 0);
        ActionHitsPosition4 = new Vector3(Myself.x - 0.01f, Myself.y - RayPositionHit34, 0);
        ActionHitsPosition5 = new Vector3(Myself.x - RayLength2 - RayLength1, Myself.y - RayPositionHit5, 0);

        // Raycast

        GroundHitsLeft = Physics2D.RaycastAll(GroundLeftPosition, Vector2.down, RayLength);
        GroundHitsCenter = Physics2D.RaycastAll(GroundCenterPosition, Vector2.down, RayLength);
        GroundHitsRight = Physics2D.RaycastAll(GroundRightPosition, Vector2.down, RayLength);

        ActionHits1 = Physics2D.RaycastAll(ActionHitsPosition1, Vector2.left * transform.localScale.x, RayLength1);
        ActionHits2 = Physics2D.RaycastAll(ActionHitsPosition2, Vector2.left * transform.localScale.x, RayLength2);
        ActionHits3 = Physics2D.RaycastAll(ActionHitsPosition3, Vector2.right , RayLength34);
        ActionHits4 = Physics2D.RaycastAll(ActionHitsPosition4, Vector2.left , RayLength34);
        ActionHits5 = Physics2D.RaycastAll(ActionHitsPosition5, Vector2.left * transform.localScale.x, RayLength5);

        //vẽ
        DrawRay();
        //Set bool isGrounded
        GroundLeft = RayCheck(GroundHitsLeft);
        GroundCenter = RayCheck(GroundHitsCenter);
        GroundRight = RayCheck(GroundHitsRight);
        //hit1 - Punch or TĐC
        //hit2 - Chuy
        //hit5 - throw

        //hit3 - right
        //hit5 - left
        if(currentHealthy > 0)
        {
            hit1 = RayCheck2(ActionHits1);
            // đảm bảo sao cho các ray ko cùng lúc true
            if (hit1 == false)
            { // Xét theo độ dài từ nhỏ đến lớn
                hit2 = RayCheck2(ActionHits2);
                if (hit2 == false)
                {
                    hit5 = RayCheck2(ActionHits5);
                    AllowThrowBoss();
                    if (hit5 == false)
                    {
                        hit3 = RayCheck2(ActionHits3);
                        hit4 = RayCheck2(ActionHits4);
                    }
                }
            }
        }    
       
        else if(hit1 == true)
        {
            hit2 = false;
            hit3 = false;
            hit4 = false;
            hit5 = false;
        }    
        if(hit2 == true)
        {
            hit3 = false;
            hit4 = false;
            hit5 = false;
        }  
        if(hit5 == true)
        {
            hit3 = false;
            hit4 = false;
        }   
 
       // dừng move
        if(hit3 == true || hit4 == true)
        {
            Idle = false;
        }    
        else if(hit3 == false && hit4 == false )   
        {
            Idle = true;
        }    


        if (GroundLeft == true || GroundCenter == true || GroundRight == true)
        {
            isGrounded = true;
        }
        else if( GroundLeft == false && GroundCenter == false && GroundRight == false)
        {
            isGrounded = false;
        } 

        if(hit4 == true )
        {
            Right = false;
        }    
        else if(hit3 == true)
        {
            Right = true;
        }    
            
    }    
    public void RaySKy()
    {
        //Set vị trí các Raycast Sky
        SkyActionPosition6 = new Vector3(Myself.x - 3*km*RayPositionOffSetSky , Myself.y + RaypositionHitSky + km*RayPositionOffSetSky, 0);
        SkyActionPosition7 = new Vector3(Myself.x - 0.6f * km * RayPositionOffSetSky, Myself.y + RaypositionHitSky + km*RayPositionOffSetSky, 0);
        SkyActionPosition8 = new Vector3(Myself.x + 0.6f * km * RayPositionOffSetSky, Myself.y + RaypositionHitSky + km*RayPositionOffSetSky, 0);
        SkyActionPosition9 = new Vector3(Myself.x + 3*km * RayPositionOffSetSky, Myself.y + RaypositionHitSky + km*RayPositionOffSetSky, 0);
        //Set RayCast
        SkyActionHits6 = Physics2D.RaycastAll(SkyActionPosition6, new Vector2(Mathf.Cos((17 * Mathf.PI) / 18), Mathf.Sin((17 * Mathf.PI) / 18)), RayLengthSky);
        SkyActionHits7 = Physics2D.RaycastAll(SkyActionPosition7, new Vector2(Mathf.Cos((7 * Mathf.PI) / 9), Mathf.Sin((7 * Mathf.PI) / 9)), RayLengthSky);
        SkyActionHits8 = Physics2D.RaycastAll(SkyActionPosition8, new Vector2(Mathf.Cos((2 * Mathf.PI) / 9), Mathf.Sin((2 * Mathf.PI) / 9)), RayLengthSky);
        SkyActionHits9 = Physics2D.RaycastAll(SkyActionPosition9, new Vector2(Mathf.Cos((1 * Mathf.PI) / 18), Mathf.Sin((1 * Mathf.PI) / 18)), RayLengthSky);
        //Vẽ
        DrawRay();

        //Check bool
        hitSky6 = RayCheck3(SkyActionHits6);
        hitSky7 = RayCheck3(SkyActionHits7);
        hitSky8 = RayCheck3(SkyActionHits8);
        hitSky9 = RayCheck3(SkyActionHits9);

        if(hitSky6 == true || hitSky7 == true || hitSky8 == true || hitSky9 == true )
        {
            hitSky = true;
        }    
        else if(hitSky6 == false && hitSky7 == false && hitSky8 == false && hitSky9 == false)
        {
            hitSky = false;
        }    
        if(hitSky6 == true || hitSky7 == true)
        {
            gameObject.transform.localScale = new Vector3(2, 2, 0);
        }    
        else if(hitSky8 == true || hitSky9 == true)
        {
            gameObject.transform.localScale = new Vector3(-2, 2, 0);
        }
        
        SkyStone();
    }    
    public void SkyStone()
    {
        if (hitSky == true)
        {
            hit5 = false;
            k++;
            if (k == 1)
            {
                StartCoroutine(SetK2());
                anim.SetTrigger("Throw");
            }
        }
        else if(hitSky == false)
        {
            AttackBoss();
        }    
    }    
    public void DrawRay()
    {
        Debug.DrawRay(GroundLeftPosition, Vector2.down * RayLength, Color.blue);
        Debug.DrawRay(GroundCenterPosition, Vector2.down * RayLength, Color.blue);
        Debug.DrawRay(GroundRightPosition, Vector2.down * RayLength, Color.blue);
        // Với mỗi action sẽ có 1 animator khác nhau
        Debug.DrawRay(ActionHitsPosition1, Vector2.left * RayLength1 * 0.5f * transform.localScale.x, Color.green);
        Debug.DrawRay(ActionHitsPosition2, Vector2.left * RayLength2 * 0.5f * transform.localScale.x, Color.red);
        Debug.DrawRay(ActionHitsPosition5, Vector2.left * RayLength5 * 0.5f * transform.localScale.x, Color.black);

        Debug.DrawRay(ActionHitsPosition3, Vector2.right * RayLength34 , Color.cyan);
        Debug.DrawRay(ActionHitsPosition4, Vector2.left * RayLength34, Color.yellow);

        // Raycast Sky 6 7 8 9
        Debug.DrawRay(SkyActionPosition6, (new Vector2(Mathf.Cos((17 * Mathf.PI) / 18), Mathf.Sin((17 * Mathf.PI) / 18))) * RayLengthSky, Color.gray);
        Debug.DrawRay(SkyActionPosition7, (new Vector2(Mathf.Cos((7 * Mathf.PI) / 9), Mathf.Sin((7 * Mathf.PI) / 9))) * RayLengthSky, Color.gray);
        Debug.DrawRay(SkyActionPosition8, (new Vector2(Mathf.Cos((2 * Mathf.PI) / 9), Mathf.Sin((2 * Mathf.PI) / 9))) * RayLengthSky, Color.gray);
        Debug.DrawRay(SkyActionPosition9, (new Vector2(Mathf.Cos((1 * Mathf.PI) / 18), Mathf.Sin((1 * Mathf.PI) / 18))) * RayLengthSky, Color.gray);
    }    
    public bool RayCheck(RaycastHit2D[] RayHits)
    {
        foreach(RaycastHit2D hits in RayHits)
        {
            if(hits.collider.tag != null )
            {
                if(hits.collider.tag != "FootBoss")
                {
                    if(hits.collider.tag == "Ground")
                    {
                        return true;
                    }    
                }    
            }    
        }
        return false;
    }
    public bool RayCheck2(RaycastHit2D[] RayHits2)
    {
        foreach (RaycastHit2D hits2 in RayHits2)
        {
            if (hits2.collider.tag != null)
            {
                if (hits2.collider.tag != "BodyBoss")
                {
                    if(hits2.collider.tag != "Enemy")
                    {
                        if (hits2.collider.tag == "Player")
                        {
                            return true;
                        }
                    }    
                      
                }
            }
        }
        return false;
    }
    public bool RayCheck3(RaycastHit2D[] RayHits3)
    {
        foreach(RaycastHit2D hit3 in RayHits3)
        {
            if(hit3.collider.tag != null)
            {
                if(hit3.collider.tag != "Enemy")
                {
                    if (hit3.collider.tag == "Player")
                    {
                        return true;
                    }
                }                  
            }          
        }
        return false;
    }    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Turn2")
        {
            if(Right == true)
            {
                Right = false;
            }    
            else if( Right == false)
            {
                Right = true;
            }    
        }    
        
    }

    public void AllowThrowBoss()
    {
       if(N == 150)
       {
            RayLength5 = 12;
       }
       else if(N != 150)
       {
            RayLength5 = 0;
       }
        if (N == 200)
        {
            N = 0;
        }   
    }
    public IEnumerator SetK()
    {
        moveSpeed = 0f;
        yield return new WaitForSeconds(0.4f);
        if(currentHealthy > 0)
        {
            Instantiate(stoneBoss, new Vector3(Myself.x - 0.5f * transform.localScale.x, Myself.y + 0.3f, 0), Quaternion.identity);
            moveSpeed = 0f;
            audi.clip = bossShout;
            audi.Play();
        }            
        yield return new WaitForSeconds(0.4f);
        moveSpeed = 10;
        yield return new WaitForSeconds(0.5f);
        k = 0;
    }
    public IEnumerator SetK2()
    {
        moveSpeed = 0f;
        yield return new WaitForSeconds(0.4f);
        if(currentHealthy > 0)
        {
            Instantiate(stoneBoss, new Vector3(Myself.x - 0.5f * transform.localScale.x, Myself.y + 0.3f, 0), Quaternion.identity);
            moveSpeed = 0;
            audi.clip = bossShout;
            audi.Play();
        }           
        yield return new WaitForSeconds(0.4f);
        moveSpeed = 10;
        yield return new WaitForSeconds(0.5f);
        k = 0;
    }

    public void IsAttackedSt()
    {
        currentHealthy = currentHealthy - damage;
        if (currentHealthy <= 0)
        {
            StartCoroutine(BossDie());
        }
    }    
    public void IsAttackKN2()
    {
        currentHealthy = currentHealthy - 5 * damage;
        if (currentHealthy <= 0)
        {
            StartCoroutine(BossDie());
        }
    }    
    public IEnumerator BossDie()
    {
        anim.SetTrigger("Died");
        hit1 = false;
        hit2 = false;
        hit3 = false;
        hit4 = false;
        hit5 = false;
        hitSky = false;
        hitSky6 = false;
        hitSky7 = false;
        hitSky8 = false;
        hitSky9 = false;
        moveSpeed = 0;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        BodyBoss.GetComponent<BodyBoss>().GetComponent<Collider2D>().isTrigger = true;       
        yield return new WaitForSeconds(10);
        audi.enabled = false;
        Time.timeScale = 0;
        gameController.GetComponent<OldGameController>().BossLv15Completed();
    }    
}
