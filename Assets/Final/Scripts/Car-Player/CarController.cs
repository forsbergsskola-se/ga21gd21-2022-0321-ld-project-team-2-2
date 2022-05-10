using System.Collections;
using UnityEngine;

public class CarController : MonoBehaviour
{
    #region Variables

    [Header("Rigidbodies")]
    public Rigidbody sphereRB;
    public Rigidbody carRB;

    [Header("Normal")]
    public float fwdSpeed;
    public float revSpeed;
    public float turnSpeed;
    public LayerMask groundLayer;
    private float originalSpeed;
    public float gravityDrag = -200f;
    
    [Header("Boost")]
    public float boostSpeed;
    public float newGravity;
    public float cooldown;
    
    private float moveInput;
    private float turnInput;
    public bool isCarGrounded;
    private bool boostCheck = true;
    
    private float normalDrag;
    public float modifiedDrag;
    
    public float alignToGroundTime;

    public bool nitroUnlock = false;

    [SerializeField] private GameObject green;
    [SerializeField] private GameObject red;
    
    
    #endregion
    void Start()
    {
        // Detach Sphere from car
        sphereRB.transform.parent = null;
        carRB.transform.parent = null;

        normalDrag = sphereRB.drag;

        originalSpeed = fwdSpeed;
    }
    
    void Update()
    {
        // Get Input
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        // Calculate Turning Rotation
        float newRot = turnInput * turnSpeed * Time.deltaTime * moveInput;
        
        if (isCarGrounded)
            transform.Rotate(0, newRot, 0, Space.World);

        // Set Cars Position to Our Sphere
        transform.position = sphereRB.transform.position;

        // Raycast to the ground and get normal to align car with it.
        RaycastHit hit;
        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, groundLayer);
        
        // Rotate Car to align with ground
        Quaternion toRotateTo = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotateTo, alignToGroundTime * Time.deltaTime);
        
        // Calculate Movement Direction
        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;
        
        // Calculate Drag
        sphereRB.drag = isCarGrounded ? normalDrag : modifiedDrag;
        
        UIFollow();
    }

    private void FixedUpdate()
    {
        if (isCarGrounded)
            sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration); // Add Movement 
        else
            sphereRB.AddForce(transform.up * gravityDrag); // Add Gravity
        
        carRB.MoveRotation(transform.rotation);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(NitroBoost());
        }
        
    }

    IEnumerator NitroBoost()
    {
        if (boostCheck && nitroUnlock)
        {
            boostCheck = false;
            fwdSpeed = boostSpeed;
            gravityDrag = newGravity;
            yield return new WaitForSeconds(2);
            fwdSpeed = originalSpeed;
            gravityDrag = -200f;
            yield return new WaitForSeconds(cooldown);
            boostCheck = true;
        }
    }

    private void UIFollow()
    {
        if (boostCheck)
        {
            green.SetActive(true);
            red.SetActive(false);
        }
        else
        {
            red.SetActive(true);
            green.SetActive(false);
        }
    }
}