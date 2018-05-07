using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingMechanic : MonoBehaviour {
    private Animator anim;
    private InformationMessage im;

    private AudioSource source;
    private CustomAudioManager amscript;
    // Use this for initialization
    void Start () {
        im = GameObject.FindGameObjectWithTag("message").GetComponent<InformationMessage>();
        GetComponent<customCharController>().OnDie += HandleDying;
       anim = GetComponent<Animator>();

        source = GetComponent<AudioSource>();
        amscript = GameObject.Find("AudioManagerCust").GetComponent<CustomAudioManager>();
    }

    void HandleDying()
    {
        amscript.playDie(source);//audio
        anim.SetTrigger("death");
        Dissapear();
        im.DisplayMessage(this.tag + " Has Diededed!");
        PlayersFollow cameraScript = Camera.main.GetComponent<PlayersFollow>();
        if(cameraScript.playerNumber > 1)
        {
            cameraScript.RemovePlayer(this.gameObject);
            
            
        }
    }
    IEnumerator Dissapear()
    {
        
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }
}
