using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {

    private float angleA;
    public float angleB = 45;

    public float speed;
    public float restitution;
    public float bullshitValue;

    public KeyCode flipKey = KeyCode.Colon;

    private HingeJoint2D hinge;

    private float velocity;
    private float angle_to;

    public bool bouncing;

	// Use this for initialization
	void Start ()
    {
        hinge = transform.GetComponent<HingeJoint2D>();
        hinge.useMotor = true;

        angleA = hinge.jointAngle;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(flipKey))
        {
            if (angle_to != angleB)
            {
                angle_to = angleB;
                bouncing = false;

                if (angleB > angleA)
                {
                    JointMotor2D new_motor = hinge.motor;
                    new_motor.motorSpeed = speed;
                    velocity = new_motor.motorSpeed;
                    hinge.motor = new_motor;
                }
                else
                {
                    JointMotor2D new_motor = hinge.motor;
                    new_motor.motorSpeed = -speed;
                    velocity = new_motor.motorSpeed;
                    hinge.motor = new_motor;
                }
            }
        }
        else
        {
            if (angle_to != angleA)
            {
                angle_to = angleA;
                bouncing = false;
                if (angleB > angleA)
                {
                    JointMotor2D new_motor = hinge.motor;
                    new_motor.motorSpeed = -speed;
                    velocity = new_motor.motorSpeed;
                    hinge.motor = new_motor;
                }
                else
                {
                    JointMotor2D new_motor = hinge.motor;
                    new_motor.motorSpeed = speed;
                    velocity = new_motor.motorSpeed;
                    hinge.motor = new_motor;
                }
            }
        }

        //if joint has passed the constraint point, bounce it back
        if ((velocity > 0 && hinge.jointAngle > angle_to) || (velocity < 0 && hinge.jointAngle <= angle_to))
        {
            bouncing = true;
        }
        

        if (bouncing)
        {
            if (Mathf.Abs(hinge.jointAngle - angle_to) < 0.5f && hinge.motor.motorSpeed < 1)
            {
                JointMotor2D new_motor = hinge.motor;
                new_motor.motorSpeed = 0;
                hinge.motor = new_motor;
            }
            //if joint has passed the constraint point, bounce it back
            if ((velocity > 0 && hinge.jointAngle > angle_to) || (velocity < 0 && hinge.jointAngle < angle_to))
            {
                JointMotor2D new_motor = hinge.motor;
                float new_speed = Mathf.Abs(new_motor.motorSpeed * restitution);
                if (velocity > 0)
                {
                    new_motor.motorSpeed = -new_speed;
                }
                else
                {
                    new_motor.motorSpeed = new_speed;
                }
                hinge.motor = new_motor;
            }
            else
            {
                JointMotor2D new_motor = hinge.motor;
                new_motor.motorSpeed += velocity * bullshitValue;
                hinge.motor = new_motor;
            }
        }
	}
}
