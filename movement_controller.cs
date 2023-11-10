using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
public class movement_NPC : MonoBehaviour
{
    public Rigidbody2D character;
    public Animator characterAnimator;

    public float speed = 2f;

    public float[] time;
    public string[] direction;

    public int totalIter;
    public int currIter = 0;
    public GameObject dialoguePanel;

    private float currTime = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
        character = this.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {

        if(dialoguePanel.activeInHierarchy){
            moveIdle();
            return;}
        if(currIter >= totalIter){
            currIter = 0;
        }
        //ADD THAT IF A DIALOGUE PANEL IS ACTIVE IN THE HIERACHY TO PAUSE ALL MOVEMENT (just return;)
        if(currTime < time[currIter]){
            currTime += Time.deltaTime;
            if(direction[currIter] == "up"){moveUp();}
            else if(direction[currIter] == "left"){moveLeft();}
            else if(direction[currIter] == "right"){moveRight();}
            else if(direction[currIter] == "down"){moveDown();}
            else{moveIdle();}
        }else{
            currTime = 0;
            currIter += 1;
        }
    }

   void moveUp(){
        character.velocity = new Vector2(0, 1 * speed);
   }

   void moveLeft(){
        character.velocity = new Vector2(-1 * speed, 0);
   }

   void moveRight(){
        character.velocity = new Vector2(1 * speed, 0);
   }
   void moveDown(){
        character.velocity = new Vector2(0, -1 * speed);
   }
   void moveIdle(){
        character.velocity = new Vector2(0, 0);
   }
}
