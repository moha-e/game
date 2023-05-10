using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crachtershooting : MonoBehaviour
{
   // Damage damage=new Damage();
    [SerializeField] private Transform AKM;
    [SerializeField] private LayerMask shootablelayer;
    [SerializeField] private GameObject explosionParticlePrefab;
    float health = 100f;


    private void Update()
    {
       if(Input.GetMouseButtonDown(0)) 
        {
            RaycastHit AKMHit;
            

            if(Physics.Raycast(AKM.position,AKM.forward,out AKMHit,35,shootablelayer)) 
            {
                
                health-=25;
                if(health == 0) 
                { 
                    Destroy(AKMHit.collider.gameObject);
                    Instantiate(explosionParticlePrefab,AKMHit.point, Quaternion.identity);
                    health = 100f;
                }
            }
        } 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(AKM.position,AKM.forward *35);
    }

}
