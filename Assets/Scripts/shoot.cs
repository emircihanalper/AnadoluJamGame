using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    public GameObject shoot_object;
    public GameObject pivotpoint;

    void Update()
    {
        if (Input.GetKeyDown("e")) 
        {
            mermigonder();
        }
    }
    public void mermigonder()
    {
        GameObject thrownobject = Instantiate(shoot_object, pivotpoint.transform.position, transform.rotation);
        thrownobject.GetComponent<Rigidbody2D>().AddForce(transform.right * 750);
    }

}
