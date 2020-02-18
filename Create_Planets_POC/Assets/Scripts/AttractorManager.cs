using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractorManager : MonoBehaviour
{
    private Attractor[] attractorList;
    public float G;
    public float T;

    // Start is called before the first frame update
    void Start()
    {
        T = 1;
        attractorList = FindObjectsOfType<Attractor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        print(T);
        foreach (Attractor att in attractorList)
        {
            foreach(Attractor rec in attractorList)
                if (rec != att)
                    att.Attract(rec);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            float newT = 2*T;
            ActualizeVelocity(newT);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            float newT = T/2;
            ActualizeVelocity(newT);
        }
    }

    private void ActualizeVelocity(float newT)
    {
        foreach (Attractor att in attractorList)
        {
            /*
            Rigidbody rb = att.GetComponent<Rigidbody>();
            Vector3 velocity = rb.velocity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            att.Initialize();
            */
            Rigidbody rb = att.GetComponent<Rigidbody>();
            rb.velocity = rb.velocity * newT / T;
        }
        print("T = " + newT);
        T = newT;
    }
}
