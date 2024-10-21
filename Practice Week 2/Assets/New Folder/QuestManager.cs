using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [구현사항 1] 정적 필드 정의
    private static QuestManager instance;

    // [구현사항 2] 정적 프로퍼티 정의
    public static QuestManager Instance
    {
        get
        {
            if (QuestManager.instance == null)
            {
                QuestManager.instance = FindObjectOfType<QuestManager>();
                if (instance == null)
                {
                    GameObject questManager = new GameObject();
                    questManager.AddComponent<QuestManager>();
                    QuestManager.instance=questManager.GetComponent<QuestManager>();
                }
            }
            return instance;
        }
    }

    // [구현사항 3] 인스턴스 검사 로직
    private void Awake()
    {
        if (QuestManager.instance == null) { 
            QuestManager.instance = this;
        }
        else
        {
            Destroy(this);
        }
        
    }
}
