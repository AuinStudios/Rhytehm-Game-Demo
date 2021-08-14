using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ChannelSprites
{
    public GameObject channel1Prefab;
    public GameObject channel2Prefab;
    public GameObject channel3Prefab;
    public GameObject channel4Prefab;
}

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    public ChannelSprites channelSprites;

    [Range(1.0f, 700.0f)]
    public float bpm = 100.0f;

    public List<GameObject> allArrows;

    public Renderer renderer;

    private Vector3 _channel1;
    private Vector3 _channel2;
    private Vector3 _channel3;
    private Vector3 _channel4;

    private float _cooldownTimer;
    private bool _beat = false;

    public Vector3 Channel1 { get => _channel1; set => _channel1 = value; }
    public Vector3 Channel2 { get => _channel2; set => _channel2 = value; }
    public Vector3 Channel3 { get => _channel3; set => _channel3 = value; }
    public Vector3 Channel4 { get => _channel4; set => _channel4 = value; }
    public float CooldownTimer { get => _cooldownTimer; set => _cooldownTimer = value; }
    public bool Beat { get => _beat; set => _beat = value; }

    private void Start()
    {
        CooldownTimer = bpm;
        allArrows = new List<GameObject>();
    }

    void Update()
    {
        float[] spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            //Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Channel1 = new Vector3(i, spectrum[i + 1] + 10, 0);

            //Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Channel2 = new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2);

            //Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Channel3 = new Vector3(Mathf.Log(i), spectrum[i] - 10, 1);

            //Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
            Channel4 = new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3);
        }

        if (CooldownTimer > bpm)
        {
            CooldownTimer -= 60.0f * Time.deltaTime;
            Beat = false;
        }
        else 
        {
            CooldownTimer = bpm;
            Beat = true;
        }

        if (Beat == true)
        {
            if (Channel1.y > -18.0f)
            {
                GameObject arrow = Instantiate(channelSprites.channel1Prefab, transform);
                allArrows.Add(arrow);
            }
            if (Channel2.y > 9.5f)
            {
                GameObject arrow = Instantiate(channelSprites.channel2Prefab, transform);
                allArrows.Add(arrow);
            }   
            if (Channel3.y > -18.0f)
            {
                GameObject arrow = Instantiate(channelSprites.channel3Prefab, transform);
                allArrows.Add(arrow);
            }
            if (Channel4.y > -10.0f)
            {
                GameObject arrow = Instantiate(channelSprites.channel4Prefab, transform);
                allArrows.Add(arrow);
            }
        }

        renderer = allArrows[0].GetComponent<Renderer>();

        if (!IsArrowVisible())
        {
            GameObject cachedarrow = allArrows[0];
            allArrows.RemoveAt(0);

            Destroy(cachedarrow);
        }
    }

    bool IsArrowVisible()
    {
        if (renderer.isVisible)
        {
            return true;
        }
        else
        {
            renderer = allArrows[1].GetComponent<Renderer>();

            return false;
        }
    }
}
