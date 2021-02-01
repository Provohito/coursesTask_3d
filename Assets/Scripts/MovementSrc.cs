using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSrc : MonoBehaviour
{
    [SerializeField]
    float speed;
    
    [SerializeField]
    float jumpForce;

    [SerializeField]
    private Transform rotateCursor;

    [SerializeField]
    private Transform gun;

    [SerializeField]
    private Texture2D CrossHair;

    private CharacterController chController;

    float verticalSpeed;

    [SerializeField]
    private float runForce;

    Vector3 _moveVector;
    
    private void Awake()
    {
        chController = GetComponent<CharacterController>();
    }
    void OnGUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, 10, 10), CrossHair);

    }

    private void Update()
    {
        float _MouseX = Input.GetAxis("Mouse X");
        float _MouseY = -Input.GetAxis("Mouse Y");
        chController.transform.Rotate(Vector3.up, _MouseX);
        rotateCursor.transform.Rotate(Vector3.right, _MouseY,Space.Self);
        gun.transform.Rotate(Vector3.forward, -_MouseY);
        
        var _horizontal = Input.GetAxis("Horizontal");
        var _vectical = Input.GetAxis("Vertical");

         
        _moveVector = transform.forward * _vectical * speed * Time.deltaTime + transform.right * _horizontal * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) & chController.isGrounded)
        {

            speed += runForce;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) & chController.isGrounded)
            speed -= runForce;
            
        
        verticalSpeed = chController.velocity.y;
        verticalSpeed += Physics.gravity.y * Time.deltaTime;

        float _jumpAxis = Input.GetAxis("Jump");
        if (_jumpAxis > 0 && chController.isGrounded)
        {
            verticalSpeed = jumpForce;
        }

        _moveVector += transform.up * verticalSpeed * Time.deltaTime;
        chController.Move(_moveVector);

    }
}
