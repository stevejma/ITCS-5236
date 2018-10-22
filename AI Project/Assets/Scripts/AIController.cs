﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.AI;

public class AIController : MonoBehaviour {

    private int playerDamage;
    private int enemyDamage;
    private float speed;
    private float radiusOfSat;

    [SerializeField] private Transform target;
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform enemyFlag;
    [SerializeField] private Transform targetFlag;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemyO;

    private NavMeshAgent nav;


	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();
        playerDamage = 25;
        enemyDamage = 25;
        speed = 5f;
        radiusOfSat = 2f;
	}
	
	// Update is called once per frame
	void Update () {
        //Calculate vector from enemy to player
        Vector3 towardsUnits = target.position - enemy.position;
        enemy.rotation = Quaternion.LookRotation(towardsUnits);

        //Calculate vector from target flag to enemy
        Vector3 towardsFlag = targetFlag.position - enemy.position;
        enemy.rotation = Quaternion.LookRotation(towardsFlag);
        nav.SetDestination(target.position);

        if(towardsUnits.magnitude > radiusOfSat)
        {
            Attack();
        }

        if(towardsFlag.magnitude > radiusOfSat)
        {
            GetFlag();
        }
	}
    //
    void Attack()
    {
        playerDamage -= playerDamage;
        if(playerDamage == 0)
        {
            DestroyObject(player);
        }
    }

    void GetFlag()
    {
        
    }
=======

public class AIController : MonoBehaviour {

	private Vector3 targetPosition;
	private Vector3 lookAtTarget;

	private Quaternion playerRotate;

	[SerializeField] private float rotateSpeed = 1f;
	[SerializeField] private float speed = 5f;
	private float radiusOfSat = 2f;
	public GameObject target;
	private bool isMoving = false;

	void Start () {

	}

	void Update() {
                 target = GameObject.Find("Scout");

		// On mouse click unit turns and looks at target
//		if (Input.GetMouseButton(1)) {
//			SetTargetPosition();
//		}


//		if (Input.GetMouseButtonDown(0)) {
		if(Vector3.Distance(target.transform.position, this.transform.position) < 6) {
			ShootGun();
		}

		// Unit also moves to target position when isMoving = true

		if (isMoving) {
			Move();
		}

	}

	void ShootGun() {
	


			GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
			go.transform.position = this.transform.position;
			go.layer = gameObject.layer;
			Rigidbody rb = go.AddComponent<Rigidbody>();
			Vector3 v3T = target.transform.position;
			
					
			
			go.transform.LookAt(v3T);
			rb.AddRelativeForce(Vector3.forward*3000);
		
	}

	void SetTargetPosition() {

		// Raycast to mouse click position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 1000)) {
			targetPosition = hit.point;

			// Unit orients itself so that it rotates itself along the x and z plane but does not unnaturally look up on the y plane
			lookAtTarget = new Vector3(targetPosition.x - transform.position.x,
					transform.position.y,
					targetPosition.z - transform.position.z);
			playerRotate = Quaternion.LookRotation(lookAtTarget);
		}

		// Sets isMoving to true
		isMoving = true;

	}

	void Move() {

		Vector3 towards = targetPosition - transform.position;

		// Adds rotation speed so that unit does not immediately face the mouse click position
		transform.rotation = Quaternion.Slerp(transform.rotation, playerRotate, rotateSpeed * Time.deltaTime);

		// Unit moves towards the target position
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

		// If unit moves to the target position, stop moving
		if (towards.magnitude < radiusOfSat) {
			isMoving = false;
		}

	}

>>>>>>> BrandonAssets
}
