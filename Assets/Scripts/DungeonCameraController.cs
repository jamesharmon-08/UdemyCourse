using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCameraController : MonoBehaviour
{
    public static DungeonCameraController instance;
    public Vector3 targetPoint;

    public float moveSpeed;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        targetPoint.z = transform.position.z;    
    }

    // Update is called once per frame
    void LateUpdate()
    {   
        transform.position = Vector3.MoveTowards(transform.position,targetPoint,moveSpeed*Time.deltaTime);    
    }



}
