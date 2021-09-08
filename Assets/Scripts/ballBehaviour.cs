using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public static int comboCounter;
    private bool comboActive;
    [SerializeField] private float jumpForce;
    private bool allowNextCollision = true;
    private Vector3 startPos;
    public static bool jumpEnabler = true;


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

        if(comboActive)
        {
            if(collision.gameObject.TryGetComponent(out PlatformSlice slice))
            {
                ComboHit(collision.gameObject.transform.parent.gameObject);
            }
            else
            {
                ComboHit(collision.gameObject.transform.parent.gameObject.transform.parent.gameObject); //hurdle's parent's parent == platform
            }

        }

        else if (collision.gameObject.TryGetComponent(out PlatformSlice slice))
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
        else if(collision.gameObject.transform.parent.gameObject.TryGetComponent(typeof(PlatformSlice), out Component component)) //hurdle touch, restart
        {
            GameManager.singleton.RestartLevel();
        }
    }

    private void BallJump()
    {
        if(jumpEnabler)
        {
            comboCounter = 0;
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce);
            allowNextCollision = false;
            StartCoroutine(nextCollTrigger());
        }
    }


    void Update()
    {
        if (comboCounter > 2)
        {
            comboActive = true;
        }
        
    }

    private void ComboHit(GameObject Platform)
    {
        Platform.SetActive(false);  //ComboJump
        GameManager.singleton.AddScore(comboCounter * 10);
        comboActive = false;
        jumpEnabler = true;
        BallJump();
        comboCounter = 0;
    }

}
