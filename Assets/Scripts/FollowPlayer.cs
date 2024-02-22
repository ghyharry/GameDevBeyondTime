using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset = new Vector3(-4.43f, 2.12f, -10);
    // Update is called once per frame
    //LateUpdate is called after Update.
    void LateUpdate()
    {

        //Offset the camera behind the player's position.
        transform.position = player.transform.position + offset;
    }
}
