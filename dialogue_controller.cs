using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
public class Dialogue_NPC : MonoBehaviour
{
    private bool inRange; //truth value for whether or not you are close enough
    public GameObject dialoguePanel; //reference to dialoguePanel
    public TextMeshProUGUI dialogueText; //reference to textbox
    public TextMeshProUGUI dialogueName;
    public GameObject NPC;
    public string[] dialogue; //list of dialogue
    public int dialogueAmt; //amount of dialogue
    public int dialogueCurr; //current dialogue you are on
    private bool isAnimating;

    void Start(){
        
        dialogueName.text = gameObject.name;
    }

    //when colliding, set the inrange bool to true
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            inRange = true;
        }
    }

    //when you leave set it to false and clear text
    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            inRange = false;
            clearText();
            if(dialogueCurr >= dialogueAmt){
                dialogueCurr = 0;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //If you are in range of the NPC and click on the mouse 
        //then trigger this if statement
        if(inRange == true && Input.GetMouseButtonDown(0)){
            if(isAnimating == true){return;}
            //three flows the initial dialogue, the middle portion, and the last
            if(dialoguePanel.activeInHierarchy && dialogueCurr >= dialogueAmt){
                dialogueCurr = 0;
                clearText();
            }
            else if(dialoguePanel.activeInHierarchy && dialogueCurr < dialogueAmt){
                StartCoroutine(addText(dialogue[dialogueCurr]));
                dialogueCurr = dialogueCurr + 1;
            }
            else{
                dialoguePanel.SetActive(true);
                StartCoroutine(addText(dialogue[dialogueCurr]));
                dialogueCurr = dialogueCurr + 1;
            }
        }
    }

    //disable the panel and clear the text
    void clearText(){
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
    }

    IEnumerator addText(string text)
    {
        isAnimating = true;
        float textSpeed = 0.05f;
        dialogueText.text = ""; //clear just in case something fails

        foreach (char c in text){
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isAnimating = false;
    }
}
