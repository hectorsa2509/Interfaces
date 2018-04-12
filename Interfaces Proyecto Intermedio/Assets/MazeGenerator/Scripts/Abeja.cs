using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//<summary>
//Ball movement controlls and simple third-person-style camera
//</summary>
public class Abeja : MonoBehaviour {

	public GameObject ViewCamera = null;
	public AudioClip JumpSound = null;
	public AudioClip HitSound = null;
	public AudioClip CoinSound = null;

	private Rigidbody mRigidBody = null;
	private AudioSource mAudioSource = null;
	private bool mFloorTouched = false;

	public float rotationSpeed;

	Text guiText;

	void Start () {
		mRigidBody = GetComponent<Rigidbody> ();
		mAudioSource = GetComponent<AudioSource> ();
		guiText=GameObject.Find("elemento").GetComponent<Text>();

	}

	void FixedUpdate () {
		if (mRigidBody != null) {
			if (Input.GetButton ("Horizontal")) {
				mRigidBody.AddForce(Vector3.right*Input.GetAxis("Horizontal")/5, ForceMode.Impulse);
			}
			if (Input.GetButton ("Vertical")) {
				mRigidBody.AddForce(Vector3.forward*Input.GetAxis("Vertical")/5, ForceMode.Impulse);
			}
			if (Input.GetButtonDown("Jump")) {
				if(mAudioSource != null && JumpSound != null){
					mAudioSource.PlayOneShot(JumpSound);
				}
				mRigidBody.AddForce(Vector3.up*50);
			}

			Vector3 dir = Vector3.zero;
			dir.x = -Input.GetAxis ("Horizontal") / 5;
			dir.z = -Input.GetAxis ("Vertical") / 5;

			if (dir != Vector3.zero) {
				transform.rotation = Quaternion.Slerp(
					transform.rotation,
					Quaternion.LookRotation(dir),
					Time.deltaTime * rotationSpeed
				);
			}

		}
		if (ViewCamera != null) {
			Vector3 direction = (Vector3.up*2+Vector3.back)*2;
			RaycastHit hit;
			Debug.DrawLine(transform.position,transform.position+direction,Color.red);
			if(Physics.Linecast(transform.position,transform.position+direction,out hit)){
				ViewCamera.transform.position = hit.point;
			}else{
				ViewCamera.transform.position = transform.position+direction;
			}
			ViewCamera.transform.LookAt(transform.position);
		}
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag.Equals ("Floor")) {
			mFloorTouched = true;
			if (mAudioSource != null && HitSound != null && coll.relativeVelocity.y > .5f) {
				mAudioSource.PlayOneShot (HitSound, coll.relativeVelocity.magnitude);
			}
		} else {
			if (mAudioSource != null && HitSound != null && coll.relativeVelocity.magnitude > 2f) {
				mAudioSource.PlayOneShot (HitSound, coll.relativeVelocity.magnitude);
			}
		}
	}

	void OnCollisionExit(Collision coll){
		if (coll.gameObject.tag.Equals ("Floor")) {
			mFloorTouched = false;
		}
	}

	public GameObject C;

	void Increase(string elem){
		if (elem == null)
			return;

		char[] name = elem.ToCharArray ();
		Data.total++;
		canvas cn = (C.GetComponent<canvas> ());
		if (name [0] == 'O') {
			
			Data.O++;
		} else if (name [0] == 'H') {
			Data.H++;
		} else if (name [0] == 'A') {
			Data.S++;
		} else if (name [0] == 'C' && name [0] == 'l') {
			Data.Cl++;
		} else if (name [0] == 'F') {
			Data.P++;
		} else if (name [0] == 'N') {
			Data.N++;
		} else if (name [0] == 'C' && name [0] == 'a') {
			Data.C++;
		} else if (name [0] == 'S') {
			Data.Na++;
		}
		cn.Elemento (elem);
		if(Data.total==8)
			Application.LoadLevel ("Recoleccion");
	}
		
	void OnTriggerEnter(Collider other) {
		//Si la abeja toca una moneda(8).
		if (other.gameObject.layer.Equals (8)) {
			//StartCoroutine(ShowMessage (other.gameObject.tag, 2));
			Increase (other.gameObject.tag);
			//guiText.text = "Oxígeno";
			if(mAudioSource != null && CoinSound != null){
				mAudioSource.PlayOneShot(CoinSound);
			}

			Destroy(other.gameObject);
		}
		/*
		if (other.gameObject.tag.Equals ("Coin")) {
			StartCoroutine(ShowMessage ("Azufre", 3));
			//guiText.text = "Oxígeno";
			if(mAudioSource != null && CoinSound != null){
				mAudioSource.PlayOneShot(CoinSound);
			}
			Destroy(other.gameObject);
		}
*/
	}

	/* Mostrar texto. */
	IEnumerator ShowMessage (string message, float delay) {
		guiText.text = message;
		guiText.color = Color.red;
		guiText.enabled = true;
		yield return new WaitForSeconds(delay);
		guiText.enabled = false;
	}

	/* Reproducir Audio. */
	/*IEnumerator StartAudio()
	{
		mAudioSource.Play();
		yield return new WaitForSeconds(audio.clip.length);
		mAudioSource.clip = otherClip;
		mAudioSource.Play();
	}*/
}
