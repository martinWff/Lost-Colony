using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;

    private Rigidbody rb;
    private bool jumpFlag = false;

    private Transform parent;

    [SerializeField] private Transform groundChecker;

    private Vector3 scale;

    int mask;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mask = ~(1 << LayerMask.NameToLayer("Waypoint"));
        scale = transform.localScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(groundChecker.position, -groundChecker.up);
        RaycastHit hit;

        bool onGround = false;
        bool onVehicle;


        if (Physics.Raycast(r, out hit, 1, mask,QueryTriggerInteraction.Ignore))
        {
            onGround = true;


            if (hit.transform.gameObject.CompareTag("Transportation"))
            {
                if (transform.parent != hit.transform)
                {
                    transform.SetParent(hit.transform);
                }
                onVehicle = true;
            }
            else
            {
                onVehicle = false;
            }

        } else
        {
            onVehicle = false;
        }

        if (!onVehicle)
        {
            if (transform.parent != parent)
            {
                transform.SetParent(parent);
                transform.localScale = scale;

            }
        }


        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            jumpFlag = true;

        }
    }

    private void FixedUpdate()
    {
        //Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * movementSpeed;
        Vector3 velocity = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");

        velocity *= movementSpeed;

        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
        if (jumpFlag)
        {
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            jumpFlag = false;
        }
    }
}
