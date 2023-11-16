using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceObject : MonoBehaviour
{
    public Transform dirPosition;
    [SerializeField] string targetTag = "JerryFish";
    [SerializeField] float force = 500.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == targetTag )
        {
            if ( dirPosition != null )
            {
                Vector3 dir = dirPosition.position - gameObject.transform.position;
                dir.Normalize();
                if ( collision.gameObject.GetComponent<Rigidbody>() != null )
                {
                    collision.gameObject.GetComponent<Rigidbody>().AddForce(dir *  force);
                }
            }
        }
    }
}
