using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [Header("wheels")]
    public GameObject[] wheelsToRotate;

    [Header("effects")]
    public TrailRenderer[] trails;
    public ParticleSystem smoke;

    [Header("movement")]
    public float rotationSpeed;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalAxis = Input.GetAxisRaw("Vertical");
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        foreach (var wheel in wheelsToRotate)
        {
            wheel.transform.Rotate(0, 0, Time.deltaTime * verticalAxis * rotationSpeed, Space.Self);
        }

        if (horizontalAxis > 0)
        {
            //turning right
            anim.SetBool("goingLeft", false);
            anim.SetBool("goingRight", true);
        }
        else if (horizontalAxis < 0)
        {
            //turning left
            anim.SetBool("goingRight", false);
            anim.SetBool("goingLeft", true);
        }
        else
        {
            //must be going straight
            anim.SetBool("goingRight", false);
            anim.SetBool("goingLeft", false);
        }

        if (horizontalAxis != 0)
        {
            foreach (var trail in trails)
            {
                trail.emitting = true;
            }

            var emission = smoke.emission;
            emission.rateOverTime = 5f;
        }
        else
        {
            foreach (var trail in trails)
            {
                trail.emitting = false;
            }

            var emission = smoke.emission;
            emission.rateOverTime = 0f;
        }
    }
}