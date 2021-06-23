using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Arrowgoup : MonoBehaviour
{
    public Rigidbody2D rig;
    public Score addscore;
    public Score combo;
    // Update is called once per frame
    void Update()
    {
        //   force thing
        rig.AddForce(transform.up * 10000 * Time.deltaTime);
        if (rig.velocity.magnitude <= 100)
        {
            rig.velocity = Vector3.ClampMagnitude(rig.velocity, 1000f);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("missed"))
        {
            combo.score = 0;
            addscore.score -= 30;
            Destroy(gameObject);
        }
     
    }
}   