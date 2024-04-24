using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicOtherSprite : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;

    void Start()
    {
        Mimic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        Mimic();
    }

    void Mimic(){
        //Get the sprite renderer of the target
        SpriteRenderer targetSpriteRenderer = target.GetComponent<SpriteRenderer>();
        
        //Get the size of the target sprite
        Vector3 targetSize = target.transform.localScale;

        //Get the position of the target sprite and rotation
        Vector3 targetPosition = target.transform.position;
        Vector3 targetRotation = target.transform.eulerAngles;

        //Set the size of the sprite to the target size
        gameObject.transform.localScale = targetSize;

        //Set the position of the sprite to the target position
        gameObject.transform.position = targetPosition;

        //Set the rotation of the sprite to the target rotation
        gameObject.transform.eulerAngles = targetRotation;
    }
}
