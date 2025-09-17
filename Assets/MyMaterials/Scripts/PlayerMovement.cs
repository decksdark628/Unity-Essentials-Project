using UnityEngine;

public class PlayerMovement : MonoBehaviour{
	public float speed = 5.0f;
	public float rotationSpeed = 120.0f;
	public float jumpForce = 4f;
	private bool canJump = true;

	private Rigidbody rb;
	public Transform ShootDispenser;
	public GameObject Bullet;

	private void Start(){
		rb = GetComponent<Rigidbody>();
	}

	void Update(){
		if (Input.GetButtonDown("Jump") & canJump == true){
			canJump = false;
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
		if (Input.GetMouseButtonDown(0)){
			Instantiate(Bullet, ShootDispenser.transform.position, ShootDispenser.transform.rotation);
			Debug.Log("Bullet");
		}
	}

	private void FixedUpdate(){
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
		rb.MovePosition(rb.position + movement);

		float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
		Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
		rb.MoveRotation(rb.rotation * turnRotation);
	}

	private void OnCollisionEnter(Collision c){
		if (c.collider.CompareTag("Ground")){
			canJump = true;
			Debug.Log("Jump = true");
		}
		Debug.Log("Collision detected");
	}
}
