using UnityEngine;

public abstract class MonsterBaseState 
{

    public abstract void EnterState(MonsterState monster);

    public abstract void UpdateState(MonsterState monster);

    public abstract void ExitState(MonsterState monster);

}
