using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{

    public TMPro.TextMeshProUGUI txtScore;
    int score = 0;

    hareket kuyrukSayisi;

    private void Start()
    {
        kuyrukSayisi = GameObject.Find("bas").GetComponent<hareket>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "bas")
        {
            score += 10;
            txtScore.text = "SKOR " + score;

            koorDegis();
            kuyrukSayisi.kuyrukAttir();
        }

        if (other.gameObject.tag =="kuyruk")
        {
            koorDegis();
        }

    }

    void koorDegis()
    {
        float x = Random.Range(-12.5f, 12.5f);
        float z = Random.Range(-5.5f, 8.5f);

        transform.position = new Vector3(x, -1.5f, z);

    }
}
