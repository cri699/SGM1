using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 100;
    private ParticleSystem _psystem;

    [SerializeField] private GameObject log;

    private AudioSource source;
    private CustomAudioManager amscript;

    void Awake(){
        _psystem = GetComponent<ParticleSystem>();

        source = GetComponent<AudioSource>();
        amscript = GameObject.Find("AudioManagerCust").GetComponent<CustomAudioManager>();
    }
	public void TakeDamage(float amount)
    {
        amscript.playTreeHitSounds(source);
        _psystem.Play();
        health -= amount;
        if (health <= 0)
        {
            int rand = Random.Range(1, 4);
            for (int i = 0; i < rand; i++)
            {
                float randx = Random.Range(-2, 2);
                float randz = Random.Range(-2, 2);
                float yRot = Random.Range(0, 180);
                Vector3 newPos = new Vector3(randx + transform.position.x, transform.position.y, randz + transform.position.z);
                Instantiate(log, newPos, Quaternion.Euler(90, yRot, 0));
              }
            Destroy();
        }
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
