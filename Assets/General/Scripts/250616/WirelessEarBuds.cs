using UnityEngine;

public class WirelessEarBuds : EarBuds
{
    public float battery_size;
    public bool wireless_charging;

    public void Charge()
    {
        if (wireless_charging)
            Debug.Log("Wireless Charging");
        else
            Debug.Log("Wired Charging");
    }
}