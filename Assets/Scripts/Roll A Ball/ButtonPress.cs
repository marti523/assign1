using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour {

public void ButtonNextScene(int index)
    {
       SceneManager.LoadScene(index);
    }

public void NextSceneButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
