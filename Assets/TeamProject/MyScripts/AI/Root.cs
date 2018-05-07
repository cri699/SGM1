using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{

    public string currentAction;

    void Update()
    {
        performAction();
    }

    public void performAction()
    {
        TreeNode action = null;
        foreach (Transform t in transform)
        {
            action = t.GetComponent<TreeNode>().findAction();
            if (action != null)
            {
                break;
            }
        }
        action.GetComponent<TreeAction>().performAction();
        currentAction = action.GetComponent<TreeAction>().actionName();
    }
}
