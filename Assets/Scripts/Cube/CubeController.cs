using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Rigidbody rb;
    private new Camera camera;

    private const float LaunchForce = 14f;
    
    private bool isHolding = false;

    public event Action cubePushed; 
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isHolding = true;
        }

        if (Input.GetMouseButton(0) && isHolding)
        {
            var mousePosition = Input.mousePosition;
            
            mousePosition.z = camera.WorldToScreenPoint(transform.position).z;

            var worldMousePosition = camera.ScreenToWorldPoint(mousePosition);
            
            transform.position = new Vector3(worldMousePosition.x, transform.position.y, transform.position.z);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Launch();

            cubePushed?.Invoke();
        }
    }

    private void Launch()
    {
        rb.AddForce(new Vector3(0, 0, LaunchForce), ForceMode.Impulse);
        
        isHolding = false;

        enabled = false;
        
        DestroyAllChildren();
    }

    private void DestroyAllChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
