using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TreeAction : TreeNode {

    public override TreeAction findAction()
    {
        return this;
    }

    public abstract void performAction();
    public abstract string actionName();
}
