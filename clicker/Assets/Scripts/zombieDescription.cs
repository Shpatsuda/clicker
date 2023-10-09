using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class zombieDescription : MonoBehaviour
{
    public float Speed = 1f;
    private float StopDistance = 1.3f;
    private Vector2 LastRotation;
    private Transform W1zardo; // Reference to the target character's transform.
    private Rigidbody2D Zumbis;

    private void Start()
    {
        W1zardo = FindObjectOfType<mainCharacter>().transform;
        Zumbis = this.GetComponent<Rigidbody2D>();
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
        float TargetDistance = Vector2.Distance(transform.position, W1zardo.position);

        if (TargetDistance > StopDistance)
        {
           // transform.Translate(Vector2.down * Speed * Time.deltaTime, Space.Self);
           
           Zumbis.velocity = transform.TransformDirection(Vector2.down) * Speed * Time.deltaTime * 100;
           
        }
        
        if (TargetDistance <= StopDistance)
        {
            Zumbis.velocity = new Vector2(0,0);
        }

        //Look at target.        
        if (LastRotation != moveDirection)
        {
            transform.rotation = Quaternion.FromToRotation(Vector2.down, moveDirection);
        }
        LastRotation = moveDirection;
    }
}
