using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10;
    int count;
    public Text countText;
    AudioSource getSE;
    bool goalFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Hallo,World!");
        getSE = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goalFlag == false)
        {
            float moveH = Input.GetAxis("Horizontal");
            float moveV = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(moveH, 0, moveV);
            rb.AddForce(move * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            Debug.Log(count);
            SetCountText();
            getSE.Play();
        }
        else if(other.gameObject.CompareTag("StageBottom")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Goal!!!");
//            goalFlag = true;
        }
    }

    void SetCountText()
    {
        countText.text = "ゲット数：" + count.ToString();
    }
}
