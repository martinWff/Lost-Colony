using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehaviour : MonoBehaviour
{
    [SerializeField]Vector3 eulers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(eulers,Space.Self);
    }
}
