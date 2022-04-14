using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Collider bCollider;
    public ParticleSystem electricity;
    public ParticleSystem electricity2;
    public BoxCollider wall;
    public Material nodeHeadMaterial;
    public List<GameObject> headObjects;

    [SerializeField]
    public GameObject generator;

    [SerializeField]
    private ParticleSystem explode;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("boink");
            StartCoroutine(Delete());
        }
    }

    IEnumerator Delete()
    {
        Destroy(bCollider);
        Destroy(generator);
        explode.Play();
        yield return new WaitForSeconds(2);

    }

    private void Update()
    {
        if(generator == null)
        {
            Destroy(wall);
            Destroy(electricity);
            Destroy(electricity2);
            foreach(GameObject go in headObjects)
            {
                go.GetComponent<Renderer>().material = nodeHeadMaterial;
            }
        }
    }


}
