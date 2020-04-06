using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct levels
{
    [System.Serializable]
    public struct level
    {
        public string[] tanks;
    }

    public level[] levelArray;
}

