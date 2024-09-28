using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private Vector3 movement;
    private Animator _animator; //es una propiedad
    
    [SerializeField]
    private float turnSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
      _animator = GetComponent<Animator>(); //es un metodo  
    }

    // Update is called once per frame
    void Update() //Siempre que quiera que un metodo no dependa de una instancia de la clase, lo hago estatico
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movement.Set(newX: horizontalInput, newY: 0, newZ: verticalInput);
        movement.Normalize();
        
        
        bool hasHorizontalInput = !Mathf.Approximately(horizontalInput, 0);
        bool hasVerticalInput = !Mathf.Approximately(verticalInput, 0);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        
        
        _animator.SetBool("IsWalking", isWalking);
        
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, 
            movement, turnSpeed * Time.deltaTime, 0f);
        
        Quaternion Rotation = Quaternion.LookRotation(desiredForward);
        
    }
}
