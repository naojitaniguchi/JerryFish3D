using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    [SerializeField] string targetTag = "JerryFish";
    [SerializeField] GameObject jerryFishDestroyEffect;
    [SerializeField] AudioClip dieSound;

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

                    // Animation‚ÌTrigger‚ðˆø‚­
                    if (collision.gameObject.GetComponent<Animator>() != null)
                    {
                        collision.gameObject.GetComponent<Animator>().SetTrigger("Die");
                        if ( dieSound != null)
                        {
                            if (collision.gameObject.GetComponent<AudioSource>() != null)
                            {
                                collision.gameObject.GetComponent<AudioSource>().PlayOneShot(dieSound);
                            }
                        }
                    }

                    // Destroy(collision.gameObject);

                    
                    //JerryFishManager.instance.checkJerryfishCount();

                }
            }
        }
    }
}
