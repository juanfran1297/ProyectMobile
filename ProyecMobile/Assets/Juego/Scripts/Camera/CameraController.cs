using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public bool flip = false;

    Animator camAnim;

    Quaternion originalRotation;
    Quaternion flipRotation;
    // Update is called once per frame

    private void Start()
    {
        camAnim = GetComponent<Animator>();
    }
    void Update()
    {
        originalRotation = new Quaternion(target.transform.rotation.x, target.transform.rotation.y, target.transform.rotation.z, target.transform.rotation.w);
        flipRotation = new Quaternion(target.transform.rotation.x, target.transform.rotation.y, target.transform.rotation.z + 180, target.transform.rotation.w);

        if (flip == false)
        {
            transform.LookAt(target);
            transform.position = new Vector3(target.transform.position.x + 6, target.transform.position.y + 1, transform.position.z);
            transform.rotation = originalRotation;
        }
        else
        {
            transform.LookAt(target);
            transform.position = new Vector3(target.transform.position.x + 6, target.transform.position.y + 1, transform.position.z);

            transform.rotation = flipRotation;
        }
    }

    public void CambioFlip()
    {
        flip = !flip;

        if (flip == true)
        {
            camAnim.SetBool("Rotation", true);
        }
        else
        {
            camAnim.SetBool("Rotation", false);
        }

        StartCoroutine(RotationScreen());
    }

    IEnumerator RotationScreen()
    {
        yield return new WaitForSeconds(1.3f);
    }
}
