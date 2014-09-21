using UnityEngine;
using System.Collections;

public class CharacterControllerMultiplayer : MonoBehaviour {
	public static GameObject character;
	public float speed;
	public float rotationSpeed; 
	public Transform mainCamera;
	public float lookSensitivity = 5f;
	public float lookSmoothDamp = 0.1f;
	public float lookUpAndDownLimit = 60.0f;
	public float lookLeftAndRightLimit = 360.0f;
	public float yRotation, xRotation, currentYRotation, currentXRotation, yRotationV, xRotationV;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (character != null) {
			//yRotation += Input.GetAxis ("Mouse X") * lookSensitivity; 
			//xRotation -= Input.GetAxis ("Mouse Y") * lookSensitivity; 
			//xRotation = Mathf.Clamp (xRotation, -lookUpAndDownLimit, lookUpAndDownLimit); 
			//yRotation = Mathf.Clamp (yRotation, -lookLeftAndRightLimit, lookLeftAndRightLimit); 
			//currentXRotation = Mathf.SmoothDamp (currentXRotation, xRotation, ref xRotationV, lookSmoothDamp); 
			//currentYRotation = Mathf.SmoothDamp (currentYRotation, yRotation, ref yRotationV, lookSmoothDamp); 
			//character.transform.rotation = Quaternion.Euler (currentXRotation, 0, 0); 
			character.transform.Translate (Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime, 0, Input.GetAxis ("Vertical") * speed * Time.deltaTime);
			character.transform.Rotate(Input.GetAxis("Mouse Y") *rotationSpeed* Time.deltaTime ,Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime,0);
		}
		DatabaseCharacter DBchar = (DatabaseCharacter)character.GetComponent(typeof(DatabaseCharacter));
		mainCamera.parent = DBchar.head.transform;
		mainCamera.position = DBchar.head.position;
	}
}
