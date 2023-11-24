using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    [SerializeField] string targetTag = "JerryFish";
    [SerializeField] GameObject jerryFishDestroyEffect;

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
        Debug.Log("hit !!!");
        if (collision.gameObject.tag == targetTag)
        {
            Debug.Log("hit !!!" + collision.gameObject.tag);
            if ( collision.gameObject.GetComponent<JerryFishParameter>() != null )
            {
                collision.gameObject.GetComponent<JerryFishParameter>().life--;
                if (collision.gameObject.GetComponent<JerryFishParameter>().life <= 0)
                {
                    if ( jerryFishDestroyEffect != null)
                    {
                        GameObject effect = Instantiate(jerryFishDestroyEffect);
                        effect.transform.position = collision.transform.position;
                        effect.transform.rotation = Quaternion.identity;
                    }

                    Destroy(collision.gameObject);

                    JerryFishManager.instance.checkJerryfishCount();

                }
            }
        }
    }
}
