using UnityEngine;

public class Cube : MonoBehaviour
{
    private int CubeNumber { get; set; }

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            var otherCube = other.gameObject.GetComponent<Cube>();
            
            if (otherCube.CubeNumber == CubeNumber)
            {
                Destroy(other.gameObject);

                CubeNumber *= 2;
                
                AddForce();
            }
        }
    }

    public void SetNumber(int number)
    {
        CubeNumber = number;
    }

    private void AddForce()
    {
        rb.AddForce(Vector3.up * 3, ForceMode.Impulse);
    }
}