using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPass : MonoBehaviour
{
    [SerializeField] private int passScore;
    [SerializeField] private Material dead;
    [SerializeField] private GameObject[] platformArray = new GameObject[8];
    public static GameObject deadPart;
    private int platformChooser;
    private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.AddScore(passScore);
    }
    void Start()
    {
        platformChooser = Random.Range(0, 8);
        Destroy(platformArray[platformChooser]);
        platformArray[platformChooser] = platformArray[7];
        platformChooser = Random.Range(0, 7);
        platformArray[platformChooser].GetComponent<MeshRenderer>().material = dead;
        deadPart = platformArray[platformChooser];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
