using UnityEngine;
using System.Collections;

public class AnimateMiniMap : MonoBehaviour
{
    public Animation anim;
    int animId = 0;
    public float delay = 0;
    public string nameAnim;
    bool isPlaying = false;
    public bool buttonpressed = false;

    void Start()
    {
        if (this.anim == null)
        {
            anim = GetComponent<Animation>();
        }
    }

    IEnumerator LetsWait(float secsToWait)
    {
        yield return new WaitForSeconds(secsToWait);  // we wait here (not exactly actually)...

        // done waiting... now update the playing flag to go for the next animation.
        isPlaying = false;
    }

    public void buttonPress() {
        buttonpressed = true;
    }


   
    void Update()
    {
        if (!isPlaying)  // nothing playing? let's play something...
        {
            if (anim.isPlaying)
            {
                return;
            }

            switch (animId)
            {
                case 0:
                    delay = 11;
                    break;
                case 1:
                    nameAnim = "Minimap";
                    delay = 1;
                    break;
                case 2:
                    // nameAnim = "MiniMapStay";
                    nameAnim = null;
                    delay = 0;
                    break;
                case 3:
                    if (!buttonpressed)
                        return;
                    nameAnim = "MinimapGo";
                    delay = 2;
                    break;
                default:
                    isPlaying = true;
                    return;
            }

            animId++;
            isPlaying = true;
            /*
            if (nameAnim != null)
            {
                anim.Play(nameAnim);
            }
            // now wait for the anim to finish plus 2 seconds more.
            StartCoroutine(LetsWait(delay));
            */
        }
    }
}