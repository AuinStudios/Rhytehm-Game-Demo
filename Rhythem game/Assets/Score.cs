using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;

public class Score : MonoBehaviour
{
    public float score;
    public Volume help;
    public TextMeshProUGUI textui;
    // Update is called once per frame
  
    void Update()
    {
       textui.text = Mathf.Clamp((int)score, -100, int.MaxValue).ToString();
      
        if (gameObject.CompareTag("combo"))
        {
             Bloom bloo;
       help.profile.TryGet( out bloo);
       
            if(score >= 5f)
            { 
                textui.color = new Color(0, 56, 250, 255);
                bloo.intensity.value = 5;
            }
            if(score <= 0f)
            {
                textui.color = new Color(255, 255, 255, 255);
                bloo.intensity.value = 0;
                help.sharedProfile.Add<Bloom>().intensity.value = 0;
               
            }
        }

    }

    
}
