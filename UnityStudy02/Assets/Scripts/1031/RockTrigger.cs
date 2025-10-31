using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrigger : MonoBehaviour
{
	[SerializeField] private GameObject[] _DropLocks;
	[SerializeField] private Camera _mainCamera;

	Vector3 changeCameraPos = new Vector3(-10.28f, 12.79f, 0.04f);
	Vector3 changeRotate = new Vector3(90.0f, 0.0f, 0.0f);

	Vector3 orginCameraPos;
	Vector3 originCameraRotate;

	// Start is called before the first frame update
	void Start()
	{
		orginCameraPos = _mainCamera.transform.position;
		originCameraRotate = _mainCamera.transform.rotation.eulerAngles;

		this.GetComponent<MeshRenderer>().enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Contains("Tank"))
		{
			Camera.main.GetComponent<CameraMove>().Stop(true);
			_mainCamera.transform.position = changeCameraPos;
			_mainCamera.transform.rotation = Quaternion.Euler(changeRotate);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag.Contains("Tank"))
		{
			foreach (var obj in _DropLocks)
			{
				//obj.GetComponent<Rigidbody>().useGravity = true;
				obj.GetComponent<HeavyRock>().Drop();
			}
		}

		Invoke("changeOriginCamera", 2.0f);
	}


	void changeOriginCamera()
	{
		Camera.main.GetComponent<CameraMove>().Stop(false);
		_mainCamera.transform.position = orginCameraPos;
		_mainCamera.transform.rotation = Quaternion.Euler(originCameraRotate);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
