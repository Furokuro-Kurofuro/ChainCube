using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private CubeVisualConfigSO visualConfigSo;
    
    private int CubeNumber { get; set; }

    private Rigidbody rb;
    private MeshRenderer mr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
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
                
                SetMaterial(CubeNumber, visualConfigSo);
                
                AddForce();
            }
        }
    }

    public void Initialize(int number, CubeVisualConfigSO visualConfigSo)
    {
        this.visualConfigSo = visualConfigSo;
        
        SetNumber(number);
        SetMaterial(number, visualConfigSo);
    }
    
    private void SetNumber(int number)
    {
        CubeNumber = number;
    }

    private void SetMaterial(int number, CubeVisualConfigSO visualConfigSo)
    {
        mr.material = visualConfigSo.GetMaterial(number);
    }

    private void AddForce()
    {
        rb.AddForce(Vector3.up * 3, ForceMode.Impulse);
    }
}