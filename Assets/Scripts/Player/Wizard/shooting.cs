using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    bool invOpen;
    private Inventory inventory;

    private int[] power = new int[3] { 0, 0, 0 };
    private int[] projectilesnmbr = new int[3] { 0, 0, 0 };
    private float[] degrees = new float[7] { 0, 10, -10, 20, -20, 30, -30 };
    private float cooldown = 1.0f;
    private float cooldownTimer = 0.0f;
    private int[] range = new int[3] { 0, 0, 0 };

    public int powerTot;
    public int projectilesnmbrTot;
    public int rangeTot;
    private void Start()
    {
        invOpen = false;
    }
    void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        // Get the position of the mouse in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Calculate the direction from the player to the mouse
        Vector3 shootDirection = (mousePos - transform.position).normalized;


        if (Input.GetKeyDown("c"))
        {
            invOpen = !invOpen;
        }

        // If the player clicks the mouse button, shoot a projectile
        if (!IsPointerOverUIElement() && Input.GetMouseButtonDown(0))
        {
            if (cooldownTimer <= 0.0f)
            {
                ShootProjectile(shootDirection);
                cooldownTimer = cooldown;
            }
        }

        if (cooldownTimer > 0.0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        bool IsPointerOverUIElement()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.name == "InventoryPanel")
                {
                    return true;
                }
                else if (result.gameObject.name == "StavUI")
                {
                    return true;
                }
            }
            return false;
        }

        for (int i = 0; i < 3; i++)
        {
            string gameObjectName = "slot" + i;
            GameObject slotObject = GameObject.Find(gameObjectName);
            if (slotObject != null)
            {
                UIItem uiItem = slotObject.GetComponentInChildren<UIItem>();

                if (uiItem != null && uiItem.spriteImage != null)
                {
                    string spriteName = uiItem.spriteImage.sprite.name;

                    Item item = inventory.CheckForItem(spriteName); // Use the CheckForItem method to get the corresponding Item
                    if (item != null && uiItem.GetComponentInChildren<Image>().color != Color.clear)
                    {

                        foreach (KeyValuePair<string, int> kvp in item.stats)
                        {

                            if (kvp.Key == "Power")
                            {
                                power[i] = kvp.Value;
                            }


                            if (kvp.Key == "Range")
                            {
                                range[i] = kvp.Value;
                            }

                            if (kvp.Key == "Projectiles")
                            {
                                projectilesnmbr[i] = kvp.Value;
                            }

                        }

                    }
                    else
                    {
                        power[i] = 0;
                        range[i] = 0;
                        projectilesnmbr[i] = 0;
                        //Debug.Log(gameObjectName + " sprite name does not correspond to any Item in the Inventory.");
                    }
                }
                else
                {
                    // Debug.Log(gameObjectName + " does not have a UIItem component or a sprite assigned.");
                }
            }
            else
            {
                // Debug.Log(gameObjectName + " not found.");
            }
        }
        powerTot = power[0] + power[1] + power[2];
        rangeTot = range[0] + range[1] + range[2];
        projectilesnmbrTot = projectilesnmbr[0] + projectilesnmbr[1] + projectilesnmbr[2] + 1;
    }

    void ShootProjectile(Vector3 direction)
    {


        for (int i = 0; i < projectilesnmbrTot; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.transform.parent = this.transform;

            // Calculate the rotation angle for this projectile
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + i * 100f;

            // Rotate the projectile to face the calculated angle
            projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Set the velocity of the projectile
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            projectile.GetComponent<Projectile>().duration += rangeTot;
            projectile.GetComponent<projectiledamage>().damage += powerTot;

            Vector2 rotatedDirection = Quaternion.Euler(0, 0, degrees[i]) * direction;
            rb.velocity = rotatedDirection * projectileSpeed;

        }
        Debug.Log("total added power: " + powerTot);
        Debug.Log("total added range: " + rangeTot);


    }
}
