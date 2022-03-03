using System.Collections;
using UnityEngine;

public class DetectingAnimal : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float radius;
    public GameObject clone;
    private Vector3 dir;
    [SerializeField] float slowDownFactor = 0.05f;
    [SerializeField] float slowDownLength = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        radius = 1.0f;
        // StartCoroutine(Delay());
       // clone = FindObjectOfType<SpawnManager>().instantiatedPrefab;
        //Debug.Log("clone" + clone);
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectAnimal();
        Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
    }

    void DetectAnimal() 
    {
        
        dir = new Vector3(0, -1, 0);
        Vector3 otherPosition = new Vector3(0,-5f,0);
        Debug.DrawRay(transform.position, dir * 10.0f, Color.green);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, dir, out hit, 5.0f)) {
            Debug.Log(hit.transform.tag);
            if (hit.transform.CompareTag("Animal")) 
            {
               FindObjectOfType<SpawnManager>().instantiatedPrefab.transform.SetParent(player.transform);
                FindObjectOfType<SpawnManager>().instantiatedPrefab.transform.position = player.transform.position;
                Debug.Log("parent name" + FindObjectOfType<SpawnManager>().instantiatedPrefab.transform.parent.tag);
                //Debug.Log("parent" + clone.transform.parent);
                Debug.Log("Animal detected");
            }
           
       /* Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            for ( int i = 0; i <= hitColliders.Length - 1; i++)
{
                print(hitColliders[i].gameObject.transform.tag);
            }
           // if (hitCollider.transform.tag == "Animal") 
            //{
              //  Debug.Log("here");
                //FindObjectOfType<GameManager>().addScore();
                
              //  clone.transform.parent = player.transform;
               // if (clone.transform.parent) 
                //{
                  //  Debug.Log("clone has parent now");
                //}
           // }
            Debug.Log("Collider detected" + hitCollider.transform.name);
        }*/
        }
    }

    void SlowMotion() 
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
