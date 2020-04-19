using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMemoriesCount : MonoBehaviour
{
    public Text memoriesText;
    public CollectibleManager collectiblesManager;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Get().PlaySound("Gameplay");
        CollectibleManager.OnCollectibleGrabbed += UpdateText;
        //UpdateText(true);
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/

    public void UpdateText(bool isPlayerAlive)
    {
        //Debug.Log((collectiblesManager.collectiblesLeft - collectiblesManager.collectiblesAmount));

        memoriesText.text = (collectiblesManager.collectiblesLeft - collectiblesManager.collectiblesAmount) * -1 + 
            "/" + collectiblesManager.collectiblesAmount + " Memories";
    }

    private void OnDestroy()
    {
        CollectibleManager.OnCollectibleGrabbed -= UpdateText;
    }
}
