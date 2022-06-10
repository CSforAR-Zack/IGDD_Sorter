using UnityEngine;

public class CreateRandomValues : MonoBehaviour
{
    /// <summary>
    /// Class for creating new random values.
    /// </summary>

    public GameObject valuePrefab = null;
    public int numberOfValues = 10;
    public int valueMaxHeight = 20;

    public void CreateValues()
    {
        /// <summary>
        /// Method <c>CreateValues</c> generates a new set of values.
        /// </summary>

        // Delete children, first item will be this object.
        Transform[] transforms = this.GetComponentsInChildren<Transform>();

        for (int i = 1; i < transforms.Length; i++)
        {
            Destroy(transforms[i].gameObject);
        }

        // Generate the values with random heights
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
