using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    //make these public variables so that when you attatch them to gameObjects
    //you can access them / be more flexible and reuse the script
    public string sceneName;
    public float xAxis;
    public float yAxis;

    //create private variables one for position and one for the player object
    private  Vector2 position;
    private GameObject playerOBJ; 

    private void OnTriggerEnter2D(Collider2D other){
        //if something collides with the box colider
        //and the tag is a player, then trigger this if statement
        if(other.tag == "Player"){
            //get the specified position into a vector2 since this is 2D and get reference
            position = new Vector2(xAxis, yAxis);
            playerOBJ = other.gameObject;
            
            //update the other objects position and load the scene 
            //player object is already set to do not destory, so no need to preserve it here, this would cause dupes/clones
            playerOBJ.transform.position = position;
            SceneManager.LoadScene(sceneName);
        }
    }
}
