using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConMeo : MonoBehaviour
{
    private int Diem = 0;
    [SerializeField] private TextMeshProUGUI Text;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            
            Destroy(collision.gameObject);
            Diem++;
            if(Text != null)
                Text.text = "Diem " + Diem;
        }
    }


}
