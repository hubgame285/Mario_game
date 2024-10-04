using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((isRight ? Vector3.right : Vector3.left) * Time.deltaTime * 5f);
    }
    public void setIsRight(bool isRight)
    {
        this.isRight = isRight;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "trai")
        {
            //huy dan
            Destroy(gameObject);
            var name = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
        }
        if(collision.gameObject.tag == "nen")
        {
            //huy dan
            Destroy(gameObject);
        }
    }
}
