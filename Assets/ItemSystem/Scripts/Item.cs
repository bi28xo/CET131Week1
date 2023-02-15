using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject itemPrefab;
    public Sprite icon;

    public string itemName;
    [TextArea(4, 16)]
    public string description;

    public float weigght = 0;
    public int quantity = 1;
    public int maxStackableQuantity = 1; //for bundles of items like  ammunition or in-game currency

    public bool isStorable = false; //if flase items will be used when picked up
    public bool isConsumable = true; //if true, item will be destroyed (or have quantity reduced) when used

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Picked up" + transform.name);

        if (isStorable)
        {
            Store();
        }
        else
        {
            Use();
        }
    }
    void Store()
    {
        Debug.Log("Storing" + transform.name);
        //ToDo
        Destroy(gameObject);
    }
    void Use()
    {
        if (isConsumable)
        {
            quantity--;
            if (quantity<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
