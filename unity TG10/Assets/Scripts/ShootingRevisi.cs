using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingNigger : MonoBehaviour
{
    /*private Vector3 mousePos;*/
    public GameObject bullet;
    public Transform bulletTransform;
    public bool isFire;
    private float timer;
    public float intervalFiring;
    public GameObject Flash;
    [Range(0, 5)]
    public int FramesToFlash = 1;
    public int ammo;
    /*private float timetoreload;*/
    public int currentammo;
    public float timeToReload;
    /*private float timere;*/

    bool reloading = false;
    bool isflashing = false;
    AudioSource suara; 

    private void Start()
    {
        currentammo = ammo;
        suara = GetComponent<AudioSource>();
        Flash.SetActive(false);
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentammo != ammo)
        {
            timere -= Time.deltaTime;
            if(timere <= 0)
            {
                reload();
            }
            reloading = true;
            isFire = false;
            reload();
        }
    }*/

    // Update is called once per frame
    private void FixedUpdate()
    {
        Shooting();
        if (Input.GetKeyDown(KeyCode.R) && currentammo != ammo)
        {

            reloading = true;
            isFire = false;
            Invoke("reload", 2f);
        }
    }
    
    private void Shooting()
    {
        if (!isFire && !reloading)
        {
            timer += Time.deltaTime;
            if (timer > intervalFiring)
            {
                isFire = true;
                timer = 0;
            }
        }
        if (currentammo <= 0)
        {
            isFire = false;
        } else
        {
            if (Input.GetMouseButton(0) && isFire)
            {
                isFire = false;
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
                currentammo--;
                suara.Play();
                Pressing();
                if (!isflashing)
                {
                    StartCoroutine(DoFlash());
                }
            }
        }

    }

    public static bool Pressing()
    {
        if (Input.GetMouseButton(0))
        {
            return true;
        }
        return false;
    }
    IEnumerator DoFlash()
    {
        Flash.SetActive(true);
        var framesFlashed = 0;
        isflashing = true;

        while (framesFlashed <= FramesToFlash)
        {
            framesFlashed++;
            yield return null;
        }
        Flash.SetActive(false);
        isflashing = false;
    }

    void reload()
    {
        currentammo = ammo;
        reloading = false;
        isFire = true;
        /*timere = timeToReload;*/
        /*yield return new WaitForSeconds(timeToReload);*/
    }


}
