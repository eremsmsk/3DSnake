using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hareket : MonoBehaviour
{
    public GameObject kuyruk;
    public GameObject GameOver;
    List<GameObject> kuyruklar;

    Vector3 oncekiKoordinat;
    GameObject oncekiKuyruk;

    float hiz = 30.0f;
    // Start is called before the first frame update
    void Start()
    {

        kuyruklar = new List<GameObject>();

        for (int i = 0; i < 5; i++)
        {
            GameObject yeniKuyruk = Instantiate(kuyruk, transform.position, Quaternion.identity);
            kuyruklar.Add(yeniKuyruk);
        }

        InvokeRepeating("hareketEt", 0.0f, 0.1f);
    }

    void hareketEt()
    {
        oncekiKoordinat = transform.position;

        transform.Translate(0, 0, hiz * Time.deltaTime);

        kuyrukTakip();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="duvar")
        {
            GameOver.SetActive(true);
            Time.timeScale = 0.0f;
        }

        if (other.gameObject.tag == "kuyruk")
        {
            GameOver.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");
    }

    public void kuyrukAttir()
    {
        GameObject yeniKuyruk = Instantiate(kuyruk, transform.position, Quaternion.identity);
        kuyruklar.Add(yeniKuyruk);
    }

    void kuyrukTakip()
    {
        kuyruklar[0].transform.position = oncekiKoordinat;
        oncekiKuyruk = kuyruklar[0];
        kuyruklar.RemoveAt(0);
        kuyruklar.Add(oncekiKuyruk);
    }

    public void dondur(float aci)
    {
        transform.Rotate(0, aci, 0);
    }
}
