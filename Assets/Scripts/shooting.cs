using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour
{

    public float shotsTaken = 0f;
    public Text shotsTakenText;
    public Text shotsTakenTextLevelComplete;
    public Text shotsTakenTextPauseMenu;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public Transform firePoint2;
    public GameObject bulletPrefab2;

    public float bullet1ForceMultiplier;
    public float bullet2ForceMultiplier;

    public float bullet1Force;
    public float bullet2Force;


    public float attackRate = 1f; //this = times you can shoot per second
    private float nextAttackTime = 0f;

    private bool stillFiring = false;
    private bool stillFiring2 = false;

    public PauseMenu GameIsPaused;

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1") || stillFiring == true && GameIsPaused)
            {
                nextAttackTime = Time.time + 1f / attackRate;

                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

                bullet1Force = (mousePosition.x + 6.97f) + ((mousePosition.y + 0.09f) * bullet1ForceMultiplier);

                stillFiring = true;
                shotsTaken++;
                shotsTakenText.text = shotsTaken.ToString();
                shotsTakenTextLevelComplete.text = shotsTakenText.text;
                shotsTakenTextPauseMenu.text = shotsTakenText.text;
                Shoot();
            }

            if (Input.GetButtonDown("Fire2") || stillFiring2 == true && GameIsPaused)
            {
                nextAttackTime = Time.time + 1f / attackRate;

                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

                bullet2Force = (mousePosition.x + 6.97f) + ((mousePosition.y + 0.09f) * bullet2ForceMultiplier);

                stillFiring2 = true;
                shotsTaken++;

                Shoot2();
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            stillFiring = false;
        }

        if (Input.GetButtonUp("Fire2"))
        {
            stillFiring2 = false;
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bullet1Force, ForceMode2D.Impulse);
    }

    void Shoot2()
    {
        GameObject bullet2 = Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet2.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bullet2Force, ForceMode2D.Impulse);
    }

}
