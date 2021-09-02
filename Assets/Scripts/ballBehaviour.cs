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
        rb.velocity = Vector3.zero;
    }
    private IEnumerator nextCollTrigger()
    {
        yield return new WaitForSeconds(0.2f);
        allowNextCollision = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!allowNextCollision)
        {
            return;
        }

        if (collision.gameObject.TryGetComponent(out PlatformSlice slice))
        {
            if (slice.sliceType == SliceType.Deadly)
            {
                GameManager.singleton.RestartLevel();
            }
            else
            {
                BallJump();
            }
        }
    }

    private void BallJump()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * jumpForce);
        allowNextCollision = false;
        StartCoroutine(nextCollTrigger());
    }
    
}
