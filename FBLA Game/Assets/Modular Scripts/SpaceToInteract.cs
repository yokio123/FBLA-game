using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpaceToInteract : MonoBehaviour
{
    [SerializeField] int horizontalRange = 1;
    [SerializeField] int verticalRange = 1;
    [SerializeField] float horizontalOffset = 2;
    [SerializeField] Sprite bgSprite;
    [SerializeField] TMP_FontAsset font;
    GameObject interactTextCanvas;

    public UnityEvent OnInteractEvent;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D collider = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        collider.size = new Vector2(horizontalRange, verticalRange);
        collider.isTrigger = true;

        {
            interactTextCanvas = new GameObject("iToInteractPanel", typeof(RectTransform), typeof(Canvas), typeof(GraphicRaycaster));
            interactTextCanvas.transform.SetParent(transform);
            RectTransform rectTransform = interactTextCanvas.GetComponent(typeof(RectTransform)) as RectTransform;
            rectTransform.transform.SetLocalPositionAndRotation(new Vector3(0, horizontalOffset, 0), new Quaternion());
            rectTransform.sizeDelta = new Vector2(5, 1);
        }
        {
            GameObject text = new GameObject("text", typeof(RectTransform), typeof(CanvasRenderer), typeof(TextMeshPro));
            text.transform.SetParent(interactTextCanvas.transform);
            RectTransform rectTransform = text.GetComponent(typeof(RectTransform)) as RectTransform;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            rectTransform.position = new Vector3(rectTransform.position.x, rectTransform.position.y, -1);
            TextMeshPro tmp = text.GetComponent(typeof(TextMeshPro)) as TextMeshPro;
            tmp.text = "Space To Interact";
            tmp.alignment = TextAlignmentOptions.Center;
            tmp.fontSize = 5;
            tmp.font = font;
        }
        {
            GameObject bg = new GameObject("bg", typeof(RectTransform), typeof(CanvasRenderer), typeof(UnityEngine.UI.Image));
            bg.transform.SetParent(interactTextCanvas.transform);
            RectTransform rectTransform = bg.GetComponent(typeof(RectTransform)) as RectTransform;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            UnityEngine.UI.Image image = bg.GetComponent(typeof(UnityEngine.UI.Image)) as UnityEngine.UI.Image;
            image.sprite = bgSprite;
        }
        interactTextCanvas.active = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter: " + collision.gameObject.name);
        interactTextCanvas.active = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit: " + collision.gameObject.name);
        interactTextCanvas.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactTextCanvas.active && Input.GetKeyDown(KeyCode.Space))
        {
            OnInteractEvent.Invoke();
            Debug.Log("INTERACT!");
        }
    }
}
