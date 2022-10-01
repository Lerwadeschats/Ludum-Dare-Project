using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class attack : MonoBehaviour
{
    
    public int selectedWeapon = 0;

    public CamShake cam;
    public GameObject slash;
    public Transform bulletsOut;
    int timeattact = 0;
    public AudioSource audio;

    public List<Arme> list = new List<Arme>();

    bool refresh = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && refresh == false && list[selectedWeapon].type == Arme.Type.Tire)
        {
            refresh = true;
            for(int i = 1; i <= list[selectedWeapon].bulletShoted; i++)
            {
                var bullets = Instantiate(list[selectedWeapon].bullets);
                bullets.transform.position = bulletsOut.position;
                bullets.GetComponent<DamagesCollision>().damages = list[selectedWeapon].damage;


            }
            StartCoroutine(ReloadTime());
            audio.PlayOneShot(list[selectedWeapon].attakSound);
            cam.time = list[selectedWeapon].timeShake;
        }


        if (Input.GetKeyDown(KeyCode.Space) && refresh == false && list[selectedWeapon].type == Arme.Type.Corps)
        {
            refresh = true;
            //Attacks
            StartCoroutine(ReloadTime());
        }

        if (list[selectedWeapon].type == Arme.Type.Slash)
        {
            //print("slash");
            slash.SetActive(true);
            if(timeattact == 0)
            {
                slash.transform.eulerAngles = new Vector3(0,0, list[selectedWeapon].minAngleAttack + transform.eulerAngles.z);
                slash.GetComponent<SlashCollision>().damages = list[selectedWeapon].damage;
            }
        }
        else
        {
            //print("UNNNNNslash");
            slash.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && refresh == false && list[selectedWeapon].type == Arme.Type.Slash)
        {
            refresh = true;
            
            //StartCoroutine(ReloadTime());
        }
        if(refresh && list[selectedWeapon].type == Arme.Type.Slash)
        {

            timeattact += list[selectedWeapon].attackSpeed;
            print(timeattact);
            slash.transform.localRotation = Quaternion.Euler(0, 0, timeattact);
            //slash.transform.localEulerAngles += new Vector3(0, 0, slash.transform.localRotation.eulerAngles.z + list[selectedWeapon].attackSpeed);
            //slash.transform.localEulerAngles += new Vector3(0, 0, list[selectedWeapon].attackSpeed);
            if(slash.transform.localEulerAngles.z >= list[selectedWeapon].maxAngleAttack)
            {
                print("TOURE");
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
        refresh = false;
    }

    [System.Serializable]
    public class Arme
    {
        public string name = "";
        public enum Type { Tire, Corps, Slash, Else };
        public Type type = Type.Corps;
        [Header("Common")]
        public float reoladTime;
        public float damage;
        [Space]
        public float camshake;
        public float timeShake;
        [Space]
        public AudioClip attakSound;
        
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

   
}

