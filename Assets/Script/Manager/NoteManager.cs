using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currenTime = 0d;

    [SerializeField] Transform tfNoteAppcar = null;
    [SerializeField] GameObject goNote = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currenTime += Time.deltaTime;

        if(currenTime >= 60d / bpm)
        {
            GameObject t_note = Instantiate(goNote, tfNoteAppcar.position, Quaternion.identity);
            t_note.transform.SetParent(this.transform);
            currenTime -= 60d / bpm;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            Destroy(collision.gameObject);
        }
    }
}
