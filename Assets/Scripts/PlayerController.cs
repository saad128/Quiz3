using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject animal;
    public float jumpForce = 50f;
    private float alongXAxis = -5;
    private float alongYAxis = 5;

    public float gravityModifier;
    public bool isOnAnimal = true;
   

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        animal = GameObject.Find("Animal 1");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement(jumpForce);
    }

    public void PlayerMovement(float speed)
    {
        PlayerJump(alongXAxis, alongYAxis);
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

    }

    void PlayerJump(float forceAtX, float forceAtY)
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnAnimal)
        {
            animal.transform.parent = null;
            playerRb.AddForce(forceAtX, forceAtY, 0, ForceMode.Impulse);
            isOnAnimal = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Animal1"))
        {
            isOnAnimal = true;
            animal.transform.parent = null;
        }
    }

   
    
}
