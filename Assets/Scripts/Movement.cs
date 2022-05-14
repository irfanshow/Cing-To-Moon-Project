using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    AudioSource sfx;

    [SerializeField]float thrustPower;
    [SerializeField]float thrustRotationPower;
    [SerializeField]AudioClip kucingEngine;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RotationControl();
        ThrustControl();
    }

    void RotationControl()
    {
        if(Input.GetKey(KeyCode.D))
        {
            RocketRotation(-thrustRotationPower);
        }

        else if(Input.GetKey(KeyCode.A))
        {
            RocketRotation(thrustRotationPower);
        }
    }

    void ThrustControl()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
            if(!sfx.isPlaying)
            {
                sfx.PlayOneShot(kucingEngine);
            }
            
        }

        else{
            sfx.Stop();
        }
    }

    void RocketRotation(float rotationVar)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationVar * Time.deltaTime);
        rb.freezeRotation = false;
    }

}
