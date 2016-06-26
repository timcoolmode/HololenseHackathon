using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour
{
    Animator anim;
    int script1 = Animator.StringToHash("AlertIn");
    int script2 = Animator.StringToHash("AlertUp");
    int script3 = Animator.StringToHash("AlertDownStop");
    int script4 = Animator.StringToHash("AlertUpMove");
    int animId = 0;
    int delay = 0;
    bool isPlaying = false;
    void Start()
    {
        anim = GetComponent<Animator>();
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
            string nameAnim;

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
                    nameAnim = "AlertDownWait";
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
                int hash = Animator.StringToHash(nameAnim);
                anim.SetTrigger(hash);
            }
            // now wait for the anim to finish plus 2 seconds more.
            StartCoroutine(LetsWait(delay));
            }
    }
}