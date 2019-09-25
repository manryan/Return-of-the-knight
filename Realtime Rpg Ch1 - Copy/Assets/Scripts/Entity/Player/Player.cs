using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using VIDE_Data; //<--- Import to use easily call VD class


public class Player : Warrior {

    Vector3 localScale;

    public Transform healthbar;

    public int saveIndex;

    public ItemManager itemManager;

    public DamageEntity dEntity;

    public LayerMask itemMask;

    //Inventory System
    //[System.NonSerialized]
    public InventorySystem inventory = new InventorySystem();
    Item tempItem;//For picking up items
    int tempItemCount;
    GameObject tempItemGameobject;


    //Reference to object pool
    public ObjectPoolingManager objPoolManager;

    public void save()
    {
        manager.saveEm();
        id.instance.health = health;
        id.instance.x = transform.root.position.x;
        id.instance.y = transform.root.position.y;
        id.instance.time = DateTime.Now;
        SaveInvo();
        itemManager.saveEm();
        id.instance.SavePlayer(Application.persistentDataPath + "/gamesave.save" + saveIndex);
    }

      public void SaveInvo()
      {
          //string saveInventory = JsonUtility.ToJson(inventory);
          //PlayerPrefs.SetString("PlayerSave" + "IDFILLEDHERE" + "/Inventory", saveInventory);
          inventory.Save();
      }

      public void LoadInvo()
      {
        //string loadInventory = PlayerPrefs.GetString("PlayerSave" + "IDFILLEDHERE" + "/Inventory");
        //inventory = JsonUtility.FromJson<InventorySystem>(loadInventory);
          inventory.Load();
      }

    public void addToInvo(GameObject obj)
    {
        if (inventory.checkIfWeCanAdd(obj.GetComponent<ItemPickup>().item))
        {
            
            objPoolManager.ObjectPoolAddition(obj);
            ItemPickup ip = obj.GetComponent<ItemPickup>();
            tempItem = ip.item;
            tempItemCount = ip.count;
            inventory.Add(tempItem, tempItemCount);
        }
        else
        {
            objPoolManager.DropTable(obj, transform.position);
        }

        /*  tempItemGameobject = obj;

          Debug.Log(tempItemGameobject.name);
          if (tempItemCount <= 0)
          {
              Debug.LogError(tempItemGameobject.name + " item pickup count is 0 or less then");
          }


              objPoolManager.ReturnFromPool(obj);*/


    }

    public void pickUp()
    {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 1f, itemMask);

            for (int i = 0; i < hit.Length; i++)
            {

                    tempItemGameobject = hit[i].gameObject;


             /*   if (hit[i].gameObject.GetComponent<ItemPickup>() == null)
                {
                    Debug.Log(tempItemGameobject.name + "Error, Item Pickup Is not implimented onto this object");
                    continue;
                }
                if (hit[i].gameObject.GetComponent<ItemPickup>().item == null)
                {
                    Debug.Log(tempItemGameobject.name + "Error, The Item in Item Pickup component is null on this prefab object");
                    continue;
                }*/
            if (!inventory.checkIfWeCanAdd(hit[i].GetComponent<ItemPickup>().item))
                continue;

         //   Debug.Log(tempItemGameobject.name);
                objPoolManager.ObjectPoolAddition(tempItemGameobject);
            ItemPickup ip = hit[i].gameObject.GetComponent<ItemPickup>();
                tempItem = ip.item;
                tempItemCount = ip.count;
                if (tempItemCount <= 0)
                {
                    Debug.LogError(tempItemGameobject.name + " item pickup count is 0 or less then");
                }

                inventory.Add(tempItem, tempItemCount);
            textDisplay.Enqueue("Picked Up " + tempItemCount.ToString() + " " + tempItem.name);
            checkIfWeShouldHandle();
    //        objPoolManager.txtboxManager.StartCoroutine(objPoolManager.txtboxManager.setTo("Picked Up " + tempItemCount.ToString() + " "+ tempItem.name));

            }
            //Add to inventoy Here

    }

 /*   public bool checkIfLastWasTheSame(string text)
    {
        return objPoolManager.txtboxManager.checkIfTheLastWasTheSame(text);
    }*/

    public void checkIfWeShouldHandle()
    {
        if (!handlingDisplay)
        {
            handlingDisplay = true;
            StartCoroutine(handleTextDisplay());
        }
    }

    public IEnumerator handleTextDisplay()
    {

        while(textDisplay.Count>0)
        {
            objPoolManager.txtboxManager.StartCoroutine(objPoolManager.txtboxManager.setTo(textDisplay.Peek()));
            textDisplay.Dequeue();
            yield return new WaitForSeconds(0.5f);
        }
        handlingDisplay = false;
    }

    public Queue<string> textDisplay = new Queue<string>();
    public bool handlingDisplay;

    Vector3 movement;

    public EnemyManager manager;

    public Rigidbody2D rb;

    public void setQuest1Active()
    {
        quest1 = true;
    }

    // Update is called once per frame
    void FixedUpdate () {

        Movement();


    }

    public void TakeAway(Item item, int num)
    {
        inventory.Remove(item, num);
        //itemManager.tester.pool.Remove(item.name);
    }

    /*
    public void TakeAway(GameObject item, int num)
    {

        inventory.Remove(item.GetComponent<ItemPickup>().item, num);
        itemManager.tester.pool.Remove(item.name);
    }*/

        public bool checkIfEnough(Item item, int num)
    {
        if (inventory.inventory.Contains(item))
        {
            Item temp = inventory.inventory.Find(x => x.itemName == item.itemName);//.count -= item.count;
            if (temp.count>=num)
                return true;
            else
                return false;
            //  VD.assigned.overrideStartNode = 13;
            //VD.SetNode(10);
            //item.Use();
        }
        else
        {
            return false;
            //  VD.SetNode(11);
        }
    }

  /*  public bool Check(Item item)
    {
        if(inventory.inventory.Contains(item))
        {
            return true;
          //  VD.assigned.overrideStartNode = 13;
            //VD.SetNode(10);
            //item.Use();
        }
        else
        {
            return false;
          //  VD.SetNode(11);
        }

    }*/


public void Start()
    {

        // saveIndex = id.instance.saveIndex;

        anim.SetFloat("rot", Mathf.RoundToInt(transform.GetChild(0).transform.up.x));
        anim.SetFloat("roty", Mathf.RoundToInt(transform.GetChild(0).transform.up.y));

        inventory = new InventorySystem();
        GameManager.instance.playerInventory = inventory;
        objPoolManager = GameManager.instance.objPoolManager;

        if (manager.tester==null)
        {
            manager.initializeEnemies();
            localScale = healthbar.localScale;
        }
        else
        {
            saveIndex = id.instance.saveIndex;
            health = id.instance.health;
            float p = health / maxHealth;
            float userHpBarLength = p * 1f;
            localScale = new Vector3( userHpBarLength, 1, 1);
            healthbar.localScale = localScale;
            transform.parent.position = new Vector3(id.instance.x, id.instance.y);
            manager.StartCoroutine(manager.loadEnemies());
            GameManager.instance.playerInventory = inventory;
            LoadInvo();
        }

        if(itemManager.tester==null)
        {
            itemManager.initializeEnemies();
        }
        else
        {
            itemManager.loadEnemies();
        }
    }

    public void moveDialogue()
    {
        dialogue.GetComponent<RectTransform>().transform.position = new Vector3(0, -10000, 0);
    }

    public void returnDialogue()
    {
        dialogue.GetComponent<RectTransform>().transform.position = new Vector2(dialogue.transform.parent.position.x, 0);
    }

   /* public void wait()
    {
        manager.loadEnemies();
        
    }*/

    public void Update()
    {
     /*   if (Input.GetKeyDown(KeyCode.K))
            Time.timeScale = 0;
        if (Input.GetKeyDown(KeyCode.U))
            Time.timeScale = 1;*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
                Fire();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Time.timeScale != 0)
            {
                if(inTrigger)
                dEntity.Flip(inTrigger.transform);
                TryInteract();
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            pickUp();
        }
        //manager.checkSpot();
    }

    public override void DamageEntity(float Damage)
    {
        base.DamageEntity(Damage);

        if (health > 100f)
            health = 100;

        float p = health / maxHealth;
        float userHpBarLength = p * 1f;
        localScale.x = userHpBarLength;
        healthbar.localScale = localScale;

        //update healthbar for us:) none for enemy

        if (health <= 0)
        {
            health = 0;

            p = health / maxHealth;
            userHpBarLength = p * 1f;
            localScale.x = userHpBarLength;
            healthbar.localScale = localScale;

            damageCol.enabled = false;

            manager.clearEnemies();

            anim.Play("Death Tree");

            //make enemies in enemy manager stop attacking and leave:)

        //disactivate our damage col & maybe navmesh obstacle
        }

    }

    public virtual void Fire()
    {
        if (!dialogue.activeInHierarchy)
            if (canAttack && health>0)
        {
            if (attackState == 0)
            {
                anim.SetBool("attacking", true);
              //  if (movement != Vector3.zero)
                 //   transform.GetChild(0).transform.up = Vector3.zero + movement; 
                attacking = true;
                attackState++;
                StartCoroutine("WeaponCoolDown");
            }
            else if (attackState == 1)
            {
                if (anim.GetBool("attacking") == true)
                {
                    anim.SetBool("Combo", true);
                    attacking = true;
                    canAttack = false;
                    StopCoroutine("WeaponCoolDown");
                    StartCoroutine("ComboCoolDown");
                }
            }

        }
    }

    public void Movement()
    {
        if (health > 0)
        {
            movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (movement != Vector3.zero)
            {
                transform.GetChild(0).transform.up = Vector3.zero + movement;
                anim.SetFloat("rot", Mathf.RoundToInt(transform.GetChild(0).transform.up.x));
                anim.SetFloat("roty", Mathf.RoundToInt(transform.GetChild(0).transform.up.y));
                //   anim.SetFloat("Horizontal", movement.x);
                //   anim.SetFloat("Vertical", movement.y);
            }
            float test = 0.5f;
            if (Input.GetKey(KeyCode.LeftShift))
                test = 1f;
            anim.SetFloat("Blend", Mathf.Clamp(movement.magnitude * test, 0, 1f));

            //if(attacking==false) -> for no movement either normal attack or combo
            //
            //use if (canAttack) for movement with normal attack but none with combo
            if (canAttack)
                rb.MovePosition(new Vector2(transform.parent.position.x + movement.x * Time.deltaTime * 2f * test, transform.parent.position.y + movement.y * Time.deltaTime * 2f * test));
            //   transform.position += (movement * Time.deltaTime * 2f*test);

            // if (movement == Vector3.zero)
            //transform.up = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y) - new Vector2(transform.position.x, transform.position.y);
            // else
            // transform.up = Vector3.zero + movement;
        }
    }

   public IEnumerator ComboCoolDown()
    {
        // yield return new WaitForSeconds(attCoolDown);
        yield return new WaitUntil(() => anim.GetBool("Combo") == false);
        //   yield return new WaitForSeconds(attCoolDown);
        if (anim.GetBool("Combo") == false)
        {
            canAttack = true;
            attackState = 0;
            attacking = false;
        }
    }
}
