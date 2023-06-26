using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkDemoScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    void Start()
    {
        FireBullets();
    }

    // Update is called once per frame
    void Update()
    {
        //FireBullets();
    }

    private void FireBullets()
    {

        StartCoroutine(CoFireBullets());
    }

    private IEnumerator CoFireBullets()
    {
        GameObject player = ICommon.GetPlayerObject();
        while (player) //when player is still alive
        {
            GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity); //Spawns a bullet and assign it to _bullet

            Rigidbody2D _bullet_rb = _bullet.GetComponent<Rigidbody2D>(); 
            _bullet_rb.velocity = new Vector2(-50, 0); // give the spawned bullet some speed

            yield return new WaitForSeconds(1f); 
        }
        
    }
}
