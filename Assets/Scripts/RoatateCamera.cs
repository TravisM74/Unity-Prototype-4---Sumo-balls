using System.Collections;

using UnityEngine;

public class RoatateCamera : MonoBehaviour
{

    public float rotationSpeed = 50;
    private float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * rotationSpeed);
        
    }
}
