using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

	private Vector3 targetPosition;
	private Vector3 lookAtTarget;

	private Quaternion playerRotate;

	private GUIStyle guiStyle = new GUIStyle();

	[SerializeField] private float rotateSpeed = 1f;
	[SerializeField] private float speed = 5f;
	private float radiusOfSat = 2f;

	private bool isMoving = false;

	bool displayMessage;
	string message = "You Won! You're Great!";
	void Start () {

	}

	void Update() {

		// On mouse click unit turns and looks at target
		if (Input.GetMouseButton(1)) {
			SetTargetPosition();
		}

		if (Input.GetMouseButtonDown(0)) {
			ShootGun();
		}

		// Unit also moves to target position when isMoving = true

		if (isMoving) {
			Move();
		}
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name == "FlagB") {
			other.transform.parent = this.transform;
		}

		if(other.gameObject.name == "FlagR") {
			displayMessage = true;
		}
	}

	void ShootGun() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 1000)) {


			GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
			go.transform.position = this.transform.position;
			go.layer = gameObject.layer;
			Rigidbody rb = go.AddComponent<Rigidbody>();
			Vector3 v3T = hit.point;
			
			go.transform.LookAt(v3T);
			rb.AddRelativeForce(Vector3.forward*3000);
		}
		
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

	void OnGUI() {

		guiStyle.fontSize = 72;
		if(displayMessage) {
			GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), message);
		}
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

}
