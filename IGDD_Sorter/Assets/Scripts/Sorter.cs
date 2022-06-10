using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorter : MonoBehaviour
{
    public float delay = .1f;

    public Material[] mats = null;

    public void StartSort()
    {
        Transform[] transforms = this.GetComponentsInChildren<Transform>();
        List<Transform> childTransforms = new List<Transform>();

        for (int i = 1; i < transforms.Length; i++)
        {
            childTransforms.Add(transforms[i]);
        }

        StartCoroutine(BubbleSort(childTransforms));
    }

    IEnumerator BubbleSort(List<Transform> values)
    {
        bool done = false;
        int sorted = 0;

        while (!done)
        {
            UpdateValues(values);
            yield return new WaitForSeconds(delay);

            done = true;
            for (int k = 0; k < values.Count - sorted - 1; k++)
            {
                SetColor(values[k], 2);
                SetColor(values[k + 1], 3);
                if (k > 0)
                    SetColor(values[k - 1], 0);            
                UpdateValues(values);
                yield return new WaitForSeconds(delay);

                if (values[k].localScale.y > values[k + 1].localScale.y)
                {
                    Swap(values, k, k + 1);
                    done = false;
                }
                UpdateValues(values);
                yield return new WaitForSeconds(delay);
            }
            sorted++;
            SetColor(values[values.Count - sorted], 1);
            if (values.Count - sorted > 0)
                SetColor(values[values.Count - sorted - 1], 0);
        }
        UpdateValues(values);
        yield return new WaitForSeconds(delay);

        if (sorted < values.Count)
        {
            for (int i = 0; i < values.Count - sorted; i++)
            {
                SetColor(values[i], 1);
            }            
            UpdateValues(values);
        }
    }

    void Swap(List<Transform> unsortedValues, int k, int v)
    {
        Transform temp = unsortedValues[k];
        unsortedValues[k] = unsortedValues[v];
        unsortedValues[v] = temp;
    }

    void UpdateValues(List<Transform> values)
    {
        for (int i = 0; i < values.Count; i++)
        {
            Vector3 newPosition = new Vector3(i - values.Count / 2f, values[i].position.y, values[i].position.z);

            values[i].transform.position = newPosition;
        }
    }

    void SetColor(Transform value, int materialIndex)
    {
        value.GetComponent<Renderer>().material = mats[materialIndex];
    }
}
