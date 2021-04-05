using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagePlayer : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Hurtable")
        {
            SceneManager.LoadScene("SampleScene");
        } else if (hit.gameObject.tag == "Disappearable")
        {
            hit.gameObject.GetComponent<DisappearingBlock>().isDisappearing = true;
        } else if (hit.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
