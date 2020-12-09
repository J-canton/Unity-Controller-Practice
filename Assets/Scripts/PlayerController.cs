using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public float jumSpeed;
    public GameObject bullet;
    public Transform shootPoint;
    public float bulletSpeed = 100f;

    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    private float hInput, vInput;

    private Rigidbody _rb;
    private CapsuleCollider _col;

    void Start() 
    {
        _rb = GetComponent<Rigidbody>();
        _col  = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        InitAxis();
        Shoot();
    }

    void FixedUpdate() 
    {
        PhysicRotation();   
        Jump();
    }

    void InitAxis()
    {
        hInput = Input.GetAxis("Horizontal")*rotateSpeed;
        vInput = Input.GetAxis("Vertical")*moveSpeed;
    }

    // MOVE WITHOUT PHYSIC
    void TranslatePlayer()
    {
        transform.Translate(vInput * Time.deltaTime * Vector3.forward);
    }

    void RotatePlayer()
    {
        transform.Rotate(hInput* Time.deltaTime * Vector3.up);
    }

    //MOVE WITH PHYSIC
    void PhysicRotation(){
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(transform.position + transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& IsOnTheGround())
        {
            _rb.AddForce(Vector3.up * jumSpeed, ForceMode.Impulse);
        }
    }

    void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = shootPoint.forward * bulletSpeed;
        }
    }

    bool IsOnTheGround()
    {
    Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
    bool onTheGround = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
    return onTheGround;
    }

}
