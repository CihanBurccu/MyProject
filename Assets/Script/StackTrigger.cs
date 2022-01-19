using UnityEngine;

public class StackTrigger : MonoBehaviour
{

    public int childCount = 0;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Stackable")
        {
            childCount++;
            
            collider.gameObject.transform.position = transform.position - (new Vector3(0, 0, 0.5f) * childCount);
            collider.gameObject.transform.parent = transform;
            collider.gameObject.transform.localScale = new Vector3(1, 1, 1);
            collider.gameObject.GetComponent<Collider>().enabled = false;
        }
    }

}
