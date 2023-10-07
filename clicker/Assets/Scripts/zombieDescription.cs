using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class zombieDescription : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float Speed = 1f;
    private Transform W1zardo; // Reference to the target character's transform.

    private void Start()
    {
        W1zardo = FindObjectOfType<mainCharacter>().transform;
    }

    private void Update()
    {
        if (W1zardo == null)
        {
            // If the target is null, do nothing.
            return;
        }

        // Move the character towards the target.
        Vector2 moveDirection = (W1zardo.position - transform.position).normalized;
        transform.Translate(moveDirection * Speed * Time.deltaTime);
        
    }
}
