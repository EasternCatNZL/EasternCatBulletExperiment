﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demarcation : MonoBehaviour {

    [Header("Timing Vars")]
    [Tooltip("Time Between Sprays")]
    public float timeBetweenSprays = 1.5f;
    [Tooltip("Time between waves")]
    public float timeBetweenWaves = 0.8f;

    [Header("Bullet Vars")]
    [Tooltip("Bullet Object")]
    public GameObject bulletObject;
    [Tooltip("Number of bullet layers")]
    public int numBulletLayers = 2;
    [Tooltip("Number of bullet waves")]
    public int numBulletWaves = 3;

    [Header("Bullet set up vars")]
    [Tooltip("Bullet base setup distance")]
    public float bulletBaseSetupDistance = 0.5f;
    [Tooltip("Bullet step distance increase value")]
    public float bulletStepDistanceIncrease = 0.5f;
    [Tooltip("Bullet setup move time")]
    public float bulletSetupTime = 0.5f;
    [Tooltip("Bullet active move start time")]
    public float bulletStartMoveTimeDelay = 0.2f;
    [Tooltip("Bullet angle change")]
    public float bulletAngleChange = 90.0f;

    [Header("Angle Control")]
    [Tooltip("Angle change per shot in spray")]
    public float angleChangePerShot = 1.0f;
    [Tooltip("Positive or negative (1 or -1)")]
    [Range(-1, 1)]
    public float rotationDirection = 1.0f;

    //control vars
    private float timeLastSprayFired = 0.0f; //the time last spray began
    private float currentAngleTotal = 0.0f; //the current angle the bullet is angled at in regards to owner

    // Use this for initialization
    void Start () {
        //StartCoroutine(BulletSprayRoutine());
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > timeLastSprayFired + timeBetweenSprays)
        {
            StartCoroutine(BulletSprayRoutine());
        }
    }

    //bullet firing coroutine
    private IEnumerator BulletSprayRoutine()
    {
        //set time of last spray to now
        timeLastSprayFired = Time.time;

        //for each waves
        for (int i = 0; i < numBulletWaves; i++)
        {
            //get a random starting angle
            float angle = Random.Range(0.0f, 360.0f);
            //for each wave
            for (int j = 0; j < numBulletLayers; j++)
            {
                
                //reset current angle total between bullet rings
                currentAngleTotal = 0.0f;
                //while current angle total not reached 360, keep spawning bullets
                while (currentAngleTotal < 360.0f)
                {
                    //create a shot
                    //get the current angle as a quaternion
                    Quaternion currentRotation = new Quaternion();
                    currentRotation.eulerAngles = new Vector3(0.0f, angle, 0.0f);
                    //create a bullet clone, and orient it using the current angle
                    GameObject bulletClone = Instantiate(bulletObject, transform.position, currentRotation);

                    //get distance to travel forward for setup based on layer
                    float distanceToSetup = bulletBaseSetupDistance + (bulletStepDistanceIncrease * j);

                    //set up first bullet variables
                    bulletClone.GetComponent<SetupStraightBullet>().SetupVars(distanceToSetup, bulletSetupTime, bulletSetupTime + bulletStartMoveTimeDelay, bulletAngleChange);

                    //create second shot
                    //get the current angle as a quaternion
                    currentRotation.eulerAngles = new Vector3(0.0f, angle, 0.0f);
                    //create a bullet clone, and orient it using the current angle
                    GameObject bulletCloneTwo = Instantiate(bulletObject, transform.position, currentRotation);

                    //get distance to travel forward for setup based on layer
                    distanceToSetup = bulletBaseSetupDistance + (bulletStepDistanceIncrease * j);

                    //set up second bullet variables <- angle change negative of first
                    bulletClone.GetComponent<SetupStraightBullet>().SetupVars(distanceToSetup, bulletSetupTime, bulletSetupTime + bulletStartMoveTimeDelay, -bulletAngleChange);

                    //change the angle between shots
                    angle += angleChangePerShot;
                    //add the amount angle changed to current angle total
                    currentAngleTotal += angleChangePerShot;
                }
            }

            //wait between waves
            yield return new WaitForSecondsRealtime(timeBetweenWaves);
        }
    }
}