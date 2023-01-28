using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private int JumpHeight;
    [SerializeField] private Transform GroundCheckTransform;
    [SerializeField] private LayerMask PlayerMask;
    [SerializeField] private float WalkSpeed = 1f;

    private bool IsJumping;
    private float HorizontalInput;
    private Rigidbody Skeleton;
    private bool IsOnGround;
    

    // Start is called before the first frame update
    private void Start()
    {
        Skeleton = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsJumping = true;
        }


        HorizontalInput = Input.GetAxis("Horizontal");
    }


    // Called once every physics update
    private void FixedUpdate()
    {


        Vector3 MovementVelocity = Skeleton.velocity;
        float XPosition = HorizontalInput * WalkSpeed;
        float YPosition = MovementVelocity.y;
        float ZPosition = 0;
        Skeleton.velocity = new Vector3(XPosition, YPosition, ZPosition);

        if (Physics.OverlapSphere(GroundCheckTransform.position, 0.1f, PlayerMask).Length == 0) return;

        if (IsJumping)
        {
            Skeleton.AddForce(Vector3.up * JumpHeight, ForceMode.VelocityChange);
            IsJumping = false;
        } else
        {
            IsJumping = false;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsOnGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        IsOnGround = false;
    }
}
