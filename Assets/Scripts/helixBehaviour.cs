using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helixBehaviour : MonoBehaviour
{
    public float rotateSpeed;
    private float moveX;
    private Quaternion startRot;

    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.rotation;
    }

    public void ResetRotation()
    {
        transform.rotation = startRot;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Mouse X");
        if(Input.GetMouseButton(0))
        {
            transform.Rotate(0f, -rotateSpeed * moveX, 0f);
        }
    }
}
