using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    public attack attack;
    public float speeed;
    public float lifeTime;
    private void Awake()
    {
        attack = FindObjectOfType<attack>();
        transform.eulerAngles = new Vector3(0, 0, Random.Range(-attack.list[attack.selectedWeapon].spreadness, attack.list[attack.selectedWeapon].spreadness) + attack.bulletsOut.eulerAngles.z); 
        speeed = attack.list[attack.selectedWeapon].speed + Random.Range(-.1f, .1f);
        lifeTime = attack.list[attack.selectedWeapon].lifeTime;
        StartCoroutine(LifeTime());
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.TransformDirection(new Vector3(-(speeed)/ 100, 0, 0));
    }

    public IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
