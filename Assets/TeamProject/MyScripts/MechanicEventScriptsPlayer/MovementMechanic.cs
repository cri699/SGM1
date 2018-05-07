using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMechanic : MonoBehaviour {
    private Vector3 lastRotation;
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Vector3 lookDirection;
    private Animator anim;

    [SerializeField] private LayerMask mLayerMask;

    // Use this for initialization
    void Start () {
        GetComponent<customCharController>().OnMovement += HandleMovement;

        
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        lookDirection = Vector3.zero;
    }
	
	void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("HorizontalJ" + this.transform.tag[6]);
        float vertical = Input.GetAxisRaw("VerticalJ" + this.transform.tag[6]);

        ////Keyboard
        //float horizontalK = Input.GetAxisRaw("HorizontalK");
        //float verticalK = Input.GetAxisRaw("VerticalK");
        ////keyboard


        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        ////KEYBOARD
        //Vector3 directionK = new Vector3(horizontalK, 0f, verticalK);
        ////KEYBOARD

        //keyboard                  //add horizontalk and verticalk if you want to use keyboard
        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("run", true);
            
        }
        else
        {
            anim.SetBool("run", false);
        }


        

        lookDirection = new Vector3(Input.GetAxisRaw("RightHoriz" + this.transform.tag[6]), 0, Input.GetAxisRaw("RightVert" + this.transform.tag[6]));

        //DISABLE HERE IF NO KEYBOARD USER
        //lookDirection = new Vector3(Input.GetAxisRaw("RightHorizK"), 0, Input.GetAxisRaw("RightVertK"));

        lastRotation = lookDirection;



        //Transform direction gets the world space instead of the local space

        direction = Camera.main.transform.TransformDirection(direction);
        direction.y = 0.0f;

        ////KEYBOARD
        //directionK = Camera.main.transform.TransformDirection(directionK);
        //directionK.y = 0.0f;
        ////KEYBOARD

        rb.velocity = Vector3.Normalize(direction) * speed * Time.deltaTime;

        //Keyboard
        //rb.velocity = Vector3.Normalize(directionK) * speed * Time.deltaTime;
        //Keyboard

        //Got the next if statement from here
        // https://answers.unity.com/questions/46845/face-forward-direction-of-movement.html
        //if (direction != Vector3.zero)
        //{
        //    //transform.rotation = Quaternion.Slerp(
        //    transform.rotation,
        //    Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed;




        //}

        //// FOR KEYBOARD LOOK AT MOUSE POSITION//
        //RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(ray, out hit, 100, mLayerMask))
        //{
        //    if(hit.collider.CompareTag("floor"))
        //    transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        //}
        // FOR KEYBOARD LOOK AT MOUSE POSITION//


        if (lookDirection.sqrMagnitude < 0.1f)
        {
            return;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection + lastRotation), Time.deltaTime * rotationSpeed);




    }
}
