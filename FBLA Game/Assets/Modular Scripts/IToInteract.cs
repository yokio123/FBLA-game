using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IToInteract : MonoBehaviour
{
    [SerializeField] int horizontalRange = 1;
    [SerializeField] int verticalRange = 1;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = gameObject.transform.position;


        BoxCollider2D collider = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        collider.size = new Vector2(horizontalRange, verticalRange);
        collider.isTrigger = true;

        SpriteRenderer spriteRenderer = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter: " + collision.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit: " + collision.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
