using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpace : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private Material material;

    private Vector2 offset = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        offset = material.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
