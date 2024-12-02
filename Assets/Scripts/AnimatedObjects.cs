using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedObjects : MonoBehaviour
{
    public GameObject cloud1, cloud2, cloud3, cloud4, cloud5;
    public float cloud1Speed, cloud2Speed, cloud3Speed, cloud4Speed, cloud5Speed;
    public Vector2 cloud1Pos, cloud2Pos, cloud3Pos, cloud4Pos, cloud5Pos;

    void Start()
    {
        cloud1Speed = 0.7f;
        cloud2Speed = 1.4f;
        cloud3Speed = 1.7f;
        cloud4Speed = 1f;
        cloud5Speed = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        cloud1.transform.Translate(Vector3.right * cloud1Speed * Time.deltaTime);
        cloud2.transform.Translate(Vector3.right * cloud2Speed * Time.deltaTime);
        cloud3.transform.Translate(Vector3.right * cloud3Speed * Time.deltaTime);
        cloud4.transform.Translate(Vector3.right * cloud4Speed * Time.deltaTime);
        cloud5.transform.Translate(Vector3.right * cloud5Speed * Time.deltaTime);

        cloud1Pos = cloud1.transform.position;
        cloud2Pos = cloud2.transform.position;
        cloud3Pos = cloud3.transform.position;
        cloud4Pos = cloud4.transform.position;
        cloud5Pos = cloud5.transform.position;

        if (cloud1Pos.x > 80)
        {
            cloud1.transform.position = new Vector2(-65, 30f);
        }
        if (cloud2Pos.x > 80)
        {
            cloud2.transform.position = new Vector2(-70, 27f);
        }
        if (cloud3Pos.x > 80)
        {
            cloud3.transform.position = new Vector2(-80, 25f);
        }
        if (cloud4Pos.x > 80)
        {
            cloud4.transform.position = new Vector2(-69, 23f);
        }
        if (cloud5Pos.x > 80)
        {
            cloud5.transform.position = new Vector2(6, 18.8f);
        }
    }
}
