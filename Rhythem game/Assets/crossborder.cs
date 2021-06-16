using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossborder : MonoBehaviour
{ 
    public Score score;
    public Score comboscore;
    public bool right;
    public bool left;
    public bool up;
    public bool down;
    public bool canhitornot;
    public bool destorynote;
 
    
    void Update()
    {
      
        // right 
        if (right == true && Input.GetKeyDown(KeyCode.D))
        {
         destorynote = true;
        }
        if( canhitornot != true &&  right != true &&Input.GetKeyDown(KeyCode.D))
        {
         score.score -= 3f;
        }
        // up
        if (up == true  && Input.GetKeyDown(KeyCode.F))
        {
         destorynote = true;
        }
        if( canhitornot != true && up != true && Input.GetKeyDown(KeyCode.F))
        {
         score.score -= 3f;
        }
        // down
        if (down == true && Input.GetKeyDown(KeyCode.J))
        {
         destorynote = true;
        }
        if ( canhitornot != true && down != true &&  Input.GetKeyDown(KeyCode.J))
        {
         score.score -= 3f;
        }
        // left
        if (left == true &&  Input.GetKeyDown(KeyCode.K))
        {
         destorynote = true;
        }
        if (canhitornot != true && left != true && Input.GetKeyDown(KeyCode.K))
        {
           
            score.score -= 3f;
        }
    }

    // a shity script
    public void OnTriggerEnter2D(Collider2D other)
    {
       
        // unorganized terrible code
        if (other.gameObject.CompareTag("up note") && gameObject.CompareTag("arrowjudger"))
        {
            up = true;
            canhitornot = true;
        }
        if (other.gameObject.CompareTag("down note") && gameObject.CompareTag("arrowjudger"))
        {
            down = true;
            canhitornot = true;
        }

        if (other.gameObject.CompareTag("left note") && gameObject.CompareTag("arrowjudger"))
        {
          left = true;
            canhitornot = true;
        }

        if (other.gameObject.CompareTag("right note")&& gameObject.CompareTag("arrowjudger"))
        {
            right = true;
            canhitornot = true;
        }
    }
    
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(destorynote == true)
        {
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
            canhitornot = false;
        }
        if (collision.gameObject)
        {
            destorynote = false;
        }
        if (!collision.gameObject.CompareTag("up note") && gameObject.CompareTag("arrowjudger"))
        {
            down = false;
            canhitornot = false;
        }
        if (!collision.gameObject.CompareTag("down note") && gameObject.CompareTag("arrowjudger"))
        {
            left = false;
            canhitornot = false;
        }

        if (!collision.gameObject.CompareTag("left note") && gameObject.CompareTag("arrowjudger"))
        {
            right = false;
            canhitornot = false;
        }


    }
}
