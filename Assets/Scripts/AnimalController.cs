using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    Rigidbody animalRb;
    [SerializeField] private float runningSpeed;
    // Start is called before the first frame update
    void Start()
    {
        animalRb = GetComponent<Rigidbody>();
        runningSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveVertical();   
    }

    void MoveVertical()
    {
        animalRb.AddForce(Vector3.forward * runningSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}
