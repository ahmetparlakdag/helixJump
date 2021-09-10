using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ballBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public static int comboCounter;
    private bool comboActive = false;
    private static int boostCount = 0;
    public static bool boostActive = false;
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

        if(boostActive)
        {
            if (collision.gameObject.TryGetComponent(out PlatformSlice slice))
            {
                collision.gameObject.transform.parent.gameObject.SetActive(false);
                GameManager.singleton.AddScore(10);
                BoostMode();
                allowNextCollision = false;
                StartCoroutine(nextCollTrigger());
            }
            else
            {
                collision.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
                GameManager.singleton.AddScore(10);
                BoostMode();
                allowNextCollision = false;
                StartCoroutine(nextCollTrigger());
            }
        }

        else if(comboActive)
        {
            if(collision.gameObject.TryGetComponent(out PlatformSlice slice))
            {
                ComboHit(collision.gameObject.transform.parent.gameObject);
                allowNextCollision = false;
                StartCoroutine(nextCollTrigger());
            }
            else
            {
                ComboHit(collision.gameObject.transform.parent.gameObject.transform.parent.gameObject); //hurdle's parent's parent == platform
                allowNextCollision = false;
                StartCoroutine(nextCollTrigger());
            }

        }

        else if (collision.gameObject.TryGetComponent(out PlatformSlice slice))
        {
            if (slice.sliceType == SliceType.Deadly)
            {
                comboCounter = 0;
                jumpEnabler = true;
                PlayerPrefs.SetInt("finalScore", GameManager.singleton.currentScore);
                SceneManager.LoadScene(4);
            }
            else
            {
                BallJump();
            }
        }
        else if(collision.gameObject.transform.parent.gameObject.TryGetComponent(typeof(PlatformSlice), out Component component)) //hurdle touch, restart
        {
            comboCounter = 0;
            jumpEnabler = true;
            PlayerPrefs.SetInt("finalScore", GameManager.singleton.currentScore);
            SceneManager.LoadScene(4);
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
        if(boostActive)
        {
            rb.velocity = new Vector3(0f, -6f, 0f);
        }
    }

    private void BoostMode()
    {
        boostCount++;
        if(boostCount == 2)
        {
            boostActive = false;
            boostCount = 0;
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
