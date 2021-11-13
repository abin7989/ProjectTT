using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class ShippingAddress
{
    public string address;
    public string npcName;

    public ShippingAddress(string _npcName, string _address)
    {
        npcName = _npcName;
        address = _address;
    }
}
public class JsonMaker : MonoBehaviour
{
    public List<ShippingAddress> shipping = new List<ShippingAddress>();
    // Start is called before the first frame update
    void Start()
    {
        shipping.Add(new ShippingAddress("NPC1","ȣ����� 101-1"));
        shipping.Add(new ShippingAddress("NPC2", "ȣ����� 102"));
        shipping.Add(new ShippingAddress("NPC3", "ȣ����� 103-4"));
        shipping.Add(new ShippingAddress("NPC4", "ȣ����� 104-1"));

        JsonData addressJson = JsonMapper.ToJson(shipping);
        File.WriteAllText(Application.dataPath+ "/Json/ShippingAddress.json",
            addressJson.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
