using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float jumpForce;
    private bool allowNextCollision = true;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    public void ResetPos()
    {
        transform.position = startPos;
    }
    private void nextCollTrigger()
    {
        allowNextCollision = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!allowNextCollision)
        {
            return;
        }
        foreach(ContactPoint contact in collision.contacts)
        {
            if (contact.otherCollider.gameObject == PlatformPass.deadPart)
            {
                GameManager.singleton.RestartLevel();
            }
            else
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * jumpForce);
                allowNextCollision = false;
                Invoke("nextCollTrigger", 0.2f);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
