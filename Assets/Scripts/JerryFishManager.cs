using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryFishManager : MonoBehaviour
{
    [SerializeField] GameObject contineDialogObject;
    [SerializeField] string jerryFishtag = "JerryFish";
    public static JerryFishManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkJerryfishCount()
    {
        GameObject[] jerryFishObjects = GameObject.FindGameObjectsWithTag(jerryFishtag);

        Debug.Log("checkJerryfishCount");
        Debug.Log(jerryFishObjects.Length);

        if ( jerryFishObjects.Length == 1 )
        {
            // show dialog
            contineDialogObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
