using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossborder : MonoBehaviour
{ 
 // compoments ------------------------------------------
 public Score score;
 public Score comboscore;
 public Animator effects;
 //static bool -------------------------------------------
 public static bool donotmiss;
 // bools ------------------------------------------------
 public bool right;
 public bool left;
 public bool up;
 public bool down;
 public bool destorynote;
 // ------------------------------------------------------
 
    void Update()
    {
        // right 
        if (right == true && Input.GetKeyDown(KeyCode.D))
        {
         destorynote = true;
       
        }
        else if( donotmiss != true  &&  right != true &&Input.GetKeyDown(KeyCode.D))
        {
            comboscore.score = 0;
            score.score -= 7.5f;
        }
        // up
        if (up == true  && Input.GetKeyDown(KeyCode.F))
        {
         destorynote = true;
         
        }
        else if( donotmiss!= true  && up != true && Input.GetKeyDown(KeyCode.F))
        {
         comboscore.score = 0;
         score.score -= 7.5f;
        }
        // down
        if (down == true && Input.GetKeyDown(KeyCode.J))
        {
         destorynote = true;
         
        }
        else if ( donotmiss!= true && down != true &&  Input.GetKeyDown(KeyCode.J))
        {
            comboscore.score = 0;
            score.score -= 7.5f;
        }
        // left
        if (left == true &&  Input.GetKeyDown(KeyCode.K))
        {
         destorynote = true;
        
        }
        else if (donotmiss != true  && left != true && Input.GetKeyDown(KeyCode.K))
        {
            comboscore.score = 0;
            score.score -= 7.5f;
        }
    }

    // a shity script
    public void OnTriggerEnter2D(Collider2D other)
    {
       
        // unorganized terrible code
        if (other.gameObject.CompareTag("up note") && gameObject.CompareTag("arrowjudger"))
        {
            up = true;
            donotmiss = true;
        }
        if (other.gameObject.CompareTag("down note") && gameObject.CompareTag("arrowjudger"))
        {
            down = true;
            donotmiss = true;
        }

        if (other.gameObject.CompareTag("left note") && gameObject.CompareTag("arrowjudger"))
        {
          left = true;
          donotmiss = true;
        }

        if (other.gameObject.CompareTag("right note")&& gameObject.CompareTag("arrowjudger"))
        {
            right = true;
            donotmiss = true;
        }
    }
    
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(destorynote == true)
        {  
            effects.SetTrigger("Whenpressbutten");
            comboscore.score += 1;
            score.score += 50;
            collision.gameObject.SetActive(false);
        }
       
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("right note") && gameObject.CompareTag("arrowjudger"))
        {
            up = false;
            donotmiss = false;
        }
        if (collision.gameObject)
        {
            destorynote = false;
        }
        if (!collision.gameObject.CompareTag("up note") && gameObject.CompareTag("arrowjudger"))
        {
            down = false;
            donotmiss = false;
        }
        if (!collision.gameObject.CompareTag("down note") && gameObject.CompareTag("arrowjudger"))
        {
            left = false;
            donotmiss = false;
        }

        if (!collision.gameObject.CompareTag("left note") && gameObject.CompareTag("arrowjudger"))
        {
            right = false;
            donotmiss = false;
        }


    }
}
