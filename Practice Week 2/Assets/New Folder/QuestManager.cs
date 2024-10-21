using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [�������� 1] ���� �ʵ� ����
    private static QuestManager instance;

    // [�������� 2] ���� ������Ƽ ����
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

    // [�������� 3] �ν��Ͻ� �˻� ����
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
