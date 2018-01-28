using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    private Renderer scroll;
    [SerializeField]
    private float scrollSpeed = 0.1f;

    private Vector2 currentOffset;
    private Vector2 diffOffset;
    private Vector3 currentPosition;
    private Vector3 diffPosition;

    // Use this for initialization
    void Start()
    {
        currentPosition = scroll.transform.position;
        currentOffset = scroll.material.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        // Diff the change in position
        diffPosition = scroll.transform.position - currentPosition;

        // Diff the offset
        diffOffset.x = diffPosition.x * scrollSpeed;
        diffOffset.y = diffPosition.y * scrollSpeed;

        // Update the current offset
        currentOffset.x = Mathf.Repeat(currentOffset.x + diffOffset.x, 1f);
        currentOffset.y = Mathf.Repeat(currentOffset.y + diffOffset.y, 1f);
        scroll.material.mainTextureOffset = currentOffset;
        currentPosition = scroll.transform.position;
    }
}
