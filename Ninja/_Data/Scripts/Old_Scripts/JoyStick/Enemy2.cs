using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy2 : MonoBehaviour
{
 
    public float moveSpeed = 5f;
    public int moveAI = 15;
    public int rayLength = 8;
    public int rayAI = 8;
    public int hesoHidden = 0;
    int maxHealthy = 75, currentHealthy;
    int damage = 25;
    private float RayCheckLength;

    private float GroundBelowOffSet;      // khoảng cách dịch xuống phía dưới bao nhiêu
    private float GroundLeftSideOffSet;
    private float GroundRightSideOffSet;// khoảng cách dịch sang 2 bên trái phải

    Animator anim;
    GameObject obj;

    public bool moveRight;
    private bool isDied;
    public bool defense2;
    public bool isEscaped;
    public bool isGrounded;

    private Vector3 GroundLeft;
    private Vector3 GroundCenter;
    private Vector3 GroundRight;
    private Vector3 Scale;

    RaycastHit2D hit,hit2;
    RaycastHit2D[] GroundHitsLeft;
    RaycastHit2D[] GroundHitsCenter;
    RaycastHit2D[] GroundHitsRight;

    public GameObject dmGB, goldWB;
    // Start is called before the first frame update
    void Start()
    {
        isDied = false;
        currentHealthy = maxHealthy;
        obj = gameObject;
        anim = obj.GetComponent<Animator>();
        defense2 = false;
        rayAI = rayLength;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        RayCheckLength = 0.1f;
        GroundBelowOffSet = 0.72f;      // khoảng cách dịch xuống phía dưới bao nhiêu
        GroundLeftSideOffSet = 0;
        GroundRightSideOffSet = 0.6f;
        isEscaped = false;
    }

    // Update is called once per frame
    public void Update()
    {
        // Attack
        hit = Physics2D.Raycast(obj.transform.position + transform.localScale.x * Vector3.right, transform.localScale.x * Vector2.right, rayLength);
        Debug.DrawRay(obj.transform.position + transform.localScale.x * Vector3.right, transform.localScale.x * Vector2.right * rayLength, Color.green, 0.5f);
         if (hit.collider != null)
            {
                if (hit.collider.tag != "Enemy1" || hit.collider.tag != "Enemy2" || hit.collider.tag != "Enemy3")
                {
                   if (hit.collider.tag == "Player" || hit.collider.tag == "St")
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
        
       // Dành cho phòng thủ
        if (defense2 == true)
        {
            hit2 = Physics2D.Raycast(obj.transform.position + transform.localScale.x * Vector3.left, transform.localScale.x * Vector2.left, rayAI);
            Debug.DrawRay(obj.transform.position + transform.localScale.x * Vector3.left, transform.localScale.x * Vector2.left * rayAI, Color.red, 0.5f);
            
            if (hit2.collider != null)
            {
                if (hit2.collider.tag != "Enemy1" || hit2.collider.tag != "Enemy2" || hit2.collider.tag != "Enemy3")
                {
                    if (hit2.collider.tag == "Player" || hit2.collider.tag == "St")
                    {
                        if (moveRight)
                        {
                            moveRight = false;
                        }
                        else
                        {
                            moveRight = true;

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

        Scale = obj.transform.localScale;
    }
    public IEnumerator StaticDonotDrop()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
    public void RaySetUp()
    {
        //Xác định vị trí check Ground
        if (Scale.x == -1f)
        {
            GroundLeft = obj.transform.position + new Vector3(-GroundLeftSideOffSet, -GroundBelowOffSet, 0);
            GroundCenter = obj.transform.position + new Vector3(0.3f, -GroundBelowOffSet, 0);
            GroundRight = obj.transform.position + new Vector3(GroundRightSideOffSet, -GroundBelowOffSet, 0);
        }
        else if (Scale.x == 1f)
        {
            // Để tránh việc phải thay đôi các hằng số khi local Scale thì ta đổi thứ tự Left Right trong các vị trí Raycast, Left-> Rigth và ngược lại
            // Lưu ý đây không phải sai
            GroundLeft = obj.transform.position + new Vector3(-GroundRightSideOffSet, -GroundBelowOffSet, 0);
            GroundCenter = obj.transform.position + new Vector3(-0.3f, -GroundBelowOffSet, 0);
            GroundRight = obj.transform.position + new Vector3(GroundLeftSideOffSet, -GroundBelowOffSet, 0);
        }

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
            if (hit3.collider.tag != "Enemy2")
            {
                if (hesoHidden == 0)
                {
                    if (hit3.collider.tag == "Ground")
                    {
                        return true;
                    }
                }
                else if(hesoHidden == 1 && isEscaped == true)
                {
                    if (hit3.collider.tag == "Ground")
                    {
                        return true;
                    }
                }    
            }
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D turn2)
    {
        if (turn2.gameObject.CompareTag("Turn2"))
        {
            if (moveRight) { moveRight = false; }
            else { moveRight = true; }
        }
        if (turn2.gameObject.CompareTag("KN2"))
        {
           
            Die();
        }
        if (turn2.gameObject.CompareTag("St"))
        {
            currentHealthy = currentHealthy - damage;
            if (currentHealthy <= 0)
            {
                Die();
            }
            defense2 = true;
        }
        if (turn2.gameObject.CompareTag("Boom"))
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
            defense2 = false;
        }
        if (col.gameObject.tag == "Ground" && hesoHidden == 0)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
        if ( col.gameObject.tag == "TransferTurn2" && hesoHidden == 1)              
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Hàm này chỉ riêng cho Enemy2 bơi vì trong StoneHidden, pLayer đsung vì nếu trong Th cả 2 StoneHidden và ground cùng chạm thì escape ko đúng vì enemy vẫn chạm đất o thoát khỏi player
        if(collision.gameObject.tag == "Player")
        {
            isEscaped = true;
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
        Debug.Log("AAaaaaaaaaa");
        int i = Random.Range(1, 10);
        if (i == 5 )
        {
            Instantiate(dmGB, gameObject.transform.position, Quaternion.identity);
        }
        else if (i != 2 && i != 3 && i != 6 && i != 8)
        {
            Instantiate(goldWB, gameObject.transform.position, Quaternion.identity);
        }

    }

}

