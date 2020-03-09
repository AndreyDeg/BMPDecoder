using System;
using System.IO;
using UnityEngine;

public class TestBmpSuite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (var fileName in Directory.GetFiles(".\\Assets\\bmpsuite-2.6\\", "*.bmp", SearchOption.AllDirectories))
        {
            var dir = Path.GetFileName(Path.GetDirectoryName(fileName));
            if (dir != "g" && dir != "q" && dir != "x")
                continue;

            try
            {
                var texture = new BMPDecoder().Decode(fileName);

                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.name = Path.GetFileName(fileName);
                cube.transform.position = new Vector3((i % 10), 0, i / 10);
                var render = cube.GetComponent<Renderer>();
                i++;

                render.material.mainTexture = texture;
                cube.transform.localScale = new Vector3(texture.width, 0.1f, texture.height) / Math.Max(texture.width, texture.height);
            }
            catch (Exception)
            {
            }
        }
    }
}
