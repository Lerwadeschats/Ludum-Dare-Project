using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class attack : MonoBehaviour
{
    
    public int selectedWeapon = 0;
    public int sgcount = 0;
    public int Cscount = 0;
    public int WallCount = 0;
    public GameObject csAAA;
    public CamShake cam;

    public GameObject slash;
    public TrailRenderer trail;
    public alors ALLORS;
    public Transform bulletsOut;
    
    int timeattact = 0;
    public AudioSource audio;

    public List<Arme> list = new List<Arme>();

    bool refresh = false;

    public InventoryWeapon inventory;

    void Start()
    {
        list[1].isObtained = true;
    }

    // Update is called once per frame
    void Update()
    {
        inventory.weaponUsedID = selectedWeapon;
        AddWeaponToInventory();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedWeapon = 2;
        }
        if (Input.GetMouseButtonDown(0) && refresh == false && list[selectedWeapon].type == Arme.Type.Tire)
        {
            refresh = true;
            for(int i = 1; i <= list[selectedWeapon].bulletShoted; i++)
            {
                var bullets = Instantiate(list[selectedWeapon].bullets);
                bullets.transform.position = bulletsOut.position;
                bullets.GetComponent<DamagesCollision>().damages = list[selectedWeapon].damage;


            }
            StartCoroutine(ReloadTime());
            for(int i = 0; i < list[selectedWeapon].attakSound.Count; i++)
            {
            audio.PlayOneShot(list[selectedWeapon].attakSound[i]);
            }
            cam.time = list[selectedWeapon].timeShake;
        }


        if (Input.GetMouseButtonDown(0) && refresh == false && list[selectedWeapon].type == Arme.Type.Corps)
        {
            refresh = true;
            //Attacks
            StartCoroutine(ReloadTime());
        }


        if (list[selectedWeapon].type == Arme.Type.Slash)
        {
            slash.transform.localRotation = Quaternion.Euler(0, 0, -45);
            ALLORS.enabled = true;
            slash.SetActive(true);
            if(timeattact == 0)
            {
                trail.enabled = false;
            }
        }
        else
        {
            slash.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0) && refresh == false && list[selectedWeapon].type == Arme.Type.Slash)
        {
            ALLORS.enabled = false;
            for (int i = 0; i < list[selectedWeapon].attakSound.Count; i++)
            {
                audio.PlayOneShot(list[selectedWeapon].attakSound[i]);
            }
            refresh = true;
            trail.enabled = true;
            //StartCoroutine(ReloadTime());
        }
        if(refresh && list[selectedWeapon].type == Arme.Type.Slash)
        {
            timeattact += list[selectedWeapon].attackSpeed;
            slash.transform.localRotation = Quaternion.Euler(0, 0, timeattact);
            if(slash.transform.localEulerAngles.z >= list[selectedWeapon].maxAngleAttack - 45)
            {
                ALLORS.enabled = true;
                trail.enabled = false;
                slash.transform.localRotation = Quaternion.Euler(0, 0, -45);
                refresh = false;
                timeattact = 0;
            }
        }


            if (Input.GetKeyDown(KeyCode.Space) && refresh == false && list[selectedWeapon].type == Arme.Type.Else)
        {
            refresh = true;
            //Attacks
            StartCoroutine(ReloadTime());
        }
    }
    public IEnumerator ReloadTime()
    {
        
        yield return new WaitForSeconds(list[selectedWeapon].reoladTime);
        print("qtop");
        refresh = false;
    }

    [System.Serializable]
    public class Arme
    {
        public int ID;
        public string name = "";
        public enum Type { Tire, Corps, Slash, Else };
        public Type type = Type.Corps;
        public Sprite sprite;
        public bool isObtained;
        public bool isAlreadyInInventory;
        [Header("Common")]
        public float reoladTime;
        public float damage;
        [Space]
        public float camshake;
        public float timeShake;
        [Space]
        public List<AudioClip> attakSound;
        [Space]
        [Header("Bullets")]
        public GameObject bullets;
        public int bulletShoted;
        [Tooltip("Should be 0 for snipers ")]
        [Range(0, 45)]
        public float spreadness;
        public float speed;
        public float lifeTime;
        [Space]
        [Header("Slash")]
        [Range(45,90)]
        public int minAngleAttack;
        [Range(90,180)]
        public int maxAngleAttack;
        public int attackSpeed;
    }

    public void AddWeaponToInventory()
    {
        
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].isObtained)
            {
                list[i].isAlreadyInInventory = true;
                list[i].isObtained = false;
            }
        }
    }

    

}

