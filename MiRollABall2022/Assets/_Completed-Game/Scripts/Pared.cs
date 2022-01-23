using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ainhoa Izquierdo Arenas

public class Pared : MonoBehaviour
{
    public float size;
    [SerializeField] Transform prefabFuegoPared;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bola"))
        {
            // Instanciamos la explosión.
            Transform fuegoPared = Instantiate(prefabFuegoPared, 
                collision.transform.position, Quaternion.identity);
            Destroy(fuegoPared.gameObject, 1f);
            
            changeScale(-size);

        }
        
    }
    void changeScale(float scaleChange)
    {
        Vector3 change = new Vector3(0, scaleChange, 0);
        transform.localScale += change;
    }
}
