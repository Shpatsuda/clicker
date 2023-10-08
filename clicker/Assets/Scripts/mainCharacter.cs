using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class mainCharacter : MonoBehaviour
{
    private Transform CurrentTarget;
    private GameObject[] Zumbisi;
    private Vector2 LastRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Zumbisi = GameObject.FindGameObjectsWithTag("Zumbis");
        FindNearestZumbis();

        //Look at target.
        Vector2 LookDirection = (CurrentTarget.position - transform.position).normalized;
        if (LastRotation != LookDirection)
        {
            transform.rotation = Quaternion.FromToRotation(Vector2.up, LookDirection);
        }
        LastRotation = LookDirection;
    }
    void FindNearestZumbis()
    {
        float DistanceToTarget;
        float NearestDistanceToTarget = 1000f;

        for (int i = 0; i < Zumbisi.Length; i++)
        {
            DistanceToTarget = Vector2.Distance(transform.position, Zumbisi[i].transform.position);
            if (DistanceToTarget < NearestDistanceToTarget)
            {
                CurrentTarget = Zumbisi[i].transform;
                NearestDistanceToTarget = DistanceToTarget;
            }
        }
    }
}
