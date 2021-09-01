using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> upgradeList;

    public DropTable DropTable { get; private set; }
    private void Start()
    {
        DropTable = new DropTable();

        DropTable.lootList = new List<LootDrop>
        {
            new LootDrop(upgradeList[0], 4), //shield
            new LootDrop(upgradeList[1], 3), //weapon
            new LootDrop(upgradeList[2], 2), //laser
        };
    }

    public GameObject DropItem()
    {
        int randomNumber = Random.Range(0, 101);
        Debug.Log(randomNumber);
        int weightSum = 0;
        foreach(LootDrop item in DropTable.lootList)
        {
            weightSum += item.Weight;
            if(randomNumber < weightSum)
            {
                return item.Drop;
            }
        }
       
        return null;
    }
}


