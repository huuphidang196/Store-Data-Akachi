using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBoxDrop : MonoBehaviour
{
    public GameObject txtGBCreat;
    public bool SetText;
    // Start is called before the first frame update
    void Start()
    {
        SetText = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(SetText == true)
        {
            txtGBCreat.transform.SetParent(this.transform);
        }    
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<Collider2D>().isTrigger = true;
        }    
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Destroy(gameObject);
            SetText = true;
            GameObject point = Instantiate(txtGBCreat, transform.position + new Vector3(0,1,0), Quaternion.identity) as GameObject;
            point.transform.GetChild(0).GetComponent<txtGoldBoxCreat>().FlyGB();
        }
    }
    
}
