using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    private float hInput, vInput;

    void Update()
    {
        InitAxis();
        TranslatePlayer();
        RotatePlayer();
    }

    void InitAxis()
    {
        hInput = Input.GetAxis("Horizontal")*rotateSpeed;
        vInput = Input.GetAxis("Vertical")*moveSpeed;
    }

    void TranslatePlayer()
    {
        transform.Translate(vInput * Time.deltaTime * Vector3.forward);
    }

    void RotatePlayer()
    {
        transform.Rotate(hInput* Time.deltaTime * Vector3.up);
    }

}
