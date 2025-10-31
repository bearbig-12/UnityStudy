using TMPro.EditorUtilities;
using UnityEngine;

public class DynamicInstanceTest : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _cubeParent;


    // Start is called before the first frame update
    void Start()
    {
        CreateInstance1();

	}

    void CreateInstance1()
    {        
        for(int i = 0; i < 100; i++) {
			Vector2 pos = Random.insideUnitCircle * 10;

            Vector3 pos2 = new Vector3(pos.x + _cubeParent.position.x, 0.0f, pos.y + _cubeParent.position.z);
			var obj = Instantiate(_prefab, pos2, Quaternion.identity, _cubeParent);

            obj.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
		}

	}

	void CreateInstance2()
	{
		for (int i = 0; i < 1000; i++)
		{
			Vector3 pos = Random.insideUnitSphere * 10;			
			var obj = Instantiate(_prefab, pos, Quaternion.identity, _cubeParent);
			obj.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
		}

	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
