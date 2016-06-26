using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour
{
    public Animation anim;
    int animId = 0;
    public int delay = 0;
    public string nameAnim;
    bool isPlaying = false;

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
                    nameAnim = null;
                    delay = 8;
                    break;
                case 1:
                    nameAnim = "AlertIn";
                    delay = 2;
                    break;
                case 2:
                    nameAnim = "AlertUp";
                    delay = 2;
                    break;
                case 3:
                    //nameAnim = "AlertDownStop";
                    delay = 2;
                    break;
                 case 4:
                    nameAnim = "AlertUpMove";
                    delay = 2;
                    break;
                default:
                    isPlaying = true;
                    return;
            }

            animId++;
            isPlaying = true;

            if (nameAnim != null)
            {
                anim.Play(nameAnim);
            }
            // now wait for the anim to finish plus 2 seconds more.
            StartCoroutine(LetsWait(delay));
        }
    }
}