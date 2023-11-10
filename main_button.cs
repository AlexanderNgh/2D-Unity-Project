using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using these libraries
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playBTN : MonoBehaviour
{
    //make a class var that is a button (button comes from UI library)
    public Button playButton;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<gameObjectType>() gets reference to the button 
        //AddListener to the onClick allows you to make a function,
        playButton = GetComponent<Button>();
        playButton.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick(){
        //load the scene using the Scene Manager, preserve nothing! 
        SceneManager.LoadScene("SampleScene");
    }
}
