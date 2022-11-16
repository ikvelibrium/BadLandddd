using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    void Start()
    {
        
    }

   
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = player.position.x;
        transform.position = newPosition;
    }
}
