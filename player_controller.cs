using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFunctionality : MonoBehaviour
{
    public float speed;
    private bool playerExists;
    public Animator OttoAnimator;
    // Start is called before the first frame update
    public Rigidbody2D ottoBody;
    void Start()
    {
        ottoBody = this.GetComponent<Rigidbody2D>();
        OttoAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        //get the pos / neg values depedning on the input

        ottoBody.velocity = new Vector2(xAxis * speed, yAxis * speed);

        //update position of the rigidbody through the rigidbody reference 

        OttoAnimator.SetFloat("horizontal", xAxis);
        OttoAnimator.SetFloat("vertical", yAxis);
    }

    void Awake(){
        //if more than 1 player object, then delete, because that means when the scene is initalized/loaded
        //there is a dupleicate to destory the calling game object
        //the orginal player should be preserved due to the other if statement
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 1){
             Destroy(gameObject);
             return;
        }

        //if there are no players registered, which the bool keeps track of
        //change it to true and preserve the game object
        if(playerExists == false){
            playerExists = true;
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
        }
    }
}
