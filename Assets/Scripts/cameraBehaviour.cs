using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{
    public ballBehaviour target;
    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.y - target.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = transform.position;
        camPos.y = target.transform.position.y + offset;
        transform.position = camPos;
    }
}
