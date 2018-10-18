using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
