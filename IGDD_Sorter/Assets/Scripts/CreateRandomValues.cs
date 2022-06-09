using UnityEngine;

public class CreateRandomValues : MonoBehaviour
{
    public GameObject valuePrefab = null;
    public int numberOfValues = 20;
    public int valueMaxHeight = 20;

    void Start() 
    {
        CreateValues();
    }

    void CreateValues()
    {        
        for (int i = 0; i < numberOfValues; i++)
        {
            int randomHeight = Random.Range(1, valueMaxHeight);
            Vector3 valuePosition = new Vector3(i - numberOfValues / 2f, randomHeight - randomHeight / 2f, 0);

            GameObject newValue = Instantiate(valuePrefab, valuePosition, Quaternion.identity);
            newValue.transform.localScale = new Vector3(.7f, randomHeight, 1);

            newValue.transform.parent = this.transform;
        }
    }
}
