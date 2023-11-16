using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryFishClicker : MonoBehaviour
{
    [SerializeField] float jumpPower = 10.0f;
    [SerializeField] string targetTag = "JerryFish";
    GameObject clickedGameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                // Debug.Log(hit.point);
                clickedGameObject = hit.collider.gameObject;
                if (clickedGameObject.tag == targetTag ) 
                {
                    // Debug.Log(clickedGameObject.name);//ゲームオブジェクトの名前を出力
                    Vector3 dir = clickedGameObject.transform.position - hit.point;
                    dir.Normalize();
                    dir.z = 0.0f;
                    if ( clickedGameObject.GetComponent<Rigidbody>() != null )
                    {
                        if ( clickedGameObject.GetComponent<JerryFishParameter>() != null )
                        {
                            clickedGameObject.GetComponent<Rigidbody>().AddForce(dir * clickedGameObject.GetComponent<JerryFishParameter>().jumpPower);
                        }
                        else
                        {
                            clickedGameObject.GetComponent<Rigidbody>().AddForce(dir * jumpPower);
                        }
                        
                    }
                }
            }
        }
    }
}
