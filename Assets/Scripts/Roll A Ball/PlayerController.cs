using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public AudioSource shine;
    public Text countText;
   // public Text winText;
    public int buttonWidth;
    public int buttonHeight;

    private int origin_x;
    private int origin_y;
    private bool win;
    private Rigidbody rb;
    private int count;
    private CursorLockMode currentMode;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        win = false;
        SetCountText();
     //   winText.text = "";
        GetComponent<AudioSource>().playOnAwake = false;
        shine = GetComponent<AudioSource>();
        buttonWidth = 200;
        buttonHeight = 50;
        origin_x = Screen.width / 2 - buttonWidth / 2;
        origin_y = Screen.height / 2 - buttonHeight * 2;

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            shine.Play();
            SetCountText();

        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            win = true;
        //    winText.text = "You Win!";
            Time.timeScale = 0;
        }
    }
    void OnGUI()
    {
        if (win == true)
        {
            Cursor.lockState = currentMode = CursorLockMode.None;
            Cursor.visible = true;

            if (GUI.Button(new Rect(origin_x, origin_y + buttonHeight + 10, buttonWidth, buttonHeight), "Main Menu"))
            {
                SceneManager.LoadScene(0);
            }
            if (GUI.Button(new Rect(origin_x, origin_y + buttonHeight * 2 + 20, buttonWidth, buttonHeight), "Exit"))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
            }
        }


    }
}


