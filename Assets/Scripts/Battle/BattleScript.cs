using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleScript : MonoBehaviour
{
    void Update()
    {
        if (BattleManager.BattleActive) BattleUpdate();
    }

    public virtual void BattleUpdate() { }

    private void FixedUpdate()
    {
        if(BattleManager.BattleActive) BattleFixedUpdate();
    }

    public virtual void BattleFixedUpdate() { }
}
