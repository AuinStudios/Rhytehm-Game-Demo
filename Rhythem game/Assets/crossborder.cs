using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossborder : MonoBehaviour
{
    public bool test30;
    public Score score;
    public Score comboscore;


    // Update is called once per frame



    public void FixedUpdate()
    {
        if(test30 == false && Input.GetKeyDown(KeyCode.D))
        {
            comboscore.score = 0;
           
        }
        if (test30 == false && Input.GetKeyDown(KeyCode.F))
        {
            comboscore.score = 0;
            
        }


        if (test30 == false && Input.GetKeyDown(KeyCode.J))
        {
          comboscore.score = 0;
            
        }


        if (test30 == false && Input.GetKeyDown(KeyCode.K))
        {
            comboscore.score = 0;
            
        }

    }
    void Update()
    {
        if (test30 == false && Input.GetKeyDown(KeyCode.D))
        {
        score.score -= 1;

        }
        if (test30 == false && Input.GetKeyDown(KeyCode.F))
        {
         score.score -= 1;
        }

        if (test30 == false && Input.GetKeyDown(KeyCode.J))
        {
         score.score -= 1;
        }

        if (test30 == false && Input.GetKeyDown(KeyCode.K))
        {
         score.score -= 1;
        }
    }
}
