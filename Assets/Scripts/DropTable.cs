using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTable
{
    public List<LootDrop> lootList;
}

public class LootDrop
{
    public GameObject Drop { get; private set; }
    public int Weight { get; private set; }

    public LootDrop(GameObject drop, int weight)
    {
        this.Drop = drop;
        this.Weight = weight;
    }
}
