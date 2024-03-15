using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Security.Cryptography.X509Certificates;

public class Move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField]
    public float v;
    public Rigidbody player;
    public Transform cameraPosition;
    public GameManager gameManager;

    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothDirection;
    public float smoothing;

    public void OnDrag(PointerEventData eventData)
    {
        var currentPosition = eventData.position;
        var directionRaw = currentPosition - origin;
        direction = directionRaw.normalized;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        origin = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction = Vector2.zero;
    }

    private void Awake()
    {
        direction = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (gameManager.GameActive)
        {
            player.velocity += new Vector3(direction.x * 1.5f, 0f, direction.y * 1.5f);

            player.velocity -= player.velocity / 6;

            player.transform.position += new Vector3(0f, 0f, 1f * v);
            cameraPosition.position += new Vector3(0f, 0f, 1f * v);
        }
    }
}
