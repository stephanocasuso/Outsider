using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraOffset;
    public float smoothFollow;
    void FollowTarget(){
        Vector3 targetPos = target.position+cameraOffset;
        transform.position = Vector3.Lerp(targetPos,transform.position,Time.deltaTime*smoothFollow);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }
}
