using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private Camera fpsCam;

    private float timeToFire = 0f;

    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private  GameObject impact;

    private Animator wepAnimator;

    [SerializeField] AudioSource source;
    [SerializeField] AudioClip gunShot;

    private void Start() {
        wepAnimator = GetComponent<Animator>();
    }
    
    private void Update(){
        if(Input.GetButtonDown("Fire1") && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1f/fireRate;
            Shoot();
            PlayAudio();

            if(wepAnimator != null){
                wepAnimator.SetBool("Firing", true);
            }
        }else{
            wepAnimator.SetBool("Firing", false);
        }
    }

    private void Shoot(){
        muzzleFlash.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            
            TargetController target = hit.transform.GetComponent<TargetController>();

            if(target != null){
                target.TakeDamage(damage);
            }

            GameObject impactGameObject = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGameObject, 0.5f);
        }
    }

    private void PlayAudio(){
        source.clip = gunShot;
        source.Play();
    }

}
