using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Arrowgoup : MonoBehaviour
{
    public Rigidbody2D rig;
    public bool canbepressed;
    public Score addscore;
    public Score combo;
    public crossborder test;
    // Update is called once per frame
    void Update()
    {
     
        if (canbepressed == true && !gameObject.CompareTag("up note") && !gameObject.CompareTag("down note")&& !gameObject.CompareTag("left note") && Input.GetKeyDown(KeyCode.D))
        {
            combo.score += 1;
            addscore.score += 50;
            Destroy(gameObject);
        }

        if (canbepressed == true && !gameObject.CompareTag("note right") && !gameObject.CompareTag("down note") && !gameObject.CompareTag("left note") && Input.GetKeyDown(KeyCode.F))
        {
            combo.score += 1;
            addscore.score += 50;
            Destroy(gameObject);
        }
        if (canbepressed == true && !gameObject.CompareTag("note right") && !gameObject.CompareTag("up note") && !gameObject.CompareTag("left note") && Input.GetKeyDown(KeyCode.J))
        {
            combo.score += 1;
            addscore.score += 50;
            Destroy(gameObject);
        }
        if (canbepressed == true && !gameObject.CompareTag("note right") && !gameObject.CompareTag("down note") && !gameObject.CompareTag("up note") &&  Input.GetKeyDown(KeyCode.K))
        {
            combo.score += 1;
            addscore.score += 50;
            Destroy(gameObject);
        }
        //   force thing
        rig.AddForce(transform.up * 60000 * Time.deltaTime);
        if (rig.velocity.magnitude <= 100)
        {
            rig.velocity = Vector3.ClampMagnitude(rig.velocity, 1000f);
        }
    }

    public void OntriggerEnter(Collider2D collision)
    {
 if (!collision.gameObject.CompareTag("left"))
        {
            test.test30 = false;
        }
        if (!collision.gameObject.CompareTag("right"))
        {
            test.test30 = false;
        }
        if (!collision.gameObject.CompareTag("up"))
        {
            test.test30 = false;
        }
        if (!collision.gameObject.CompareTag("down"))
        {
            test.test30 = false;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
       
       



        if (collision.gameObject.CompareTag("left"))
        {
         canbepressed = true;
            test.test30 = true;
        }
        if (collision.gameObject.CompareTag("right"))
        {
            test.test30 = true;
            canbepressed = true;
        }

        if (collision.gameObject.CompareTag("up"))
        {
            canbepressed = true;
            test.test30 = true;
        }

        if (collision.gameObject.CompareTag("missed"))
        {
            combo.score = 0;
            addscore.score -= 20;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("down"))
        {
            test.test30 = true;
            canbepressed = true;
        }
    }


    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("left"))
        {
            canbepressed = false;
            
        }
        if (coll.gameObject.CompareTag("right"))
        {
            canbepressed = false;
           
        }

        if (coll.gameObject.CompareTag("up"))
        {
            canbepressed = false;
      
        }
        if (coll.gameObject.CompareTag("down"))
        {
           
            canbepressed = false; 
        }
    }





}   