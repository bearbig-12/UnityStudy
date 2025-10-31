using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRock : MonoBehaviour
{
    [SerializeField] private GameObject _SkyRock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.CompareTo("Tank") == 0)
        {
            _SkyRock.GetComponent<MeshRenderer>().enabled = true;
            _SkyRock.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
