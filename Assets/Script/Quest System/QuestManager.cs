using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VContainer;

class QuestManager
{
    [Inject]
    public List<Quest> allQuest;

    private List<Quest> activeQuest;

    public QuestManager()
    {
        foreach (var q in allQuest)
        {
            q.OnActivate += OnQuestActivated;
            q.OnResolve += OnQuestResolved;
        }
    }

    public List<Quest> GetActiveQuest()
    {
        return activeQuest;
    }

    public List<Quest> GetAllQuest()
    {
        return allQuest;
    }

    private void OnQuestActivated(Quest quest)
    {
        activeQuest.Add(quest);
    }

    private void OnQuestResolved(Quest quest)
    {
        activeQuest.Remove(quest);
    }
}
