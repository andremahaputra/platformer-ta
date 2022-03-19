using UnityEngine;



[CreateAssetMenu(fileName = "Kill Monster Quest", menuName = "ScriptableObject/Quest")]
public class KillQuest : Quest
{
    public override event ActivateDelegate OnActivate;
    public override event ResolveDelegate OnResolve;

    public override void Activate()
    {
        this.OnActivate?.Invoke(this);
    }

    public override void Resolve()
    {
        if (CheckCondition())
        {
            this.OnResolve?.Invoke(this);
        }
    }

    private bool CheckCondition()
    {
        return false;
    }

}

public class EnemyData { }
