using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBulletController : MonoBehaviour
{
    [Header("Projectile Settings")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject projectilePrefab;

    [Header("Private Variables")]
    private Vector3 startPoint;
    private const float radius = 1;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
        //StartCoroutine(ShootingDelay());
        startPoint = transform.position;
        SpawnProjectile(numberOfProjectiles);
        }
    }

    //Spawns X number of projectiles
    private void SpawnProjectile(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            //Direction calculation of the bullets fired
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180 ) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180 ) * radius;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 ProjectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject tempObj = Instantiate(projectilePrefab, startPoint, Quaternion.identity);
            tempObj.GetComponent<Rigidbody>().velocity = new Vector3(ProjectileMoveDirection.x, 0, ProjectileMoveDirection.y);

            angle += angleStep;
        }
    }

    IEnumerator ShootingDelay()
    {
        bool onDelay = false;
        if(!onDelay)
        {
            SpawnProjectile(numberOfProjectiles);
            yield return new WaitForSecondsRealtime(5);
            onDelay = true;
        }
        SpawnProjectile(numberOfProjectiles);
    }
}
