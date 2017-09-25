using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SetupStraightBullet : MonoBehaviour {

    public float travelSpeed;

    //set up vars
    private Vector3 setupDestination = new Vector3(0, 0, 0);
    private float setupDestinationDistance = 0.0f;
    private float setupTime = 0.0f;
    private float startDelay = 0.0f;
    private float angleChange = 0.0f;

    //control vars
    private float startTime = 0.0f;
    private bool isStarting = false;
    private bool isReady = false;

    private Rigidbody myRigid;

    // Use this for initialization
    void Start () {
        myRigid = GetComponent<Rigidbody>();
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (isStarting)
        {
            SetUp();
        }
	}

    //sets up vars for bullet behaviour
    public void SetupVars(float dist , float setTime, float delay, float angle)
    {
        setupDestinationDistance = dist;
        setupTime = setTime;
        startDelay = delay;
        angle = angleChange;
        isStarting = true;
    }

    //func called when setup ready
    private void SetUp()
    {
        isStarting = false;
        transform.DOMove(setupDestination, setupTime, false);
        StartCoroutine(BeginMove());
    }

    private IEnumerator BeginMove()
    {
        yield return new WaitForSecondsRealtime(startDelay);
        transform.Rotate(transform.up, angleChange);
        myRigid.velocity = transform.forward * travelSpeed;
    }
}
