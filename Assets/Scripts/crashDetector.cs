using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crashDetector : MonoBehaviour
{

    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSound;
    bool hasCrashed = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<playerController>().disableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            Invoke("headBonk", 0.5f);

        }
    }

    void headBonk()
    {
        SceneManager.LoadScene("Level1");
    }
}
