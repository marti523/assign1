using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LootScript : MonoBehaviour {

    public AudioSource loot;

    public int buttonWidth;
    public int buttonHeight;

    private int origin_x;
    private int origin_y;
    private bool win;
    private int count;
    private CursorLockMode currentMode;

    public GUIStyle style;
	// Use this for initialization
	void Start ()
    {
        count = 5;
        loot.GetComponent<AudioSource>();
        win = false;
        buttonWidth = 200;
        buttonHeight = 50;
        origin_x = Screen.width / 2 - buttonWidth / 2;
        origin_y = Screen.height / 2 - buttonHeight * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 0)
        {
            win = true;
            Time.timeScale = 0;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            count--;
            loot.Play();
            other.gameObject.SetActive(false);
        }
    }

    void OnGUI()
    {
            style.fontSize = 30;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(10,10, 100, 20),count + " Chests Remaining",style);
    
            style.normal.textColor = Color.magenta;
            GUI.Label(new Rect(Screen.width-300, 10, 100, 20),"Find the Chests", style);

        if(win == true)
        {
            Cursor.lockState = currentMode = CursorLockMode.None;
            Cursor.visible = true;
            //style.fontSize = 50;
            //style.normal.textColor = Color.magenta;
            //GUI.Label(new Rect(Screen.width/2 -150, origin_y + buttonHeight - 30, 100, 20), "YOU WON!", style);

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
