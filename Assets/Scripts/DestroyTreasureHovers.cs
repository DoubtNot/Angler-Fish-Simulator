using UnityEngine;

public class DestroyTreasureHovers : MonoBehaviour
{
    private GameObject treasureBoat;
    private GameObject treasureFishBarrel;
    private GameObject treasureShovel;

    public void DestroyAllTreasureBoats()
    {
        treasureBoat = GameObject.Find("TreasureBoat(Clone)");
        Destroy(treasureBoat);
    }
    public void DestroyAllTreasureFishBarrel()
    {
        treasureFishBarrel = GameObject.Find("TreasureFishBarrel(Clone)");
        Destroy(treasureFishBarrel);
    }
    public void DestroyAllTreasureShovel()
    {
        treasureShovel = GameObject.Find("TreasureShovel(Clone)");
        Destroy(treasureShovel);
    }
}
