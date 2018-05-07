using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : TreeNode
{

    public override TreeAction findAction()
    {
        if (!isValid()) return null;

        TreeAction action = null;
        foreach (Transform t in transform)
        {
            TreeNode c = t.GetComponent<TreeNode>();
            action = c.findAction();
            if (action != null) break;
        }
        return action;
    }

    protected abstract bool isValid();
}
