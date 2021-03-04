using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [Space]
    [SerializeField]
    private Sprite image;
    Texture2D texture2D;

    [Space]
    [SerializeField]
    private GameObject cube;

    
    public float size = .1f;

    [Space]
    [SerializeField]
    private Transform interactCubePos;

    [Space]
    [SerializeField]
    private GameObject interactCube;

    [Space]
    [SerializeField]
    private GameObject plate;

    public int spawnedCube = 0;



    Vector3 cubePos = Vector3.zero;
    Vector3 interactCubePosition = Vector3.zero;

    private void Awake()
    {
        texture2D = image.texture;
        Color color ;

        spawnedCube = texture2D.width * texture2D.height;
        for (int x = 0; x < texture2D.width; x++)
        {
            for (int y = 0; y < texture2D.height; y++)
            {
                color = texture2D.GetPixel(x, y);

                if (color.a == 0)
                {
                    spawnedCube--;
                    continue;
                }
                //Küpleri spawnladığımız kısım
                cubePos = new Vector3(size * (x - (texture2D.width * .5f)), size * .5f, size * (y - (texture2D.height * .5f)));
                GameObject cubeObj = Instantiate(cube, transform);
                cubeObj.transform.localPosition = cubePos;
                cubeObj.GetComponent<Renderer>().material.color = color;
                cubeObj.transform.localScale = new Vector3(1f,.2f,1f) * size;
                cubeObj.GetComponent<MeshRenderer>().enabled = false;

                //tabanları spawnladığımız kısım
                cubePos = new Vector3(cubePos.x, .1f, cubePos.z);
                GameObject plateObj = Instantiate(plate, transform);
                plateObj.transform.localPosition = cubePos;
                plateObj.transform.localScale = new Vector3 (1f,0f,1f) * size;

                /*//Eşleştireceğimiz küpleri spawnladığımız kısım
                interactCubePosition = new Vector3(size * (x - (texture2D.width * .5f) + interactCubePos.position.x), size * .5f, size * (y - (texture2D.height * .5f) + interactCubePos.position.x));
                GameObject interactCubeObj = Instantiate(interactCube, interactCubePos);
                interactCubeObj.transform.localPosition = interactCubePosition;                
                interactCubeObj.transform.localScale = Vector3.one * size;
                

                */
                
            }
        }
        
        //Resimde kullandığımız pixel kadar küp oluşturuyoruz
        int interactCubeNum = 0;
        Debug.Log(spawnedCube);

        for (int i = 0; i < spawnedCube / 10 + 1; i++)
        {
            if (interactCubeNum == spawnedCube)
            {
                break;
            }
            for (int j = 0; j < 10; j++)
            {
                interactCubePosition = new Vector3(size * (i + interactCubePos.position.x - spawnedCube / 20), size*.5f, size * (j + interactCubePos.position.z));
                GameObject interactCubeObj = Instantiate(interactCube, interactCubePos);
                interactCubeObj.transform.localPosition = interactCubePosition;
                interactCubeObj.transform.localScale = Vector3.one * size;
                interactCubeNum++;
                if (interactCubeNum == spawnedCube)
                {
                    break;
                }
            }
           
        }
    }

}
