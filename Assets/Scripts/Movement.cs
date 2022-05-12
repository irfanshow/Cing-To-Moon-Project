using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField]float thrustPower;
    [SerializeField]float thrustRotationPower;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        }
    }

    void RocketRotation(float rotationVar)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationVar * Time.deltaTime);
        rb.freezeRotation = false;
    }

}
