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
            slash.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && refresh == false && list[selectedWeapon].type == Arme.Type.Slash)
        {
            refresh = true;
            slashME();
            StartCoroutine(ReloadTime());
        }
        if (Input.GetKeyDown(KeyCode.Space) && refresh == false && list[selectedWeapon].type == Arme.Type.Else)
        {
            refresh = true;
            //Attacks
            StartCoroutine(ReloadTime());
        }
    }
    public void slashME()
    {
        var timer = list[selectedWeapon].reoladTime;
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            print(timer);
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
        public int tamere;

    }
}

