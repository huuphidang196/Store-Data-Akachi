using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1a : MonoBehaviour
{
    public float moveSpeed =5f;
    public int moveAI = 15;
    public int rayLength = 8;
    int maxHealthy = 100, currentHealthy;
    int damage = 25;
    private float RayCheckLength;

    private float GroundBelowOffSet;      // khoảng cách dịch xuống phía dưới bao nhiêu
    private float GroundLeftSideOffSet;
    private float GroundRightSideOffSet;// khoảng cách dịch sang 2 bên trái phải

    Animator anim;
    GameObject obj;
    public GameObject dmGB, goldWB;

    private bool isDied;
    public bool defense;
    public bool moveLeft;
    public bool CheckTurnFlash;
    public bool isGrounded;

    private Vector3 GroundLeft;
    private Vector3 GroundCenter;
    private Vector3 GroundRight;
    private Vector3 Scale;

    RaycastHit2D hit,hit2;
    RaycastHit2D[] GroundHitsLeft;
    RaycastHit2D[] GroundHitsCenter;
    RaycastHit2D[] GroundHitsRight;
   
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        currentHealthy = maxHealthy;
        anim = GetComponent<Animator>();
        isDied = false;
        defense = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        // Cài đặt hằng số ngay từ đầu tránh việc phải cài đặt riêng, không private vì có thể mong muốn điều chỉnh
        RayCheckLength = 0.3f;
        GroundBelowOffSet =  1.1f;      
        GroundLeftSideOffSet = 0;
        GroundRightSideOffSet = 1;

        CheckTurnFlash = false;
}
    public void  Update()                                 // Lưu ý: tránh để hit Va chạm với cái Turn Trigger 
    {   
        hit = Physics2D.Raycast(obj.transform.position + transform.localScale.x * Vector3.left + 0.5f*Vector3.down, transform.localScale.x * Vector2.left, rayLength);
        if (hit.collider != null)
        {
            if (hit.collider.tag != "Enemy1" || hit.collider.tag != "Enemy2" || hit.collider.tag != "Enemy3")
            {
                if (hit.collider.tag == "Player" || hit.collider.tag == "St")
                {
                    if (isDied == false)
                    {
                        if (moveLeft)
                        {

                            transform.Translate(-1 * Time.deltaTime * moveAI, 0, 0);
                            transform.localScale = new Vector2(1, 1);

                        }
                        else
                        {
                            transform.Translate(1 * Time.deltaTime * moveAI, 0, 0);
                            transform.localScale = new Vector2(-1, 1);
                        }
                        anim.SetBool("Walk", true); Debug.Log("AI");

                    }
                }
                else
                {
                    if (isDied == false)
                    {
                        if (moveLeft)
                        {

                            transform.Translate(-1 * Time.deltaTime * moveSpeed, 0, 0);
                            transform.localScale = new Vector2(1, 1);

                        }
                        else
                        {
                            transform.Translate(1 * Time.deltaTime * moveSpeed, 0, 0);
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
                if (moveLeft)
                {

                    transform.Translate(-1 * Time.deltaTime * moveSpeed, 0, 0);
                    transform.localScale = new Vector2(1, 1);

                }
                else
                {
                    transform.Translate(1 * Time.deltaTime * moveSpeed, 0, 0); 
                    transform.localScale = new Vector2(-1, 1);
                }
                anim.SetBool("Walk", true);
            }

        }
        Debug.DrawRay(obj.transform.position + transform.localScale.x * Vector3.left + 0.5f*Vector3.down, transform.localScale.x * Vector2.left * rayLength, Color.yellow, 0.5f);       
        if (defense==true )
        {
            hit2 = Physics2D.Raycast(obj.transform.position + 1.2f * transform.localScale.x * Vector3.right + 0.5f * Vector3.down, transform.localScale.x * Vector2.right, rayLength);
             if (hit2.collider != null)
             {
                if (hit2.collider.tag != "Enemy1" || hit2.collider.tag != "Enemy2" || hit2.collider.tag != "Enemy3")
                {
                    if (hit2.collider.tag == "Player" || hit2.collider.tag == "St")
                    {
                        if (moveLeft)
                        {
                            moveLeft = false;

                        }
                        else
                        {
                            moveLeft = true;

                        }
                    }

                }
                Debug.DrawRay(obj.transform.position + 1.2f * transform.localScale.x * Vector3.right + 0.5f * Vector3.down, transform.localScale.x * Vector2.right * rayLength, Color.red, 0.5f);
            }
        }

        RaySetUp();
        // Mục đích khi nó có bay ra thì cũng check , TH này dùng cho enemy vượt qua Turn và cho StoneHidden
        if (isGrounded == true && CheckTurnFlash == false) // Cái này chỉ làm bởi vì Enemy 1 khi gặp Turn sẽ bị dật rồi khựng lại do thay đổi bodytype
        {
            StartCoroutine(StaticDonotDrop());
        }
        else if(isGrounded == false)
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
        // Xác định vị trí check Ground
        if(Scale.x == 1)
        {
            GroundLeft = obj.transform.position + new Vector3(-GroundLeftSideOffSet, -GroundBelowOffSet, 0);
            GroundCenter = obj.transform.position + new Vector3(0.5f, -GroundBelowOffSet, 0);
            GroundRight = obj.transform.position + new Vector3(GroundRightSideOffSet, -GroundBelowOffSet, 0);
        }    
        else if(Scale.x == -1f)
        {
            // Để tránh việc phải thay đôi các hằng số khi local Scale thì ta đổi thứ tự Left Right trong các vị trí Raycast, Left-> Rigth và ngược lại
            // Lưu ý đây không phải sai
            GroundLeft = obj.transform.position + new Vector3(-GroundRightSideOffSet, -GroundBelowOffSet, 0);
            GroundCenter = obj.transform.position + new Vector3(-0.5f, -GroundBelowOffSet, 0);
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
        foreach(RaycastHit2D hit3 in RayHits)
        {
            if(hit3.collider.tag != "Enemy1")
            {
                if(hit3.collider.tag == "Ground")
                {
                    return true;
                }    
            }    
        }
        return false;
    }    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
            defense = false;
        }
       

    }
    
    void OnTriggerEnter2D(Collider2D turn1)
    {
        if (turn1.gameObject.CompareTag("Turn1"))
        {
            if (moveLeft) { moveLeft = false; }
            else { moveLeft = true; }
            CheckTurnFlash = true;
        }

        if (turn1.gameObject.CompareTag("KN2"))
        {
            Die();
        }
        if (turn1.gameObject.CompareTag("St"))
        {
            currentHealthy=currentHealthy-damage;
            if(currentHealthy<=0)
            {
                Die();
            }
            defense = true;
        }
        if (turn1.gameObject.CompareTag("Boom"))
        {
            Die();
        }
    }
    public void OnTriggerExit2D(Collider2D turn1)
    {
        // Cái này chỉ làm bởi vì Enemy 1 khi gặp Turn sẽ bị dật rồi khựng lại do thay đổi bodytype
        if (turn1.gameObject.CompareTag("Turn1"))
        {
            CheckTurnFlash = false;
        }
    }
    public void Die()
    {
        anim.SetBool("isDead", true);
        Debug.Log("Enemy died");
        GetComponent<Collider2D>().isTrigger=true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        isDied = true;
        CreatdM();
    }
    public void CreatdM()
    {
        int i = Random.Range(1, 10);
        if (i == 5)
        {
            Instantiate(dmGB, gameObject.transform.position, Quaternion.identity);
        }
        else if (i != 1 && i != 4 && i != 6 && i != 8)
        {
            Instantiate(goldWB, gameObject.transform.position, Quaternion.identity);
        }

    }


}
