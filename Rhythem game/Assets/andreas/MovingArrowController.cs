using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingArrowController : MonoBehaviour
{
    private readonly float speed = 5.0f;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(0,Time.deltaTime * speed, 0);

        if (transform.position.y >= 60.0f)
        {
            Destroy(gameObject);
        }
    }
}
