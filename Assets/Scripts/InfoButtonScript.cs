using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class InfoButtonScript : MonoBehaviour {

    HashSet<GameObject> uiSet = new HashSet<GameObject>();
    public GameObject targets;

	public void ToggleInfoPanels()
    {
        if (uiSet.Count == 0)
        {
            foreach (Transform child in targets.transform)
            {
                Debug.Log("Child: "+child.ToString());
                var ui = child.Find("InfoUI");
                if (ui != null)
                {
                    uiSet.Add(ui.gameObject);
                }
            }
        }

        bool active = uiSet.Any(g => !g.activeSelf);

        foreach (GameObject ui in uiSet)
        {
            ui.SetActive(active);
        }
    }
}
