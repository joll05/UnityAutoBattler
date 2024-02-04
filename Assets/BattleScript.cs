using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleScript : MonoBehaviour
{
    void Update()
    {
        if (BattleManager.instance.battleActive) BattleUpdate();
    }

    public virtual void BattleUpdate() { }

    private void FixedUpdate()
    {
        if(BattleManager.instance.battleActive) BattleFixedUpdate();
    }

    public virtual void BattleFixedUpdate() { }
}
