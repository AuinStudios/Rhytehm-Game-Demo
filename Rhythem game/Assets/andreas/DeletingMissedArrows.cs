using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DeletingMissedArrows : MonoBehaviour
{
    public AudioController audio;
    public Camera camera;
    public Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        audio = transform.GetComponent<AudioController>();
        camera = Camera.main;
        renderer = audio.allArrows[0].GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
