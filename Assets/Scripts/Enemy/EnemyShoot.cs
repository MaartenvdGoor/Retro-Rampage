using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public FollowRadius FollowRadius;

    private static AudioSource audioSource;

    public GameObject bullet;
    public Transform bulletPos;

    private Weapon currentWeapon;
    private float timer;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentWeapon = new Weapon(0.5f, WeaponType.SMG);
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 17.3)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, distance, LayerMask.GetMask("Wall"));

            if (hit.collider == null || hit.collider.CompareTag("Player"))
            {
                timer += Time.deltaTime;

                if (timer > 2)
                {
                    timer = 0;
                    shoot();
                }
            }
        }
    }

    void shoot()
    {
        if (FollowRadius.canFollowPlayer)
        {
            audioSource.Play();
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }

}
