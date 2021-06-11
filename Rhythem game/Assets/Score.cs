using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI textui;
    
    // Update is called once per frame
    void Update()
    {
         textui.text = Mathf.Clamp((int)score, -100, int.MaxValue).ToString();

        if (gameObject.CompareTag("combo"))
        {
            if(score == 50f)
            {
                textui.color = new Color(71, 0, 245, 255);
            }
            if(score == 0f)
            {
                textui.color = new Color(255, 255, 255, 255);
            }
        }

    }

    
}
