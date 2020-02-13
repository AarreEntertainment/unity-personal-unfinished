using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forkliftname : MonoBehaviour
{
    string firstletters()
    {
        switch (Random.Range(0, 10))
        {
            case 0:
                return "Sp";
            case 1:
                return "P";
            case 2:
                return "Shm";
            case 3:
                return "Fl";
            case 4:
                return "Gl";
            case 5:
                return "Bl";
            case 6:
                return "Gn";
            case 7:
                return "M";
            case 8:
                return "Z";
            default:
                return "f";
        }
    }

    string secondletters()
    {
        switch (Random.Range(0, 10))
        {
            case 0:
                return "s";
            case 1:
                return "n";
            case 2:
                return "m";
            case 3:
                return "b";
            case 4:
                return "g";
            case 5:
                return "j";
            case 6:
                return "sh";
            case 7:
                return "r";
            case 8:
                return "d";
            default:
                return "l";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = firstletters() + "ork" + secondletters() + "ift";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
