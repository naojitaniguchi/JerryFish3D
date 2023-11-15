using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovex : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speedX = 0.1f ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.right * speedX * Time.deltaTime);
    }
}
