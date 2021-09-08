using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helixBehaviour : MonoBehaviour
{
    public float rotateSpeed;
    private float moveX;
    private Quaternion startRot;
    [SerializeField] private PlatformPass[] helixPlatforms;

    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.rotation;
    }

    public void recreatePlatforms()
    {
        for (var i = 0; i < helixPlatforms.Length; i++)
        {
            helixPlatforms[i].gameObject.SetActive(true);
        }
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
