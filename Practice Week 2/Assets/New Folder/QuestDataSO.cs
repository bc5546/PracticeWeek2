using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuestDataSO : ScriptableObject
{
    public string QuestName;

    public int QuestRequiredLevel;

    public int QuestNPC;

    public List<int> QuestPrerequisites;

    public int QuestID;
}