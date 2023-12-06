using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCotrol : MonoBehaviour
{
    [SerializeField] float lifeTime;
    [SerializeField] Camera cam;
    ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clicked()
    {
        var mousePos = Input.mousePosition;
        var screenPos = new Vector3(mousePos.x, mousePos.y, 5f);
        // ワールド座標に変換  
        var worldPos = cam.ScreenToWorldPoint(screenPos);
        // 3Dオブジェクトの座標に代入  
        transform.localPosition = worldPos;

        particle.Play(true);

        StartCoroutine(StopParticle());

    }

    IEnumerator StopParticle()
    {

        //3秒停止
        yield return new WaitForSeconds(lifeTime);

        particle.Stop();
    }
}
