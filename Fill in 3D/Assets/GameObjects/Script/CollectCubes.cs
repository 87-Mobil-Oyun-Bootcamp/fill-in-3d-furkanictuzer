using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCubes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
            
            if (other.gameObject.CompareTag("InteractiveBlock"))
            {
                gameObject.GetComponent<SphereCollider>().enabled = false;
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
                other.transform.position = Vector3.Lerp(other.transform.position, transform.parent.position, 1);
                new WaitForSeconds(1);
                gameObject.GetComponentInParent<MeshRenderer>().enabled = true;
                Destroy(other);

            }
        
    }

}
