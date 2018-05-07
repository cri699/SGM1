using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour//, IItem
{
    public Sprite _Image = null;
    public string Name
    {
        get
        {
            return "Axe";
        }
    }

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }
}
