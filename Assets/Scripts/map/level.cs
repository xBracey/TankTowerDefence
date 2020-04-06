using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct levels
{
    [System.Serializable]
    public struct level
    {
        [System.Serializable]
        public struct spawnTank
        {
            public Tanks tankName;
            public int waitTimeAfter;
        }
        public spawnTank[] tanks;
    }

    public level[] levelArray;
}

