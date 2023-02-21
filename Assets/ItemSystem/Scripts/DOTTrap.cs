using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DOTTrap : MonoBehaviour
{
    [SerializeField]
    GameObject itemPrefab;
    [SerializeField]
    Sprite icon;

    [SerializeField]
    float rawDamage = 5f;

    [SerializeField]
    string itemName;
    [SerializeField]
    [TextArea(4, 16)]
    string description;

   
    [SerializeField]
    int quantity = 1;

    [SerializeField]
    bool isStorable = false; // if false, item will be used on pickup
    [SerializeField]
    bool isConsumable = false; // if true, item will be destroyed (or quantity reduced) when used

    [SerializeField]
    bool isPickupOnCollision = true;
    // Start is called before the first frame update
    void Start()
    {
        if (isPickupOnCollision)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (isPickupOnCollision)
        {
            if (collider.tag == "Player")
            {
                Interact();
            }
        }
    }

    public void Interact()
    {
        Debug.Log("Picked up " + transform.name);

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
        Debug.Log("Storing " + transform.name);

        // TODO Inventory system

        Destroy(gameObject);
    }

    void Use()
    {
        Debug.Log("taking damage");
        float hitPoints = hitPoints - rawDamage; //add code to apply hitPoint changes to code from HealthManager script
        if (isConsumable)
        {
            quantity--;
            if (quantity <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    
}
