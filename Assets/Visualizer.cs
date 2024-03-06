using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class Visualizer : MonoBehaviour
{
    private Mods t = new Mods();
    public TextAsset ta;
    public GameObject point;
    public GameObject backup;
    public GameObject[] parents;
    // Start is called before the first frame update
    void Start()
    {
        t = JsonConvert.DeserializeObject<Mods>(ta.text);
        foreach (Model m in t.biology)
        {
            spawn(m,0);
        }
        foreach (Model m in t.crypto)
        {
            spawnb(m, 1);
        }
        foreach (Model m in t.economics)
        {
            spawn(m, 2);
        }
        foreach (Model m in t.engineering)
        {
            spawn(m, 3);
        }
        foreach (Model m in t.icons)
        {
            spawnb(m, 4);
        }
        changeVis(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeVis(int no) {
        for (int i = 0; i < 5; i++) {
            parents[i].SetActive(i == no);
        }
    }
    private void spawn(Model m,int ti) {
        for (int i = 0; i < m.paths.Length; i++)
        {
            Vector3[] line = m.coalesce(i);
            LineRenderer p = Instantiate(point).GetComponent<LineRenderer>();
            p.positionCount = line.Length-1 ;
            p.SetPositions(line);
            p.gameObject.transform.parent = parents[ti].transform;
        }
    }
    private void spawnb(Model m, int ti)
    {
        for (int i = 0; i < m.paths.Length; i++)
        {
            Vector3[] line = m.coalesce(i);
            foreach (Vector3 v in line)
            {
                GameObject p = Instantiate(backup,v,Quaternion.identity);
                p.transform.parent = parents[ti].transform;
            }
        }
    }
}
