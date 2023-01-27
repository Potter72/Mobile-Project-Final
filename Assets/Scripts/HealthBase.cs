using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    /// <summary>
    /// HEALTH is a class which all objects with health derive from 
    /// I created this a while back but figured i might as well use it now as its quite versetile
    /// </summary>
    [Header("Health Variables")]
    public int healthValue;
    public int maxHealth;
    public AudioSource damageAudioSource;
    public GameObject bloodSplat;                       //the blood splatter effect that appears when taking damage
    public Renderer[] invulnerabilityBlinkRenderers;    //the renderers that should blink when invulnerabilty is active (mostly applies to player)
    public float additionalKnockBackForce;              //the additional knockbackthis object should take
    public bool isGettingKnockedbacked;                 //bool which tells the code that its being knockbacked (used for example to stop player from moving while being knocked back)
    public float knockbackTime;                         //how long this knockback should happen
    public float invulnerabilityTime;                   //the amount of time the player shouldnt be able to be hit after taking damage;
    private bool isInvulnerable = false;
    public float invulnerabiltyBlinkTime;               //the time between each blink of 
    public Color blinkColor;                            //the color the specified renderers will blink to
    /// <summary>
    /// Take Damage function that is used by all objects who have to deal with health
    /// </summary>
    /// <param name="damage"> the amount of damage </param>
    /// <param name="knockbackSource"> the position from which the knockback should originate </param>
    /// <param name="takeKnockback">  if the object should take knockback  </param>
    /// <param name="knockBackForce"> how much knockback it should take </param>
    public void TakeDamage(int damage, bool takeKnockback, Vector3 knockbackSource, float knockBackForce)
    {
        if (!isInvulnerable) //Can only take damage if object isnt invulnerable
        {
            healthValue -= damage;          //deals the damage

            if (damageAudioSource)          //plays a damage sound clip if one exists
            {
                damageAudioSource.Play();
            }

            if (invulnerabilityTime > 0)    //if object should become invulnerable call the coroutine for that
            {
                StartCoroutine(Invulnerablity());
            }

            //Code for spawning a blood splat
            if (bloodSplat)
            {
                GameObject tempBlood = Instantiate(bloodSplat, transform);
                Destroy(tempBlood, tempBlood.GetComponent<ParticleSystem>().main.duration);
            }

            //Code for knockback
            if ((knockBackForce + additionalKnockBackForce) != 0 && knockbackSource != new Vector3(0, 0, 0) && takeKnockback)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;  //sets the velocity to zero
                if (knockbackSource.x < transform.position.x)       //if knockback source is to the left
                {
                    Vector3 knockbackDirection = Vector3.Normalize(Vector3.right + Vector3.up * 0.5f);  //the knockback is always up and to the side
                    GetComponent<Rigidbody>().AddForce(knockbackDirection * (knockBackForce + additionalKnockBackForce), ForceMode.Impulse);
                }
                if (knockbackSource.x >= transform.position.x)      //if knockback source is to the right
                {
                    Vector3 knockbackDirection = Vector3.Normalize(Vector3.left + Vector3.up * 0.5f);   //the knockback is always up and to the side
                    GetComponent<Rigidbody>().AddForce(knockbackDirection * (knockBackForce + additionalKnockBackForce), ForceMode.Impulse);
                }

                StartCoroutine(GetKnockedBackBool());   //sets a bool which could be used by the scripts derived from Health to do different stuff while the object is taking knockback (ex: player cant move left and right)
            }
        }

        //if the object has 0 health call the ZeroHealth function
        if (healthValue <= 0)
        {
            HasZeroHealth();
        }

        if (healthValue > maxHealth)
        {
            healthValue = maxHealth;
        }

        TookDamage();   //Took damage function which can be overriden by derived scripts to do stuff when taking damage
    }

    //these functions can get overriden by derived classes to do specific things 
    public virtual void HasZeroHealth()
    {
        Destroy(gameObject);
    }
    public virtual void TookDamage()
    {

    }

    /// <summary>
    /// Function for handling the invulneraility and blinking effect when object is invulnerable
    /// </summary>
    IEnumerator Invulnerablity()
    {
        float iFrameCounter = 0;        //the counter who determines when the invulnerabilty ends (iFrame is a common word for this behaviour its not actually counting frames but rather seconds)
        float blinkCounter = 0;         //the counter for blinking
        bool flipBlink = false;         //bool that switches back and forth causing the blinking
        isInvulnerable = true;

        Color[] originalColor = new Color[invulnerabilityBlinkRenderers.Length];    //an array of all the original colors of the renderers that are blinking 
        int colorCounter = 0;
        foreach (Renderer rend in invulnerabilityBlinkRenderers)     //sets the colors in the array of original colors
        {
            originalColor[colorCounter] = rend.material.color;
            colorCounter++;
        }

        while (iFrameCounter <= invulnerabilityTime)
        {
            iFrameCounter += Time.unscaledDeltaTime;
            blinkCounter += Time.unscaledDeltaTime;

            if (invulnerabiltyBlinkTime > 0)     //checks that the time between blinks is more than 0
            {
                if (blinkCounter >= invulnerabiltyBlinkTime)
                {
                    colorCounter = 0;

                    //Every renderer in the blinking renderers array changes color alternating between original and the specified color
                    foreach (Renderer rend in invulnerabilityBlinkRenderers)
                    {
                        if (flipBlink)
                        {
                            rend.material.color = blinkColor;
                        }
                        else
                        {
                            rend.material.color = originalColor[colorCounter];
                        }
                        colorCounter++;
                    }
                    flipBlink = !flipBlink;
                    blinkCounter = 0;
                }

            }

            yield return new WaitForEndOfFrame();
        }

        colorCounter = 0;

        //Resets all the colors to what they originally were
        foreach (Renderer rend in invulnerabilityBlinkRenderers)
        {
            rend.material.color = originalColor[colorCounter];
            colorCounter++;
        }

        isInvulnerable = false;
    }

    /// <summary>
    /// disables the getting knocked back bool after a set time, used for example to make so the player cant input movement for a set time after taking damage
    /// </summary>
    IEnumerator GetKnockedBackBool()
    {
        Debug.Log("SEtting the knocback man");
        isGettingKnockedbacked = true;
        yield return new WaitForSecondsRealtime(knockbackTime);
        isGettingKnockedbacked = false;
    }

}
