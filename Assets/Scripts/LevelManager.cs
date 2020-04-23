
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager singleton;

    public HashSet<Controller> movable = new HashSet<Controller>();

    private void Awake()
    {
        if (!singleton)
        {
            singleton = this;
        }
    }
}
