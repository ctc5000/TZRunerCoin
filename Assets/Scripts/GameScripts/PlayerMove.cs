using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public VariableJoystick Joystic;
    public VariableJoystick CamJoystic;
    public GameManager Gm;
    public float speed = 1.5f; 
    public float acceleration = 100f;
    private Transform rotate; 
    public float jumpForce = 5; 
    public float jumpDistance = 1.2f; 
    private Vector3 direction;
    private float h, v,hc,vc;
    private int layerMask;
    private Rigidbody body;
    private float rotationY;
    private float rotationX;
    public float sensitivity = 0.5f;
    public float headMinY = -10f;
    public float headMaxY = 10f;

    void Awake()
    {
       
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
        gameObject.tag = "Player";
        layerMask = 1 << gameObject.layer | 1 << 2;
        layerMask = ~layerMask;
        rotate = gameObject.transform;
    }

    void FixedUpdate()
    {
        if(!Gm.GameOver)
        {
            body.AddForce(direction * speed, ForceMode.VelocityChange);
            if (Mathf.Abs(body.velocity.x) > speed)
            {
                body.velocity = new Vector3(Mathf.Sign(body.velocity.x) * speed, body.velocity.y, body.velocity.z);
            }
            if (Mathf.Abs(body.velocity.z) > speed)
            {
                body.velocity = new Vector3(body.velocity.x, body.velocity.y, Mathf.Sign(body.velocity.z) * speed);
            }
        }
    }

    bool GetJump()
    {
        GetComponent<Animator>().SetTrigger("Jump");
        bool Canjump = false;
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit, jumpDistance, layerMask))
        {
            Canjump = true;
        }

        return Canjump;
    }

    public void JumpPlayer()
    {

        if (GetJump())
        {
            body.velocity = new Vector2(0, jumpForce);
        }
    }

    void Update()
    {
        h = Joystic.Horizontal;
        v = Joystic.Vertical;
        hc = CamJoystic.Horizontal;
        vc = CamJoystic.Vertical;

        //Rotate Camera
        float rotationX = rotate.localEulerAngles.y + hc * sensitivity;
        rotationY += vc * sensitivity;
        rotationY = Mathf.Clamp(rotationY, headMinY, headMaxY);
        rotate.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        //Move Player
        direction = new Vector3(h, 0, v);
        direction = rotate.TransformDirection(direction);
        direction = new Vector3(direction.x, 0, direction.z);
        //Animate Player
        if (v != 0) { GetComponent<Animator>().SetBool("Run", true); }
        else { GetComponent<Animator>().SetBool("Run", false); }
    }
}
