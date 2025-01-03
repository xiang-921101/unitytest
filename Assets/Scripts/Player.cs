using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody2D rb;  //可提供剛體引用
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //這次練習中使用的get mouse button 是只要點擊就會做動作，之前的 void onMouse則是點擊(一下)
        if (Input.GetMouseButton(0))
        {   
            //抓取滑鼠或手指點擊的點，如果在螢幕中心的右邊就是正數，左邊是負數
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (touchPos.x < 0)
            {   
                //使用Rigidbody和AddForce會讓物體移動起來比較自然
                rb.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rb.AddForce(Vector2.right * moveSpeed);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
