using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryFishPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float jumpPower = 10.0f;
    GameObject clickedGameObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.GetComponent<Rigidbody>().velocity = 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.point);
                clickedGameObject = hit.collider.gameObject;
                Debug.Log(clickedGameObject.name);//�Q�[���I�u�W�F�N�g�̖��O���o��
                Vector3 dir =  clickedGameObject.transform.position - hit.point;
                dir.Normalize();
                dir.z = 0.0f;
                Debug.Log(dir);
                gameObject.GetComponent<Rigidbody>().AddForce(dir * jumpPower);
                // Destroy(clickedGameObject);//�Q�[���I�u�W�F�N�g��j��
            }
        }
    }

    public void onClick()
    {
        Debug.Log("Clicked");
        // gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
    }
}
