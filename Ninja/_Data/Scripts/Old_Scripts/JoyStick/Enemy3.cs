using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
   
    public float moveSpeed = 5f;
    int maxHealthy = 125, currentHealthy;
    int damage = 25;
    public int moveAI = 15;
    public int rayLength = 8;
    private float RayCheckLength;

    Animator anim;
    GameObject obj;
    public GameObject dmGB, goldWB;

    public bool moveRight;
    private bool isDied;
    public bool defense3;
    public bool isGrounded;

    private float GroundBelowOffSet;      // khoảng cách dịch xuống phía dưới bao nhiêu
    private float GroundLeftSideOffSet;
    private float GroundRightSideOffSet;// khoảng cách dịch sang 2 bên trái phải


    private Vector3 GroundLeft;
    private Vector3 GroundCenter;
    private Vector3 GroundRight;

    RaycastHit2D hit, hit2;
    RaycastHit2D[] GroundHitsLeft;
    RaycastHit2D[] GroundHitsCenter;
    RaycastHit2D[] GroundHitsRight;


    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        anim = obj.GetComponent<Animator>();
        isDied = false;
        defense3 = false;
        currentHealthy = maxHealthy;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        RayCheckLength = 0.15f;
        GroundBelowOffSet = 1f;      // khoảng cách dịch xuống phía dưới bao nhiêu
        GroundLeftSideOffSet = 0.6f;
        GroundRightSideOffSet = 0.6f;
    }
    // Update is called once per frame
    void Update()
    {
      
        hit = Physics2D.Raycast(obj.transform.position + transform.localScale.x * Vector3.right, transform.localScale.x * Vector2.right, rayLength);
        Debug.DrawRay(obj.transform.position + transform.localScale.x * Vector3.right, transform.localScale.x * Vector2.right * rayLength, Color.black, 0.5f);
        if (hit.collider != null)
            {
               if (hit.collider.tag != "Enemy1" || hit.collider.tag != "Enemy2" || hit.collider.tag != "Enemy3")
               {
                 if (hit.collider.tag == "Player"  || hit.collider.tag == "St")
                 {
                
                    if (isDied == false)
                    {
                        if (moveRight)
                        {

                            transform.Translate(1 * Time.deltaTime * moveAI, 0, 0);
                            transform.localScale = new Vector2(1, 1);

                        }
                        else
                        {
                            transform.Translate(-1 * Time.deltaTime * moveAI, 0, 0);
                            transform.localScale = new Vector2(-1, 1);
                        }
                        anim.SetBool("Walk", true); Debug.Log("AI");

                    }
                 }
                 else
                 {
                    if (isDied == false)
                    {
                        if (moveRight)
                        {

                            transform.Translate(1 * Time.deltaTime * moveSpeed, 0, 0);
                            transform.localScale = new Vector2(1, 1);

                        }
                        else
                        {
                            transform.Translate(-1 * Time.deltaTime * moveSpeed, 0, 0);
                            transform.localScale = new Vector2(-1, 1);
                        }
                        anim.SetBool("Walk", true);

                    }
                 }
               }
            }
        else

            {
                if (isDied == false)
                {
                    if (moveRight)
                    {

                        transform.Translate(1 * Time.deltaTime * moveSpeed, 0, 0);
                        transform.localScale = new Vector2(1, 1);

                    }
                    else
                    {
                        transform.Translate(-1 * Time.deltaTime * moveSpeed, 0, 0);
                        transform.localScale = new Vector2(-1, 1);
                    }
                    anim.SetBool("Walk", true);
                }

            }
        
        if (defense3==true)
        {
            hit2 = Physics2D.Raycast(obj.transform.position + 1.5f * transform.localScale.x * Vector3.left, transform.localScale.x * Vector2.left, rayLength);
            Debug.DrawRay(obj.transform.position + 1.5f * transform.localScale.x * Vector3.left, transform.localScale.x * Vector2.left * rayLength, Color.yellow, 0.5f);
            if (hit2.collider != null)
            {
                if (hit2.collider.tag != "Enemy1" || hit2.collider.tag != "Enemy2" || hit2.collider.tag != "Enemy3")
                {

                    if (hit2.collider.tag == "Player" || hit2.collider.tag == "St")
                    {
                        if (moveRight)
                        {
                            moveRight = false;
                            //  defense3 = false;
                        }
                        else
                        {
                            moveRight = true;
                            //  defense3 = false;
                        }
                    }
                }
                
            }
         
        }
        RaySetUp();
        // Mục đích khi nó có bay ra thì cũng check , TH này dùng cho enemy vượt qua Turn và cho StoneHidden
        if (isGrounded == true)
        {
            StartCoroutine(StaticDonotDrop());
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

    }
    public IEnumerator StaticDonotDrop()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
    public void RaySetUp()
    {
        // khác với Enemy1 và 2 thì là vì collider đối xứng nên không cần phải xét 2 TH Scale.x = 1 haowjc Scale.x = -1
        GroundLeft = obj.transform.position + new Vector3(-GroundLeftSideOffSet, -GroundBelowOffSet, 0);
        GroundCenter = obj.transform.position + new Vector3(0, -GroundBelowOffSet, 0);
        GroundRight = obj.transform.position + new Vector3(GroundRightSideOffSet, -GroundBelowOffSet, 0);

        // Xác định RayHits
        GroundHitsLeft = Physics2D.RaycastAll(GroundLeft, Vector2.down, RayCheckLength);
        GroundHitsCenter = Physics2D.RaycastAll(GroundCenter, Vector2.down, RayCheckLength);
        GroundHitsRight = Physics2D.RaycastAll(GroundRight, Vector2.down, RayCheckLength);

        isGrounded = RayCheCk(GroundHitsLeft);
        isGrounded = RayCheCk(GroundHitsCenter);
        isGrounded = RayCheCk(GroundHitsRight);

        // Vẽ rayCast
        DrawRay();
    }
    public void DrawRay()
    {
        Debug.DrawRay(GroundLeft, Vector2.down * RayCheckLength, Color.blue);
        Debug.DrawRay(GroundCenter, Vector2.down * RayCheckLength, Color.blue);
        Debug.DrawRay(GroundRight, Vector2.down * RayCheckLength, Color.blue);
    }
    public bool RayCheCk(RaycastHit2D[] RayHits)
    {
        foreach (RaycastHit2D hit3 in RayHits)
        {
            if (hit3.collider.tag != "Enemy3")
            {
                if (hit3.collider.tag == "Ground")
                {
                    return true;
                }
            }
        }
        return false;
    }
    private void OnTriggerEnter2D(Collider2D turn3)
    {
        if (turn3.gameObject.CompareTag("Turn3"))
        {
            if (moveRight) { moveRight = false; }
            else { moveRight = true; }
        }
        if (turn3.gameObject.CompareTag("KN2"))
        {
            Die();
           
        }
        if (turn3.gameObject.CompareTag("Boom"))
        {
            Die();
        }
        if (turn3.gameObject.CompareTag("St"))
        {
            currentHealthy = currentHealthy - damage;
            if (currentHealthy <= 0)
            {
                Die();
            }
            defense3 = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
            defense3 = false;
        }
       
    }
   
    void Die()
    {
        anim.SetTrigger("Died");
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        isDied = true;
        CreatdM();
    }
    public void CreatdM()
    {
        int i = Random.Range(1, 10);
        if (i == 4)
        {
            Instantiate(dmGB, gameObject.transform.position, Quaternion.identity);
        }
        else if (i != 1 && i != 4  && i != 6 && i != 8)
        {
            Instantiate(goldWB, gameObject.transform.position, Quaternion.identity);
        }

    }
       
    }
