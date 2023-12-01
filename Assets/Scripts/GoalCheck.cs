using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCheck : MonoBehaviour
{
    [SerializeField] string targetTag = "JerryFish";
    [SerializeField] string jerryFishNameA;
    [SerializeField] string jerryFishNameB;
    [SerializeField] string jerryFishNameC;
    [SerializeField] string goalSceneAll3;
    [SerializeField] string goalSceneAB;
    [SerializeField] string goalSceneBC;
    [SerializeField] string goalSceneAC;
    [SerializeField] string goalSceneA;
    [SerializeField] string goalSceneB;
    [SerializeField] string goalSceneC;
    int initialJerryfishNum;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] jerryFishes = GameObject.FindGameObjectsWithTag(targetTag);
        initialJerryfishNum = jerryFishes.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            if ( other.gameObject.GetComponent<JerryFishParameter>() != null )
            {
                other.gameObject.GetComponent<JerryFishParameter>().goaled = true;
            }
            // �J�E���g
            GameObject[] jerryFishes = GameObject.FindGameObjectsWithTag(targetTag);
            int goaled = 0;
            for (int i = 0; i < jerryFishes.Length; i++)
            {
                if (jerryFishes[i].GetComponent<JerryFishParameter>() != null)
                {
                    if (jerryFishes[i].GetComponent<JerryFishParameter>().goaled)
                    {
                        goaled++;
                    }
                }
            }
            if ( goaled == jerryFishes.Length)
            {
                // �S���S�[������
                if (jerryFishes.Length >= 3)
                {
                    SceneManager.LoadScene(goalSceneAll3);
                    // 2�C�S�[������
                }
                else if (jerryFishes.Length == 2)
                {
                    if ((jerryFishes[0].name == jerryFishNameA && jerryFishes[1].name == jerryFishNameB ||
                        jerryFishes[1].name == jerryFishNameA && jerryFishes[0].name == jerryFishNameB))
                    {
                        SceneManager.LoadScene(goalSceneAB);
                    }
                    else if ((jerryFishes[0].name == jerryFishNameB && jerryFishes[1].name == jerryFishNameC ||
                        jerryFishes[1].name == jerryFishNameB && jerryFishes[0].name == jerryFishNameC))
                    {
                        SceneManager.LoadScene(goalSceneBC);
                    }
                    else if ((jerryFishes[0].name == jerryFishNameA && jerryFishes[1].name == jerryFishNameC ||
                        jerryFishes[1].name == jerryFishNameA && jerryFishes[0].name == jerryFishNameC))
                    {
                        SceneManager.LoadScene(goalSceneAC);
                    }
                }else if (jerryFishes.Length == 1)
                {
                    if (jerryFishes[0].name == jerryFishNameA)
                    {
                        SceneManager.LoadScene(goalSceneA);
                    }else if (jerryFishes[0].name == jerryFishNameB)
                    {
                        SceneManager.LoadScene(goalSceneB);
                    }else if (jerryFishes[0].name == jerryFishNameC)
                    {
                        SceneManager.LoadScene(goalSceneC);
                    }
                }
            }
        }
    }

    // �N���Q���Ԃ�������J�E���gup
    // �S�[���̃t���O�𗧂Ă�
    // �c��̃N���Q�̏�Ԃ��`�F�b�N����
    // �S�����S�[����������V�[����J��
    // ���O�ŃV�[����U�蕪����
    // A.B.C
    // A.B. B.C A.C
    // A B C
    // 1,2,3�Ђ��̃V�[���ɐU�蕪����
}
